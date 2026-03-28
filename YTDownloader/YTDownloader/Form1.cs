using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace YouTubeDownloader
{
    public partial class Form1 : Form
    {
        private bool _isDownloading = false;
        private const string RegistryKeyPath = @"SOFTWARE\YTDownloader";
        private const string OfficialVideoPattern = "(?i)\\s*\\([^)]*(?:official|video|lyrics)[^)]*\\)";
        private List<string> _manualUrls = new List<string>();

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key != null)
                {
                    txtFilePath.Text = key.GetValue("FilePath", "")?.ToString() ?? "";
                    txtOutputPath.Text = key.GetValue("OutputPath", "")?.ToString() ?? "";

                    string sampleRate = key.GetValue("AudioSampleRate", "44100")?.ToString() ?? "44100";
                    int srIndex = cmbSampleRate.Items.IndexOf(sampleRate);
                    cmbSampleRate.SelectedIndex = srIndex >= 0 ? srIndex : 0;

                    // Imposta la modalità prima del bitrate, così vengono aggiunte le opzioni 256/320
                    string mode = key.GetValue("DownloadMode", "0")?.ToString() ?? "0";
                    int modeIndex;
                    cmbMode.SelectedIndex = int.TryParse(mode, out modeIndex) && modeIndex >= 0 && modeIndex < cmbMode.Items.Count ? modeIndex : 0;

                    string bitrate = key.GetValue("AudioBitrate", "128")?.ToString() ?? "128";
                    int brIndex = cmbBitrate.Items.IndexOf(bitrate);
                    cmbBitrate.SelectedIndex = brIndex >= 0 ? brIndex : 0;

                    string cleanTitle = key.GetValue("CleanTitle", "0")?.ToString() ?? "0";
                    chkCleanTitle.Checked = cleanTitle == "1";

                    string capitalize = key.GetValue("CapitalizeTitle", "0")?.ToString() ?? "0";
                    chkCapitalize.Checked = capitalize == "1";
                }
                else
                {
                    cmbSampleRate.SelectedIndex = 0;
                    cmbBitrate.SelectedIndex = 0;
                    cmbMode.SelectedIndex = 0;
                }
            }
        }

        private void SaveSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue("FilePath", txtFilePath.Text);
                key.SetValue("OutputPath", txtOutputPath.Text);
                key.SetValue("AudioSampleRate", cmbSampleRate.SelectedItem?.ToString() ?? "44100");
                key.SetValue("AudioBitrate", cmbBitrate.SelectedItem?.ToString() ?? "128");
                key.SetValue("CleanTitle", chkCleanTitle.Checked ? "1" : "0");
                key.SetValue("CapitalizeTitle", chkCapitalize.Checked ? "1" : "0");
                key.SetValue("DownloadMode", cmbMode.SelectedIndex.ToString());
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings();
            base.OnFormClosing(e);
        }

        private void btnBrowseTxt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
                dlg.Title = "Seleziona il file con i link";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = dlg.FileName;
                    _manualUrls.Clear();
                }
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Seleziona la cartella dove salvare i video";
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtOutputPath.Text = dlg.SelectedPath;
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (_isDownloading)
            {
                MessageBox.Show("Download già in corso!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Leggi URL da file TXT o da link manuali
            List<string> urls = new List<string>();
            if (_manualUrls.Count > 0)
            {
                urls.AddRange(_manualUrls);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
                {
                    MessageBox.Show("Seleziona un file TXT valido o inserisci i link manualmente con il pulsante ➕ Link.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] allLines = File.ReadAllLines(txtFilePath.Text);
                foreach (string line in allLines)
                {
                    string trimmed = line.Trim();
                    if (!string.IsNullOrEmpty(trimmed) && trimmed.StartsWith("http"))
                        urls.Add(trimmed);
                }
            }

            if (urls.Count == 0)
            {
                MessageBox.Show("Nessun URL valido trovato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOutputPath.Text) || !Directory.Exists(txtOutputPath.Text))
            {
                MessageBox.Show("Seleziona una cartella di destinazione valida.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ytDlpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "yt-dlp.exe");
            if (!File.Exists(ytDlpPath))
            {
                MessageBox.Show(
                    "yt-dlp.exe non trovato nella cartella dell'applicazione!\n\nScaricalo da:\nhttps://github.com/yt-dlp/yt-dlp/releases\n\ne mettilo nella stessa cartella dell'exe.",
                    "File mancante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica ffmpeg
            string ffmpegDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/');
            string ffmpegExe = Path.Combine(ffmpegDir, "ffmpeg.exe");
            if (!File.Exists(ffmpegExe))
            {
                MessageBox.Show(
                    "ffmpeg.exe non trovato nella cartella dell'applicazione!\n\nScaricalo da:\nhttps://ffmpeg.org/download.html\n\ne mettilo nella stessa cartella dell'exe.",
                    "File mancante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Setup UI
            _isDownloading = true;
            btnDownload.Enabled = false;
            btnDownload.Text = "⏳ Download in corso...";
            txtLog.Clear();
            progressBar.Minimum = 0;
            progressBar.Maximum = urls.Count;
            progressBar.Value = 0;

            string outputPath = txtOutputPath.Text;
            string sampleRate = cmbSampleRate.SelectedItem?.ToString() ?? "44100";
            string bitrate = cmbBitrate.SelectedItem?.ToString() ?? "128";
            bool cleanTitle = chkCleanTitle.Checked;
            bool capitalize = chkCapitalize.Checked;
            bool audioOnly = cmbMode.SelectedIndex == 1;
            int successCount = 0;
            int errorCount = 0;

            SaveSettings();

            AppendLog($"✅ Trovati {urls.Count} link.");
            AppendLog($"📁 Cartella di salvataggio: {outputPath}");
            AppendLog($"🔧 ffmpeg trovato: {ffmpegExe}");
            AppendLog($"🎛️ Modalità: {(audioOnly ? "Audio Only (MP3)" : "Video (MP4)")}");
            AppendLog($"🎵 Audio: {sampleRate} Hz, {bitrate} kbps");
            if (cleanTitle)
                AppendLog("🏷️ Pulizia titolo attiva (rimozione parentesi Official/Video/Lyrics)");
            if (capitalize)
                AppendLog("🔠 Capitalizzazione nome file attiva");
            AppendLog("");

            // Esegui i download in sequenza, uno alla volta
            await Task.Run(() =>
            {
                for (int i = 0; i < urls.Count; i++)
                {
                    string url = urls[i];

                    UpdateStatus($"Download {i + 1} di {urls.Count}...");
                    AppendLog($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    AppendLog($"[{i + 1}/{urls.Count}] {url}");
                    AppendLog($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                    // Cattura file esistenti prima del download per la capitalizzazione
                    HashSet<string>? existingFiles = null;
                    if (capitalize)
                        existingFiles = new HashSet<string>(Directory.GetFiles(outputPath));

                    // DownloadVideo è sincrono: blocca finché yt-dlp non termina completamente
                    bool ok = DownloadVideo(ytDlpPath, url, outputPath, ffmpegDir, sampleRate, bitrate, cleanTitle, audioOnly);

                    if (ok)
                    {
                        successCount++;

                        // Capitalizza il nome del file scaricato
                        if (capitalize && existingFiles != null)
                        {
                            try
                            {
                                foreach (string file in Directory.GetFiles(outputPath))
                                {
                                    if (!existingFiles.Contains(file))
                                    {
                                        string dir = Path.GetDirectoryName(file)!;
                                        string name = Path.GetFileNameWithoutExtension(file);
                                        string ext = Path.GetExtension(file);
                                        string capitalized = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
                                        string newPath = Path.Combine(dir, capitalized + ext);
                                        if (file != newPath)
                                        {
                                            if (File.Exists(newPath))
                                                File.Delete(newPath);
                                            File.Move(file, newPath);
                                            AppendLog($"  🔠 Rinominato: {Path.GetFileName(newPath)}");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                AppendLog($"  ⚠ Errore capitalizzazione: {ex.Message}");
                            }
                        }
                    }
                    else
                        errorCount++;

                    UpdateProgress(i + 1);
                    AppendLog("");
                }
            });

            // Riepilogo finale
            AppendLog($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            AppendLog($"🏁 COMPLETATO — ✅ {successCount} ok  |  ❌ {errorCount} errori");
            AppendLog($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            UpdateStatus($"✅ Completato! ({successCount}/{urls.Count})");
            _isDownloading = false;
            btnDownload.Enabled = true;
            btnDownload.Text = "▶  Avvia Download";

            MessageBox.Show(
                $"Download completati!\n\n✅ Successi: {successCount}\n❌ Errori: {errorCount}\n\nFile salvati in:\n{outputPath}",
                "Completato", MessageBoxButtons.OK,
                errorCount == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Scarica un singolo video e attende il completamento (download + merge).
        /// Restituisce true se il processo termina con exit code 0.
        /// </summary>
        private bool DownloadVideo(string ytDlpPath, string url, string outputDir, string ffmpegDir, string sampleRate, string bitrate, bool cleanTitle, bool audioOnly)
        {
            string outputTemplate = Path.Combine(outputDir, "%(title)s.%(ext)s");

            string cleanTitleArg = cleanTitle
                ? $"--replace-in-metadata \"title\" \"{OfficialVideoPattern}\" \"\" "
                : "";

            string arguments;

            if (audioOnly)
            {
                // Modalità Audio Only: estrae audio e converte in MP3
                arguments = string.Format(
    "-x --audio-format mp3 --audio-quality {3}K " +
    cleanTitleArg +
    "--postprocessor-args \"ffmpeg:-ar {4}\" " +
    "--ffmpeg-location \"{0}\" " +
    "--no-playlist " +
    "--no-part " +
    "-o \"{1}\" " +
    "\"{2}\"",
    ffmpegDir,
    outputTemplate,
    url,
    bitrate,
    sampleRate
);
            }
            else
            {
                // Modalità Video: preferisce mp4+m4a (nativo, no ricodifica).
                // Fallback: qualsiasi formato con ricodifica audio in AAC per garantire
                // compatibilità con il container mp4 ed evitare errori opus/webm.
                arguments = string.Format(
    "-f \"bestvideo[vcodec^=avc1][ext=mp4]+bestaudio[ext=m4a]/bestvideo[vcodec^=avc1]+bestaudio/best[ext=mp4]/best\" " +
    "--merge-output-format mp4 " +
    cleanTitleArg +
    "--postprocessor-args \"ffmpeg:-c:v copy -c:a aac -b:a {3}k -ar {4}\" " +
    "--ffmpeg-location \"{0}\" " +
    "--no-playlist " +
    "--no-part " +
    "-o \"{1}\" " +
    "\"{2}\"",
    ffmpegDir,
    outputTemplate,
    url,
    bitrate,
    sampleRate
);
            }

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.OutputDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                        AppendLog("  " + ev.Data);
                };
                process.ErrorDataReceived += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data))
                        AppendLog("  ⚠ " + ev.Data);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // WaitForExit() senza timeout: aspetta che yt-dlp finisca
                // completamente (download + merge + pulizia file temporanei)
                // prima di restituire il controllo al ciclo.
                process.WaitForExit();

                int exitCode = process.ExitCode;

                if (exitCode == 0)
                    AppendLog("  ✅ Completato con successo.");
                else
                    AppendLog($"  ❌ Errore (exit code: {exitCode}).");

                return exitCode == 0;
            }
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isAudioOnly = cmbMode.SelectedIndex == 1;
            string currentBitrate = cmbBitrate.SelectedItem?.ToString() ?? "128";

            cmbBitrate.Items.Clear();
            cmbBitrate.Items.AddRange(new object[] { "128", "160", "192" });

            if (isAudioOnly)
            {
                cmbBitrate.Items.Add("256");
                cmbBitrate.Items.Add("320");
            }

            int idx = cmbBitrate.Items.IndexOf(currentBitrate);
            cmbBitrate.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private void btnAddLinks_Click(object sender, EventArgs e)
        {
            using (Form popup = new Form())
            {
                popup.Text = "Inserisci link";
                popup.ClientSize = new Size(500, 370);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.FormBorderStyle = FormBorderStyle.FixedDialog;
                popup.MaximizeBox = false;
                popup.MinimizeBox = false;

                Label lbl = new Label
                {
                    Text = "Inserisci un URL per ogni riga:",
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                TextBox txtLinks = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    Location = new Point(10, 35),
                    Size = new Size(475, 280),
                    Font = new Font("Consolas", 9F)
                };

                // Pre-popola con i link manuali esistenti
                if (_manualUrls.Count > 0)
                    txtLinks.Text = string.Join(Environment.NewLine, _manualUrls);

                Button btnOk = new Button
                {
                    Text = "✅ OK",
                    Location = new Point(320, 325),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.OK
                };

                Button btnCancel = new Button
                {
                    Text = "Annulla",
                    Location = new Point(405, 325),
                    Size = new Size(80, 30),
                    DialogResult = DialogResult.Cancel
                };

                popup.Controls.AddRange(new Control[] { lbl, txtLinks, btnOk, btnCancel });
                popup.AcceptButton = btnOk;
                popup.CancelButton = btnCancel;

                if (popup.ShowDialog(this) == DialogResult.OK)
                {
                    _manualUrls.Clear();
                    string[] lines = txtLinks.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        string trimmed = line.Trim();
                        if (!string.IsNullOrEmpty(trimmed) && trimmed.StartsWith("http"))
                            _manualUrls.Add(trimmed);
                    }

                    if (_manualUrls.Count > 0)
                        txtFilePath.Text = $"(Link inseriti manualmente — {_manualUrls.Count} URL)";
                    else
                        MessageBox.Show("Nessun URL valido trovato nel testo inserito.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ── Helpers thread-safe ──────────────────────────────────────────────

        private void AppendLog(string text)
        {
            if (txtLog.InvokeRequired)
                txtLog.Invoke(new Action(() => txtLog.AppendText(text + Environment.NewLine)));
            else
                txtLog.AppendText(text + Environment.NewLine);
        }

        private void UpdateStatus(string text)
        {
            if (lblStatus.InvokeRequired)
                lblStatus.Invoke(new Action(() => lblStatus.Text = text));
            else
                lblStatus.Text = text;
        }

        private void UpdateProgress(int value)
        {
            if (progressBar.InvokeRequired)
                progressBar.Invoke(new Action(() => progressBar.Value = value));
            else
                progressBar.Value = value;
        }
    }
}