namespace RentalManagement.Forms
{
    partial class PropertyDialog
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
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
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
            this.lblName.Size = new System.Drawing.Size(150, 27);
            this.lblName.Text = "اسم العقار *";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Name = "lblName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(176, 64);
            this.txtName.Size = new System.Drawing.Size(324, 27);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            // 
            // lblType
            // 
            this.lblType.AutoSize = false;
            this.lblType.Location = new System.Drawing.Point(16, 104);
            this.lblType.Size = new System.Drawing.Size(150, 27);
            this.lblType.Text = "نوع العقار *";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblType.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblType.Name = "lblType";
            // 
            // cmbType
            // 
            this.cmbType.Location = new System.Drawing.Point(176, 104);
            this.cmbType.Size = new System.Drawing.Size(324, 28);
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Name = "cmbType";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = false;
            this.lblCity.Location = new System.Drawing.Point(16, 144);
            this.lblCity.Size = new System.Drawing.Size(150, 27);
            this.lblCity.Text = "المدينة *";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCity.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblCity.Name = "lblCity";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(176, 144);
            this.txtCity.Size = new System.Drawing.Size(324, 27);
            this.txtCity.MaxLength = 60;
            this.txtCity.Name = "txtCity";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = false;
            this.lblAddress.Location = new System.Drawing.Point(16, 184);
            this.lblAddress.Size = new System.Drawing.Size(150, 27);
            this.lblAddress.Text = "العنوان";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddress.Name = "lblAddress";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(176, 184);
            this.txtAddress.Size = new System.Drawing.Size(324, 27);
            this.txtAddress.MaxLength = 250;
            this.txtAddress.Name = "txtAddress";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = false;
            this.lblNotes.Location = new System.Drawing.Point(16, 224);
            this.lblNotes.Size = new System.Drawing.Size(150, 27);
            this.lblNotes.Text = "ملاحظات";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Name = "lblNotes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(176, 224);
            this.txtNotes.Size = new System.Drawing.Size(324, 60);
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Name = "txtNotes";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Text = "فعّال";
            this.chkActive.Location = new System.Drawing.Point(176, 297);
            this.chkActive.Name = "chkActive";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(520, 60);
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
            this.lblHeader.Size = new System.Drawing.Size(520, 48);
            this.lblHeader.Text = "عقار";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // PropertyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 405);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "عقار";
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "PropertyDialog";
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
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
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
