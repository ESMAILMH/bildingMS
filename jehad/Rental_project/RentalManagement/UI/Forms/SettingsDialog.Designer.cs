namespace RentalManagement.Forms
{
    partial class SettingsDialog
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOffice = new System.Windows.Forms.Label();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAlertDays = new System.Windows.Forms.Label();
            this.numAlertDays = new System.Windows.Forms.NumericUpDown();
            this.lblBackupInfo = new System.Windows.Forms.Label();
            this.lblBackupFolder = new System.Windows.Forms.Label();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlertDays)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOffice
            // 
            this.lblOffice.AutoSize = false;
            this.lblOffice.Location = new System.Drawing.Point(16, 64);
            this.lblOffice.Size = new System.Drawing.Size(210, 27);
            this.lblOffice.Text = "اسم المكتب / المالك *";
            this.lblOffice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOffice.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblOffice.Name = "lblOffice";
            // 
            // txtOffice
            // 
            this.txtOffice.Location = new System.Drawing.Point(236, 64);
            this.txtOffice.Size = new System.Drawing.Size(364, 27);
            this.txtOffice.MaxLength = 150;
            this.txtOffice.Name = "txtOffice";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = false;
            this.lblPhone.Location = new System.Drawing.Point(16, 104);
            this.lblPhone.Size = new System.Drawing.Size(210, 27);
            this.lblPhone.Text = "الهاتف";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhone.Name = "lblPhone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(236, 104);
            this.txtPhone.Size = new System.Drawing.Size(364, 27);
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.MaxLength = 30;
            this.txtPhone.Name = "txtPhone";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = false;
            this.lblAddress.Location = new System.Drawing.Point(16, 144);
            this.lblAddress.Size = new System.Drawing.Size(210, 27);
            this.lblAddress.Text = "العنوان";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddress.Name = "lblAddress";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(236, 144);
            this.txtAddress.Size = new System.Drawing.Size(364, 27);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            // 
            // lblAlertDays
            // 
            this.lblAlertDays.AutoSize = false;
            this.lblAlertDays.Location = new System.Drawing.Point(16, 184);
            this.lblAlertDays.Size = new System.Drawing.Size(210, 27);
            this.lblAlertDays.Text = "التنبيه قبل انتهاء العقد (يوم) *";
            this.lblAlertDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlertDays.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblAlertDays.Name = "lblAlertDays";
            // 
            // numAlertDays
            // 
            this.numAlertDays.Location = new System.Drawing.Point(236, 184);
            this.numAlertDays.Size = new System.Drawing.Size(110, 27);
            this.numAlertDays.DecimalPlaces = 0;
            this.numAlertDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numAlertDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numAlertDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAlertDays.Name = "numAlertDays";
            // 
            // lblBackupInfo
            // 
            this.lblBackupInfo.AutoSize = false;
            this.lblBackupInfo.Location = new System.Drawing.Point(16, 224);
            this.lblBackupInfo.Size = new System.Drawing.Size(584, 44);
            this.lblBackupInfo.ForeColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.lblBackupInfo.Text = "النسخة الاحتياطية تُحفظ بواسطة خدمة SQL Server: اختر مجلداً على جهاز الخادم (مثل C:\\Backup).";
            this.lblBackupInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackupInfo.Name = "lblBackupInfo";
            // 
            // lblBackupFolder
            // 
            this.lblBackupFolder.AutoSize = false;
            this.lblBackupFolder.Location = new System.Drawing.Point(16, 274);
            this.lblBackupFolder.Size = new System.Drawing.Size(210, 27);
            this.lblBackupFolder.Text = "مجلد النسخ الاحتياطي";
            this.lblBackupFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBackupFolder.Name = "lblBackupFolder";
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Location = new System.Drawing.Point(236, 274);
            this.txtBackupFolder.Size = new System.Drawing.Size(364, 27);
            this.txtBackupFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupFolder.MaxLength = 260;
            this.txtBackupFolder.Name = "txtBackupFolder";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnBackup);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(620, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 12);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 12);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Text = "إغلاق";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(276, 12);
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(62, 125, 58);
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Size = new System.Drawing.Size(200, 36);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBackup.Text = "💾 نسخة احتياطية الآن";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(620, 48);
            this.lblHeader.Text = "الإعدادات";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(620, 382);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "الإعدادات";
            this.Controls.Add(this.lblOffice);
            this.Controls.Add(this.txtOffice);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAlertDays);
            this.Controls.Add(this.numAlertDays);
            this.Controls.Add(this.lblBackupInfo);
            this.Controls.Add(this.lblBackupFolder);
            this.Controls.Add(this.txtBackupFolder);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "SettingsDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.numAlertDays)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblOffice;
        private System.Windows.Forms.TextBox txtOffice;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAlertDays;
        private System.Windows.Forms.NumericUpDown numAlertDays;
        private System.Windows.Forms.Label lblBackupInfo;
        private System.Windows.Forms.Label lblBackupFolder;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblHeader;
    }
}
