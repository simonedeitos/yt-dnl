namespace YouTubeDownloader
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.btnBrowseTxt = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.lblSampleRate = new System.Windows.Forms.Label();
            this.cmbSampleRate = new System.Windows.Forms.ComboBox();
            this.lblBitrate = new System.Windows.Forms.Label();
            this.cmbBitrate = new System.Windows.Forms.ComboBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInput.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();

            // ── lblTitle ──────────────────────────────────────────────────────
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 120);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎬 YouTube Bulk Downloader";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── grpInput ──────────────────────────────────────────────────────
            this.grpInput.Controls.Add(this.lblFilePath);
            this.grpInput.Controls.Add(this.txtFilePath);
            this.grpInput.Controls.Add(this.btnBrowseTxt);
            this.grpInput.Controls.Add(this.lblOutputPath);
            this.grpInput.Controls.Add(this.txtOutputPath);
            this.grpInput.Controls.Add(this.btnBrowseOutput);
            this.grpInput.Controls.Add(this.lblSampleRate);
            this.grpInput.Controls.Add(this.cmbSampleRate);
            this.grpInput.Controls.Add(this.lblBitrate);
            this.grpInput.Controls.Add(this.cmbBitrate);
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpInput.Location = new System.Drawing.Point(12, 55);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(760, 155);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Impostazioni";

            // ── lblFilePath ───────────────────────────────────────────────────
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(10, 28);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(120, 15);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "File TXT con gli URL:";

            // ── txtFilePath ───────────────────────────────────────────────────
            this.txtFilePath.Location = new System.Drawing.Point(160, 25);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(490, 23);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.PlaceholderText = "Seleziona il file .txt contenente un URL per ogni riga...";

            // ── btnBrowseTxt ──────────────────────────────────────────────────
            this.btnBrowseTxt.Location = new System.Drawing.Point(660, 23);
            this.btnBrowseTxt.Name = "btnBrowseTxt";
            this.btnBrowseTxt.Size = new System.Drawing.Size(88, 27);
            this.btnBrowseTxt.TabIndex = 2;
            this.btnBrowseTxt.Text = "📂 Sfoglia";
            this.btnBrowseTxt.UseVisualStyleBackColor = true;
            this.btnBrowseTxt.Click += new System.EventHandler(this.btnBrowseTxt_Click);

            // ── lblOutputPath ─────────────────────────────────────────────────
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(10, 70);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(120, 15);
            this.lblOutputPath.TabIndex = 3;
            this.lblOutputPath.Text = "Cartella di salvataggio:";

            // ── txtOutputPath ─────────────────────────────────────────────────
            this.txtOutputPath.Location = new System.Drawing.Point(160, 67);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(490, 23);
            this.txtOutputPath.TabIndex = 4;
            this.txtOutputPath.PlaceholderText = "Seleziona la cartella dove salvare i video...";

            // ── btnBrowseOutput ───────────────────────────────────────────────
            this.btnBrowseOutput.Location = new System.Drawing.Point(660, 65);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(88, 27);
            this.btnBrowseOutput.TabIndex = 5;
            this.btnBrowseOutput.Text = "📂 Sfoglia";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);

            // ── lblSampleRate ─────────────────────────────────────────────────
            this.lblSampleRate.AutoSize = true;
            this.lblSampleRate.Location = new System.Drawing.Point(10, 112);
            this.lblSampleRate.Name = "lblSampleRate";
            this.lblSampleRate.Size = new System.Drawing.Size(120, 15);
            this.lblSampleRate.TabIndex = 6;
            this.lblSampleRate.Text = "Sample rate audio:";

            // ── cmbSampleRate ─────────────────────────────────────────────────
            this.cmbSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSampleRate.Items.AddRange(new object[] { "44100", "48000" });
            this.cmbSampleRate.Location = new System.Drawing.Point(160, 109);
            this.cmbSampleRate.Name = "cmbSampleRate";
            this.cmbSampleRate.Size = new System.Drawing.Size(120, 23);
            this.cmbSampleRate.TabIndex = 7;

            // ── lblBitrate ────────────────────────────────────────────────────
            this.lblBitrate.AutoSize = true;
            this.lblBitrate.Location = new System.Drawing.Point(320, 112);
            this.lblBitrate.Name = "lblBitrate";
            this.lblBitrate.Size = new System.Drawing.Size(100, 15);
            this.lblBitrate.TabIndex = 8;
            this.lblBitrate.Text = "Bitrate audio:";

            // ── cmbBitrate ────────────────────────────────────────────────────
            this.cmbBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitrate.Items.AddRange(new object[] { "128", "160", "192" });
            this.cmbBitrate.Location = new System.Drawing.Point(430, 109);
            this.cmbBitrate.Name = "cmbBitrate";
            this.cmbBitrate.Size = new System.Drawing.Size(120, 23);
            this.cmbBitrate.TabIndex = 9;

            // ── btnDownload ───────────────────────────────────────────────────
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(12, 220);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(220, 40);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "▶  Avvia Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);

            // ── progressBar ───────────────────────────────────────────────────
            this.progressBar.Location = new System.Drawing.Point(245, 228);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(420, 24);
            this.progressBar.TabIndex = 3;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            // ── lblStatus ─────────────────────────────────────────────────────
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(672, 233);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Pronto";

            // ── grpLog ────────────────────────────────────────────────────────
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpLog.Location = new System.Drawing.Point(12, 270);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(760, 313);
            this.grpLog.TabIndex = 5;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log di output";

            // ── txtLog ────────────────────────────────────────────────────────
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.txtLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(8, 22);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(744, 283);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";

            // ── Form1 ─────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 596);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpLog);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YouTube Bulk Downloader";
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowseTxt;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label lblSampleRate;
        private System.Windows.Forms.ComboBox cmbSampleRate;
        private System.Windows.Forms.Label lblBitrate;
        private System.Windows.Forms.ComboBox cmbBitrate;
    }
}