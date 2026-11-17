namespace RentalManagement.Forms
{
    partial class FirstRunDialog
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = false;
            this.lblInfo.Location = new System.Drawing.Point(16, 64);
            this.lblInfo.Size = new System.Drawing.Size(464, 44);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo.Text = "—";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.Name = "lblInfo";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = false;
            this.lblUser.Location = new System.Drawing.Point(16, 114);
            this.lblUser.Size = new System.Drawing.Size(150, 27);
            this.lblUser.Text = "اسم المستخدم *";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.Name = "lblUser";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(176, 114);
            this.txtUser.Size = new System.Drawing.Size(304, 27);
            this.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUser.MaxLength = 50;
            this.txtUser.Name = "txtUser";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = false;
            this.lblFullName.Location = new System.Drawing.Point(16, 154);
            this.lblFullName.Size = new System.Drawing.Size(150, 27);
            this.lblFullName.Text = "الاسم الكامل *";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFullName.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblFullName.Name = "lblFullName";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(176, 154);
            this.txtFullName.Size = new System.Drawing.Size(304, 27);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = false;
            this.lblPass.Location = new System.Drawing.Point(16, 194);
            this.lblPass.Size = new System.Drawing.Size(150, 27);
            this.lblPass.Text = "كلمة المرور *";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPass.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblPass.Name = "lblPass";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(176, 194);
            this.txtPass.Size = new System.Drawing.Size(304, 27);
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.MaxLength = 100;
            this.txtPass.Name = "txtPass";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = false;
            this.lblConfirm.Location = new System.Drawing.Point(16, 234);
            this.lblConfirm.Size = new System.Drawing.Size(150, 27);
            this.lblConfirm.Text = "تأكيد كلمة المرور *";
            this.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConfirm.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfirm.Name = "lblConfirm";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(176, 234);
            this.txtConfirm.Size = new System.Drawing.Size(304, 27);
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.MaxLength = 100;
            this.txtConfirm.Name = "txtConfirm";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(500, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 12);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "إنشاء";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 12);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(500, 48);
            this.lblHeader.Text = "أول تشغيل — إنشاء حساب المدير";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // FirstRunDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 342);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "أول تشغيل — إنشاء حساب المدير";
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "FirstRunDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
