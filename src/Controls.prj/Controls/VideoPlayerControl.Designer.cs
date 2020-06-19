namespace Controls
{
	partial class VideoPlayerControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._pnlImages = new System.Windows.Forms.Panel();
			this._pnlButControl = new System.Windows.Forms.Panel();
			this._btnPause = new System.Windows.Forms.Button();
			this._btnStop = new System.Windows.Forms.Button();
			this._btnOpenFolder = new System.Windows.Forms.Button();
			this._btnImageBack = new System.Windows.Forms.Button();
			this._btnStart = new System.Windows.Forms.Button();
			this._btnOpenFile = new System.Windows.Forms.Button();
			this._btnImageNext = new System.Windows.Forms.Button();
			this._opnFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._opnFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this._picVideo = new OpenCvSharp.UserInterface.PictureBoxIpl();
			this._pnlImages.SuspendLayout();
			this._pnlButControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._picVideo)).BeginInit();
			this.SuspendLayout();
			// 
			// _pnlImages
			// 
			this._pnlImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._pnlImages.Controls.Add(this._picVideo);
			this._pnlImages.Location = new System.Drawing.Point(0, 0);
			this._pnlImages.Name = "_pnlImages";
			this._pnlImages.Size = new System.Drawing.Size(667, 445);
			this._pnlImages.TabIndex = 0;
			// 
			// _pnlButControl
			// 
			this._pnlButControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._pnlButControl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this._pnlButControl.Controls.Add(this._btnPause);
			this._pnlButControl.Controls.Add(this._btnStop);
			this._pnlButControl.Controls.Add(this._btnOpenFolder);
			this._pnlButControl.Controls.Add(this._btnImageBack);
			this._pnlButControl.Controls.Add(this._btnStart);
			this._pnlButControl.Controls.Add(this._btnOpenFile);
			this._pnlButControl.Controls.Add(this._btnImageNext);
			this._pnlButControl.Location = new System.Drawing.Point(0, 437);
			this._pnlButControl.Name = "_pnlButControl";
			this._pnlButControl.Size = new System.Drawing.Size(667, 77);
			this._pnlButControl.TabIndex = 1;
			// 
			// _btnPause
			// 
			this._btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnPause.Location = new System.Drawing.Point(579, 29);
			this._btnPause.Name = "_btnPause";
			this._btnPause.Size = new System.Drawing.Size(75, 23);
			this._btnPause.TabIndex = 3;
			this._btnPause.TabStop = false;
			this._btnPause.Text = "Пауза";
			this._btnPause.UseVisualStyleBackColor = true;
			this._btnPause.Click += new System.EventHandler(this.OnPauseClickAsync);
			// 
			// _btnStop
			// 
			this._btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnStop.Location = new System.Drawing.Point(498, 29);
			this._btnStop.Name = "_btnStop";
			this._btnStop.Size = new System.Drawing.Size(75, 23);
			this._btnStop.TabIndex = 2;
			this._btnStop.TabStop = false;
			this._btnStop.Text = "Стоп";
			this._btnStop.UseVisualStyleBackColor = true;
			this._btnStop.Click += new System.EventHandler(this.OnStopClickAsync);
			// 
			// _btnOpenFolder
			// 
			this._btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btnOpenFolder.Location = new System.Drawing.Point(3, 43);
			this._btnOpenFolder.Name = "_btnOpenFolder";
			this._btnOpenFolder.Size = new System.Drawing.Size(144, 23);
			this._btnOpenFolder.TabIndex = 7;
			this._btnOpenFolder.TabStop = false;
			this._btnOpenFolder.Text = "Открыть папку";
			this._btnOpenFolder.UseVisualStyleBackColor = true;
			this._btnOpenFolder.Click += new System.EventHandler(this.OnOpenFolderClick);
			// 
			// _btnImageBack
			// 
			this._btnImageBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btnImageBack.Location = new System.Drawing.Point(154, 30);
			this._btnImageBack.Name = "_btnImageBack";
			this._btnImageBack.Size = new System.Drawing.Size(75, 23);
			this._btnImageBack.TabIndex = 4;
			this._btnImageBack.TabStop = false;
			this._btnImageBack.Text = "<<";
			this._btnImageBack.UseVisualStyleBackColor = true;
			this._btnImageBack.Click += new System.EventHandler(this.OnPreviousClick);
			// 
			// _btnStart
			// 
			this._btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnStart.Location = new System.Drawing.Point(417, 29);
			this._btnStart.Name = "_btnStart";
			this._btnStart.Size = new System.Drawing.Size(75, 23);
			this._btnStart.TabIndex = 1;
			this._btnStart.TabStop = false;
			this._btnStart.Text = "Старт";
			this._btnStart.UseVisualStyleBackColor = true;
			this._btnStart.Click += new System.EventHandler(this.OnStartClickAsync);
			// 
			// _btnOpenFile
			// 
			this._btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btnOpenFile.Location = new System.Drawing.Point(3, 14);
			this._btnOpenFile.Name = "_btnOpenFile";
			this._btnOpenFile.Size = new System.Drawing.Size(144, 23);
			this._btnOpenFile.TabIndex = 6;
			this._btnOpenFile.TabStop = false;
			this._btnOpenFile.Text = "Открыть файл";
			this._btnOpenFile.UseVisualStyleBackColor = true;
			this._btnOpenFile.Click += new System.EventHandler(this.OnOpenFileClickAsync);
			// 
			// _btnImageNext
			// 
			this._btnImageNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btnImageNext.Location = new System.Drawing.Point(235, 30);
			this._btnImageNext.Name = "_btnImageNext";
			this._btnImageNext.Size = new System.Drawing.Size(75, 23);
			this._btnImageNext.TabIndex = 5;
			this._btnImageNext.TabStop = false;
			this._btnImageNext.Text = ">>";
			this._btnImageNext.UseVisualStyleBackColor = true;
			this._btnImageNext.Click += new System.EventHandler(this.OnNextClick);
			// 
			// _opnFileDialog
			// 
			this._opnFileDialog.FileName = "openFileDialog1";
			// 
			// _picVideo
			// 
			this._picVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._picVideo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this._picVideo.Location = new System.Drawing.Point(0, 0);
			this._picVideo.Name = "_picVideo";
			this._picVideo.Size = new System.Drawing.Size(667, 442);
			this._picVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this._picVideo.TabIndex = 0;
			this._picVideo.TabStop = false;
			// 
			// VideoPlayerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._pnlButControl);
			this.Controls.Add(this._pnlImages);
			this.Name = "VideoPlayerControl";
			this.Size = new System.Drawing.Size(667, 514);
			this._pnlImages.ResumeLayout(false);
			this._pnlButControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._picVideo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel _pnlImages;
		private System.Windows.Forms.Panel _pnlButControl;
		private System.Windows.Forms.Button _btnPause;
		private System.Windows.Forms.Button _btnStop;
		private System.Windows.Forms.Button _btnOpenFolder;
		private System.Windows.Forms.Button _btnImageBack;
		private System.Windows.Forms.Button _btnStart;
		private System.Windows.Forms.Button _btnOpenFile;
		private System.Windows.Forms.Button _btnImageNext;
		private System.Windows.Forms.OpenFileDialog _opnFileDialog;
		private System.Windows.Forms.FolderBrowserDialog _opnFolderDialog;
		private OpenCvSharp.UserInterface.PictureBoxIpl _picVideo;
	}
}
