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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            grpInput = new GroupBox();
            lblFilePath = new Label();
            txtFilePath = new TextBox();
            btnBrowseTxt = new Button();
            lblOutputPath = new Label();
            txtOutputPath = new TextBox();
            btnBrowseOutput = new Button();
            lblSampleRate = new Label();
            cmbSampleRate = new ComboBox();
            lblBitrate = new Label();
            cmbBitrate = new ComboBox();
            chkCleanTitle = new CheckBox();
            btnDownload = new Button();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            grpLog = new GroupBox();
            txtLog = new RichTextBox();
            lblTitle = new Label();
            label1 = new Label();
            grpInput.SuspendLayout();
            grpLog.SuspendLayout();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(lblFilePath);
            grpInput.Controls.Add(txtFilePath);
            grpInput.Controls.Add(btnBrowseTxt);
            grpInput.Controls.Add(lblOutputPath);
            grpInput.Controls.Add(txtOutputPath);
            grpInput.Controls.Add(btnBrowseOutput);
            grpInput.Controls.Add(lblSampleRate);
            grpInput.Controls.Add(cmbSampleRate);
            grpInput.Controls.Add(lblBitrate);
            grpInput.Controls.Add(cmbBitrate);
            grpInput.Controls.Add(chkCleanTitle);
            grpInput.Font = new Font("Segoe UI", 9F);
            grpInput.Location = new Point(12, 55);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(760, 185);
            grpInput.TabIndex = 1;
            grpInput.TabStop = false;
            grpInput.Text = "Impostazioni";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(10, 28);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(113, 15);
            lblFilePath.TabIndex = 0;
            lblFilePath.Text = "File TXT con gli URL:";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(160, 25);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.PlaceholderText = "Seleziona il file .txt contenente un URL per ogni riga...";
            txtFilePath.Size = new Size(490, 23);
            txtFilePath.TabIndex = 1;
            // 
            // btnBrowseTxt
            // 
            btnBrowseTxt.Location = new Point(660, 23);
            btnBrowseTxt.Name = "btnBrowseTxt";
            btnBrowseTxt.Size = new Size(88, 27);
            btnBrowseTxt.TabIndex = 2;
            btnBrowseTxt.Text = "📂 Sfoglia";
            btnBrowseTxt.UseVisualStyleBackColor = true;
            btnBrowseTxt.Click += btnBrowseTxt_Click;
            // 
            // lblOutputPath
            // 
            lblOutputPath.AutoSize = true;
            lblOutputPath.Location = new Point(10, 70);
            lblOutputPath.Name = "lblOutputPath";
            lblOutputPath.Size = new Size(126, 15);
            lblOutputPath.TabIndex = 3;
            lblOutputPath.Text = "Cartella di salvataggio:";
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(160, 67);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.PlaceholderText = "Seleziona la cartella dove salvare i video...";
            txtOutputPath.Size = new Size(490, 23);
            txtOutputPath.TabIndex = 4;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(660, 65);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(88, 27);
            btnBrowseOutput.TabIndex = 5;
            btnBrowseOutput.Text = "📂 Sfoglia";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // lblSampleRate
            // 
            lblSampleRate.AutoSize = true;
            lblSampleRate.Location = new Point(10, 112);
            lblSampleRate.Name = "lblSampleRate";
            lblSampleRate.Size = new Size(105, 15);
            lblSampleRate.TabIndex = 6;
            lblSampleRate.Text = "Sample rate audio:";
            // 
            // cmbSampleRate
            // 
            cmbSampleRate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSampleRate.Items.AddRange(new object[] { "44100", "48000" });
            cmbSampleRate.Location = new Point(160, 109);
            cmbSampleRate.Name = "cmbSampleRate";
            cmbSampleRate.Size = new Size(120, 23);
            cmbSampleRate.TabIndex = 7;
            // 
            // lblBitrate
            // 
            lblBitrate.AutoSize = true;
            lblBitrate.Location = new Point(320, 112);
            lblBitrate.Name = "lblBitrate";
            lblBitrate.Size = new Size(77, 15);
            lblBitrate.TabIndex = 8;
            lblBitrate.Text = "Bitrate audio:";
            // 
            // cmbBitrate
            // 
            cmbBitrate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBitrate.Items.AddRange(new object[] { "128", "160", "192" });
            cmbBitrate.Location = new Point(430, 109);
            cmbBitrate.Name = "cmbBitrate";
            cmbBitrate.Size = new Size(120, 23);
            cmbBitrate.TabIndex = 9;
            // 
            // chkCleanTitle
            // 
            chkCleanTitle.AutoSize = true;
            chkCleanTitle.Location = new Point(10, 145);
            chkCleanTitle.Name = "chkCleanTitle";
            chkCleanTitle.Size = new Size(282, 19);
            chkCleanTitle.TabIndex = 10;
            chkCleanTitle.Text = "Rimuovi dal titolo le parentesi con Official/Video";
            chkCleanTitle.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.FromArgb(0, 120, 215);
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(12, 250);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(220, 40);
            btnDownload.TabIndex = 2;
            btnDownload.Text = "▶  Avvia Download";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(245, 258);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(420, 24);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(672, 263);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(41, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Pronto";
            // 
            // grpLog
            // 
            grpLog.Controls.Add(txtLog);
            grpLog.Font = new Font("Segoe UI", 9F);
            grpLog.Location = new Point(12, 300);
            grpLog.Name = "grpLog";
            grpLog.Size = new Size(760, 313);
            grpLog.TabIndex = 5;
            grpLog.TabStop = false;
            grpLog.Text = "Log di output";
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.FromArgb(20, 20, 20);
            txtLog.Font = new Font("Consolas", 9F);
            txtLog.ForeColor = Color.LimeGreen;
            txtLog.Location = new Point(8, 22);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLog.Size = new Size(744, 283);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 30, 120);
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(760, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎬 High Quality YouTube Video Downloader";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(652, 612);
            label1.Name = "label1";
            label1.Size = new Size(129, 13);
            label1.TabIndex = 6;
            label1.Text = "Creato da Simone Dei Tos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(784, 627);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(grpInput);
            Controls.Add(btnDownload);
            Controls.Add(progressBar);
            Controls.Add(lblStatus);
            Controls.Add(grpLog);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YouTube Downloader";
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            grpLog.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.CheckBox chkCleanTitle;
        private Label label1;
    }
}
