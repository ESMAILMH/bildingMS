namespace RentalManagement.Forms
{
    partial class PaymentDialog
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
            this.lblContract = new System.Windows.Forms.Label();
            this.cmbContract = new System.Windows.Forms.ComboBox();
            this.lblInstallment = new System.Windows.Forms.Label();
            this.cmbInstallment = new System.Windows.Forms.ComboBox();
            this.lblCapRemaining = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = false;
            this.lblContract.Location = new System.Drawing.Point(16, 64);
            this.lblContract.Size = new System.Drawing.Size(160, 27);
            this.lblContract.Text = "العقد *";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContract.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblContract.Name = "lblContract";
            // 
            // cmbContract
            // 
            this.cmbContract.Location = new System.Drawing.Point(186, 64);
            this.cmbContract.Size = new System.Drawing.Size(414, 28);
            this.cmbContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContract.Name = "cmbContract";
            // 
            // lblInstallment
            // 
            this.lblInstallment.AutoSize = false;
            this.lblInstallment.Location = new System.Drawing.Point(16, 104);
            this.lblInstallment.Size = new System.Drawing.Size(160, 27);
            this.lblInstallment.Text = "القسط *";
            this.lblInstallment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInstallment.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblInstallment.Name = "lblInstallment";
            // 
            // cmbInstallment
            // 
            this.cmbInstallment.Location = new System.Drawing.Point(186, 104);
            this.cmbInstallment.Size = new System.Drawing.Size(414, 28);
            this.cmbInstallment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstallment.Name = "cmbInstallment";
            // 
            // lblCapRemaining
            // 
            this.lblCapRemaining.AutoSize = false;
            this.lblCapRemaining.Location = new System.Drawing.Point(16, 144);
            this.lblCapRemaining.Size = new System.Drawing.Size(160, 27);
            this.lblCapRemaining.Text = "المتبقي على القسط";
            this.lblCapRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapRemaining.Name = "lblCapRemaining";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = false;
            this.lblRemaining.AutoEllipsis = true;
            this.lblRemaining.Location = new System.Drawing.Point(186, 144);
            this.lblRemaining.Size = new System.Drawing.Size(414, 27);
            this.lblRemaining.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblRemaining.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblRemaining.Text = "—";
            this.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemaining.Name = "lblRemaining";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = false;
            this.lblAmount.Location = new System.Drawing.Point(16, 184);
            this.lblAmount.Size = new System.Drawing.Size(160, 27);
            this.lblAmount.Text = "المبلغ المدفوع *";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAmount.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Name = "lblAmount";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(186, 184);
            this.numAmount.Size = new System.Drawing.Size(200, 27);
            this.numAmount.DecimalPlaces = 3;
            this.numAmount.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numAmount.ThousandsSeparator = true;
            this.numAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAmount.Name = "numAmount";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = false;
            this.lblDate.Location = new System.Drawing.Point(16, 224);
            this.lblDate.Size = new System.Drawing.Size(160, 27);
            this.lblDate.Text = "تاريخ الدفع *";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblDate.Name = "lblDate";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(186, 224);
            this.dtpDate.Size = new System.Drawing.Size(180, 27);
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Name = "dtpDate";
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = false;
            this.lblMethod.Location = new System.Drawing.Point(16, 264);
            this.lblMethod.Size = new System.Drawing.Size(160, 27);
            this.lblMethod.Text = "طريقة الدفع *";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMethod.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblMethod.Name = "lblMethod";
            // 
            // cmbMethod
            // 
            this.cmbMethod.Location = new System.Drawing.Point(186, 264);
            this.cmbMethod.Size = new System.Drawing.Size(414, 28);
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.Name = "cmbMethod";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = false;
            this.lblReference.Location = new System.Drawing.Point(16, 304);
            this.lblReference.Size = new System.Drawing.Size(160, 27);
            this.lblReference.Text = "رقم الصك / الحوالة";
            this.lblReference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReference.Name = "lblReference";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(186, 304);
            this.txtReference.Size = new System.Drawing.Size(414, 27);
            this.txtReference.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReference.MaxLength = 50;
            this.txtReference.Name = "txtReference";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = false;
            this.lblNotes.Location = new System.Drawing.Point(16, 344);
            this.lblNotes.Size = new System.Drawing.Size(160, 27);
            this.lblNotes.Text = "ملاحظات";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Name = "lblNotes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(186, 344);
            this.txtNotes.Size = new System.Drawing.Size(414, 27);
            this.txtNotes.MaxLength = 300;
            this.txtNotes.Name = "txtNotes";
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Text = "طباعة إيصال القبض بعد الحفظ";
            this.chkPrint.Location = new System.Drawing.Point(186, 384);
            this.chkPrint.Name = "chkPrint";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
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
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "حفظ الدفعة";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 12);
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
            this.lblHeader.Size = new System.Drawing.Size(620, 48);
            this.lblHeader.Text = "تسجيل دفعة";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // PaymentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(620, 492);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تسجيل دفعة";
            this.Controls.Add(this.lblContract);
            this.Controls.Add(this.cmbContract);
            this.Controls.Add(this.lblInstallment);
            this.Controls.Add(this.cmbInstallment);
            this.Controls.Add(this.lblCapRemaining);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "PaymentDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.ComboBox cmbContract;
        private System.Windows.Forms.Label lblInstallment;
        private System.Windows.Forms.ComboBox cmbInstallment;
        private System.Windows.Forms.Label lblCapRemaining;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
