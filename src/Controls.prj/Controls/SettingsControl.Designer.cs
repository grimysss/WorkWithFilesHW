namespace Controls
{
	partial class SettingControl
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
			this._btnLoad = new System.Windows.Forms.Button();
			this._btnSave = new System.Windows.Forms.Button();
			this._chkIsUnderCatalog = new System.Windows.Forms.CheckBox();
			this._chkDetector = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// _btnLoad
			// 
			this._btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnLoad.Location = new System.Drawing.Point(33, 111);
			this._btnLoad.Name = "_btnLoad";
			this._btnLoad.Size = new System.Drawing.Size(75, 23);
			this._btnLoad.TabIndex = 5;
			this._btnLoad.Text = "Загрузить";
			this._btnLoad.UseVisualStyleBackColor = true;
			// 
			// _btnSave
			// 
			this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnSave.Location = new System.Drawing.Point(33, 82);
			this._btnSave.Name = "_btnSave";
			this._btnSave.Size = new System.Drawing.Size(75, 23);
			this._btnSave.TabIndex = 6;
			this._btnSave.Text = "Сохранить";
			this._btnSave.UseVisualStyleBackColor = true;
			this._btnSave.Click += new System.EventHandler(this.OnSaveClickAsync);
			// 
			// _chkIsUnderCatalog
			// 
			this._chkIsUnderCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._chkIsUnderCatalog.AutoSize = true;
			this._chkIsUnderCatalog.Location = new System.Drawing.Point(18, 38);
			this._chkIsUnderCatalog.Name = "_chkIsUnderCatalog";
			this._chkIsUnderCatalog.Size = new System.Drawing.Size(117, 17);
			this._chkIsUnderCatalog.TabIndex = 4;
			this._chkIsUnderCatalog.Text = "С подкаталогами ";
			this._chkIsUnderCatalog.UseVisualStyleBackColor = true;
			this._chkIsUnderCatalog.CheckedChanged += new System.EventHandler(this.OnChangeUnderCatalog);
			// 
			// _chkDetector
			// 
			this._chkDetector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._chkDetector.AutoSize = true;
			this._chkDetector.Location = new System.Drawing.Point(18, 15);
			this._chkDetector.Name = "_chkDetector";
			this._chkDetector.Size = new System.Drawing.Size(114, 17);
			this._chkDetector.TabIndex = 3;
			this._chkDetector.Text = "Детектор сцепок";
			this._chkDetector.UseVisualStyleBackColor = true;
			this._chkDetector.CheckedChanged += new System.EventHandler(this.OnChangeDetector);
			// 
			// SettingControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._btnLoad);
			this.Controls.Add(this._btnSave);
			this.Controls.Add(this._chkIsUnderCatalog);
			this.Controls.Add(this._chkDetector);
			this.Name = "SettingControl";
			this.Size = new System.Drawing.Size(151, 599);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnLoad;
		private System.Windows.Forms.Button _btnSave;
		private System.Windows.Forms.CheckBox _chkIsUnderCatalog;
		private System.Windows.Forms.CheckBox _chkDetector;
	}
}
