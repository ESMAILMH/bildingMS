namespace RentalManagement.Forms
{
    partial class CancelPaymentDialog
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
            this.lblCapReceipt = new System.Windows.Forms.Label();
            this.lblReceipt = new System.Windows.Forms.Label();
            this.lblCapAmount = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
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
            // lblCapReceipt
            // 
            this.lblCapReceipt.AutoSize = false;
            this.lblCapReceipt.Location = new System.Drawing.Point(16, 64);
            this.lblCapReceipt.Size = new System.Drawing.Size(150, 27);
            this.lblCapReceipt.Text = "الإيصال";
            this.lblCapReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapReceipt.Name = "lblCapReceipt";
            // 
            // lblReceipt
            // 
            this.lblReceipt.AutoSize = false;
            this.lblReceipt.AutoEllipsis = true;
            this.lblReceipt.Location = new System.Drawing.Point(176, 64);
            this.lblReceipt.Size = new System.Drawing.Size(364, 27);
            this.lblReceipt.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblReceipt.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblReceipt.Text = "—";
            this.lblReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReceipt.Name = "lblReceipt";
            // 
            // lblCapAmount
            // 
            this.lblCapAmount.AutoSize = false;
            this.lblCapAmount.Location = new System.Drawing.Point(16, 104);
            this.lblCapAmount.Size = new System.Drawing.Size(150, 27);
            this.lblCapAmount.Text = "المبلغ";
            this.lblCapAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCapAmount.Name = "lblCapAmount";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = false;
            this.lblAmount.AutoEllipsis = true;
            this.lblAmount.Location = new System.Drawing.Point(176, 104);
            this.lblAmount.Size = new System.Drawing.Size(364, 27);
            this.lblAmount.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblAmount.Text = "—";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAmount.Name = "lblAmount";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = false;
            this.lblReason.Location = new System.Drawing.Point(16, 144);
            this.lblReason.Size = new System.Drawing.Size(150, 27);
            this.lblReason.Text = "سبب الإلغاء *";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReason.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblReason.Name = "lblReason";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(176, 144);
            this.txtReason.Size = new System.Drawing.Size(364, 60);
            this.txtReason.Multiline = true;
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.MaxLength = 300;
            this.txtReason.Name = "txtReason";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = false;
            this.lblNote.Location = new System.Drawing.Point(16, 217);
            this.lblNote.Size = new System.Drawing.Size(524, 44);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.lblNote.Text = "الإيصال لا يُحذف: يبقى في السجل بحالة \"ملغى\" ويعود مبلغه إلى رصيد القسط.";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNote.Name = "lblNote";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(560, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 12);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(166, 61, 47);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "إلغاء الإيصال";
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
            this.btnCancel.Text = "رجوع";
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
            this.lblHeader.Size = new System.Drawing.Size(560, 48);
            this.lblHeader.Text = "إلغاء إيصال قبض";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // CancelPaymentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(560, 335);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إلغاء إيصال قبض";
            this.Controls.Add(this.lblCapReceipt);
            this.Controls.Add(this.lblReceipt);
            this.Controls.Add(this.lblCapAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "CancelPaymentDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCapReceipt;
        private System.Windows.Forms.Label lblReceipt;
        private System.Windows.Forms.Label lblCapAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
