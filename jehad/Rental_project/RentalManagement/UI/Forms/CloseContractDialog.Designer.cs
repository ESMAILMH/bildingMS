namespace RentalManagement.Forms
{
    partial class CloseContractDialog
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
            this.lblCapPeriod = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblCapBalance = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCapContract
            // 
            this.lblCapContract.AutoSize = false;
            this.lblCapContract.Location = new System.Drawing.Point(16, 64);
            this.lblCapContract.Size = new System.Drawing.Size(170, 27);
            this.lblCapContract.Text = "العقد";
            this.lblCapContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapContract.Name = "lblCapContract";
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = false;
            this.lblContract.AutoEllipsis = true;
            this.lblContract.Location = new System.Drawing.Point(196, 64);
            this.lblContract.Size = new System.Drawing.Size(384, 27);
            this.lblContract.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblContract.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblContract.Text = "—";
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblContract.Name = "lblContract";
            // 
            // lblCapPeriod
            // 
            this.lblCapPeriod.AutoSize = false;
            this.lblCapPeriod.Location = new System.Drawing.Point(16, 104);
            this.lblCapPeriod.Size = new System.Drawing.Size(170, 27);
            this.lblCapPeriod.Text = "مدة العقد";
            this.lblCapPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapPeriod.Name = "lblCapPeriod";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = false;
            this.lblPeriod.AutoEllipsis = true;
            this.lblPeriod.Location = new System.Drawing.Point(196, 104);
            this.lblPeriod.Size = new System.Drawing.Size(384, 27);
            this.lblPeriod.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblPeriod.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblPeriod.Text = "—";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPeriod.Name = "lblPeriod";
            // 
            // lblCapBalance
            // 
            this.lblCapBalance.AutoSize = false;
            this.lblCapBalance.Location = new System.Drawing.Point(16, 144);
            this.lblCapBalance.Size = new System.Drawing.Size(170, 27);
            this.lblCapBalance.Text = "المتبقي على المستأجر";
            this.lblCapBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapBalance.Name = "lblCapBalance";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = false;
            this.lblBalance.AutoEllipsis = true;
            this.lblBalance.Location = new System.Drawing.Point(196, 144);
            this.lblBalance.Size = new System.Drawing.Size(384, 27);
            this.lblBalance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblBalance.Text = "—";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBalance.Name = "lblBalance";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = false;
            this.lblDate.Location = new System.Drawing.Point(16, 184);
            this.lblDate.Size = new System.Drawing.Size(170, 27);
            this.lblDate.Text = "تاريخ الإنهاء *";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblDate.Name = "lblDate";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(196, 184);
            this.dtpDate.Size = new System.Drawing.Size(180, 27);
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Name = "dtpDate";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = false;
            this.lblReason.Location = new System.Drawing.Point(16, 224);
            this.lblReason.Size = new System.Drawing.Size(170, 27);
            this.lblReason.Text = "السبب / ملاحظات";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReason.Name = "lblReason";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(196, 224);
            this.txtReason.Size = new System.Drawing.Size(384, 60);
            this.txtReason.Multiline = true;
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.MaxLength = 300;
            this.txtReason.Name = "txtReason";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = false;
            this.lblNote.Location = new System.Drawing.Point(16, 297);
            this.lblNote.Size = new System.Drawing.Size(564, 44);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblNote.Text = "—";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNote.Name = "lblNote";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(600, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 12);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "تأكيد";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 12);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Text = "رجوع";
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
            this.lblHeader.Size = new System.Drawing.Size(600, 48);
            this.lblHeader.Text = "إنهاء العقد";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // CloseContractDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 415);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إنهاء العقد";
            this.Controls.Add(this.lblCapContract);
            this.Controls.Add(this.lblContract);
            this.Controls.Add(this.lblCapPeriod);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.lblCapBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "CloseContractDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCapContract;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Label lblCapPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblCapBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
