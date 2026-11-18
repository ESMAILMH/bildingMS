namespace RentalManagement.Forms
{
    partial class TenantDialog
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblNationalId = new System.Windows.Forms.Label();
            this.txtNationalId = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = false;
            this.lblName.Location = new System.Drawing.Point(16, 64);
            this.lblName.Size = new System.Drawing.Size(170, 27);
            this.lblName.Text = "الاسم الكامل *";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Name = "lblName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(196, 64);
            this.txtName.Size = new System.Drawing.Size(324, 27);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            // 
            // lblNationalId
            // 
            this.lblNationalId.AutoSize = false;
            this.lblNationalId.Location = new System.Drawing.Point(16, 104);
            this.lblNationalId.Size = new System.Drawing.Size(170, 27);
            this.lblNationalId.Text = "الرقم الوطني / السجل *";
            this.lblNationalId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNationalId.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblNationalId.Name = "lblNationalId";
            // 
            // txtNationalId
            // 
            this.txtNationalId.Location = new System.Drawing.Point(196, 104);
            this.txtNationalId.Size = new System.Drawing.Size(324, 27);
            this.txtNationalId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNationalId.MaxLength = 30;
            this.txtNationalId.Name = "txtNationalId";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = false;
            this.lblPhone.Location = new System.Drawing.Point(16, 144);
            this.lblPhone.Size = new System.Drawing.Size(170, 27);
            this.lblPhone.Text = "الهاتف *";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhone.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Name = "lblPhone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(196, 144);
            this.txtPhone.Size = new System.Drawing.Size(324, 27);
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.MaxLength = 30;
            this.txtPhone.Name = "txtPhone";
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = false;
            this.lblPhone2.Location = new System.Drawing.Point(16, 184);
            this.lblPhone2.Size = new System.Drawing.Size(170, 27);
            this.lblPhone2.Text = "هاتف آخر";
            this.lblPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhone2.Name = "lblPhone2";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(196, 184);
            this.txtPhone2.Size = new System.Drawing.Size(324, 27);
            this.txtPhone2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone2.MaxLength = 30;
            this.txtPhone2.Name = "txtPhone2";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = false;
            this.lblEmail.Location = new System.Drawing.Point(16, 224);
            this.lblEmail.Size = new System.Drawing.Size(170, 27);
            this.lblEmail.Text = "البريد الإلكتروني";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmail.Name = "lblEmail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(196, 224);
            this.txtEmail.Size = new System.Drawing.Size(324, 27);
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = false;
            this.lblAddress.Location = new System.Drawing.Point(16, 264);
            this.lblAddress.Size = new System.Drawing.Size(170, 27);
            this.lblAddress.Text = "العنوان";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddress.Name = "lblAddress";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(196, 264);
            this.txtAddress.Size = new System.Drawing.Size(324, 27);
            this.txtAddress.MaxLength = 250;
            this.txtAddress.Name = "txtAddress";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = false;
            this.lblNotes.Location = new System.Drawing.Point(16, 304);
            this.lblNotes.Size = new System.Drawing.Size(170, 27);
            this.lblNotes.Text = "ملاحظات";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Name = "lblNotes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(196, 304);
            this.txtNotes.Size = new System.Drawing.Size(324, 50);
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Name = "txtNotes";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Text = "فعّال";
            this.chkActive.Location = new System.Drawing.Point(196, 367);
            this.chkActive.Name = "chkActive";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(540, 60);
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
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(540, 48);
            this.lblHeader.Text = "مستأجر";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // TenantDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 475);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مستأجر";
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblNationalId);
            this.Controls.Add(this.txtNationalId);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone2);
            this.Controls.Add(this.txtPhone2);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "TenantDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNationalId;
        private System.Windows.Forms.TextBox txtNationalId;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
