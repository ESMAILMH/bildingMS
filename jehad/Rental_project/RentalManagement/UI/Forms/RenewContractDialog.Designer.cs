namespace RentalManagement.Forms
{
    partial class RenewContractDialog
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
            this.lblCapContract = new System.Windows.Forms.Label();
            this.lblContract = new System.Windows.Forms.Label();
            this.lblCapNewStart = new System.Windows.Forms.Label();
            this.lblNewStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblRent = new System.Windows.Forms.Label();
            this.numRent = new System.Windows.Forms.NumericUpDown();
            this.lblCycle = new System.Windows.Forms.Label();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.lblCapPreview = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCapContract
            // 
            this.lblCapContract.AutoSize = false;
            this.lblCapContract.Location = new System.Drawing.Point(16, 64);
            this.lblCapContract.Size = new System.Drawing.Size(170, 27);
            this.lblCapContract.Text = "العقد الحالي";
            this.lblCapContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapContract.Name = "lblCapContract";
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = false;
            this.lblContract.AutoEllipsis = true;
            this.lblContract.Location = new System.Drawing.Point(196, 64);
            this.lblContract.Size = new System.Drawing.Size(384, 27);
            this.lblContract.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblContract.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblContract.Text = "—";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContract.Name = "lblContract";
            // 
            // lblCapNewStart
            // 
            this.lblCapNewStart.AutoSize = false;
            this.lblCapNewStart.Location = new System.Drawing.Point(16, 104);
            this.lblCapNewStart.Size = new System.Drawing.Size(170, 27);
            this.lblCapNewStart.Text = "يبدأ العقد الجديد في";
            this.lblCapNewStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapNewStart.Name = "lblCapNewStart";
            // 
            // lblNewStart
            // 
            this.lblNewStart.AutoSize = false;
            this.lblNewStart.AutoEllipsis = true;
            this.lblNewStart.Location = new System.Drawing.Point(196, 104);
            this.lblNewStart.Size = new System.Drawing.Size(384, 27);
            this.lblNewStart.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewStart.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblNewStart.Text = "—";
            this.lblNewStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNewStart.Name = "lblNewStart";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = false;
            this.lblEnd.Location = new System.Drawing.Point(16, 144);
            this.lblEnd.Size = new System.Drawing.Size(170, 27);
            this.lblEnd.Text = "تاريخ النهاية الجديد *";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEnd.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblEnd.Name = "lblEnd";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(196, 144);
            this.dtpEnd.Size = new System.Drawing.Size(180, 27);
            this.dtpEnd.CustomFormat = "yyyy/MM/dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Name = "dtpEnd";
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = false;
            this.lblRent.Location = new System.Drawing.Point(16, 184);
            this.lblRent.Size = new System.Drawing.Size(170, 27);
            this.lblRent.Text = "الإيجار الشهري *";
            this.lblRent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRent.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblRent.Name = "lblRent";
            // 
            // numRent
            // 
            this.numRent.Location = new System.Drawing.Point(196, 184);
            this.numRent.Size = new System.Drawing.Size(200, 27);
            this.numRent.DecimalPlaces = 3;
            this.numRent.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numRent.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numRent.ThousandsSeparator = true;
            this.numRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRent.Name = "numRent";
            // 
            // lblCycle
            // 
            this.lblCycle.AutoSize = false;
            this.lblCycle.Location = new System.Drawing.Point(16, 224);
            this.lblCycle.Size = new System.Drawing.Size(170, 27);
            this.lblCycle.Text = "دورية الدفع *";
            this.lblCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCycle.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblCycle.Name = "lblCycle";
            // 
            // cmbCycle
            // 
            this.cmbCycle.Location = new System.Drawing.Point(196, 224);
            this.cmbCycle.Size = new System.Drawing.Size(384, 28);
            this.cmbCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycle.Name = "cmbCycle";
            // 
            // lblCapPreview
            // 
            this.lblCapPreview.AutoSize = false;
            this.lblCapPreview.Location = new System.Drawing.Point(16, 264);
            this.lblCapPreview.Size = new System.Drawing.Size(170, 27);
            this.lblCapPreview.Text = "الأقساط الجديدة";
            this.lblCapPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapPreview.Name = "lblCapPreview";
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = false;
            this.lblPreview.AutoEllipsis = true;
            this.lblPreview.Location = new System.Drawing.Point(196, 264);
            this.lblPreview.Size = new System.Drawing.Size(384, 27);
            this.lblPreview.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblPreview.Text = "—";
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPreview.Name = "lblPreview";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = false;
            this.lblNote.Location = new System.Drawing.Point(16, 304);
            this.lblNote.Size = new System.Drawing.Size(564, 44);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.lblNote.Text = "يُغلق العقد الحالي في تاريخ نهايته، ويُنشأ عقد جديد لنفس الوحدة والمستأجر مع جدول أقساط جديد.";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNote.Name = "lblNote";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(600, 60);
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
            this.btnSave.Text = "تجديد";
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
            this.lblHeader.Size = new System.Drawing.Size(600, 48);
            this.lblHeader.Text = "تجديد العقد";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // RenewContractDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 422);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تجديد العقد";
            this.Controls.Add(this.lblCapContract);
            this.Controls.Add(this.lblContract);
            this.Controls.Add(this.lblCapNewStart);
            this.Controls.Add(this.lblNewStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblRent);
            this.Controls.Add(this.numRent);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.cmbCycle);
            this.Controls.Add(this.lblCapPreview);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "RenewContractDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.numRent)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCapContract;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Label lblCapNewStart;
        private System.Windows.Forms.Label lblNewStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.NumericUpDown numRent;
        private System.Windows.Forms.Label lblCycle;
        private System.Windows.Forms.ComboBox cmbCycle;
        private System.Windows.Forms.Label lblCapPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
