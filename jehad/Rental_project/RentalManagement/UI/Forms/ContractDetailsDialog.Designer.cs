namespace RentalManagement.Forms
{
    partial class ContractDetailsDialog
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
            this.lblTotals = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnStatement = new System.Windows.Forms.Button();
            this.btnPrintContract = new System.Windows.Forms.Button();
            this.btnPrintSchedule = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = false;
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.Location = new System.Drawing.Point(16, 56);
            this.lblInfo.Size = new System.Drawing.Size(928, 30);
            this.lblInfo.Font = new System.Drawing.Font("Tajawal", 11F, System.Drawing.FontStyle.Bold);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblInfo.Text = "—";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.Name = "lblInfo";
            // 
            // lblTotals
            // 
            this.lblTotals.AutoSize = false;
            this.lblTotals.AutoEllipsis = true;
            this.lblTotals.Location = new System.Drawing.Point(16, 86);
            this.lblTotals.Size = new System.Drawing.Size(928, 28);
            this.lblTotals.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotals.Text = "—";
            this.lblTotals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotals.Name = "lblTotals";
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(16, 120);
            this.grid.Size = new System.Drawing.Size(928, 424);
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Name = "grid";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnPay);
            this.pnlButtons.Controls.Add(this.btnStatement);
            this.pnlButtons.Controls.Add(this.btnPrintContract);
            this.pnlButtons.Controls.Add(this.btnPrintSchedule);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(960, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(16, 12);
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(62, 125, 58);
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Size = new System.Drawing.Size(150, 36);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPay.Text = "💵 تسجيل دفعة";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Name = "btnPay";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnStatement
            // 
            this.btnStatement.Location = new System.Drawing.Point(176, 12);
            this.btnStatement.BackColor = System.Drawing.Color.FromArgb(201, 149, 43);
            this.btnStatement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatement.FlatAppearance.BorderSize = 0;
            this.btnStatement.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatement.ForeColor = System.Drawing.Color.White;
            this.btnStatement.Size = new System.Drawing.Size(190, 36);
            this.btnStatement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatement.Text = "📑 كشف حساب المستأجر";
            this.btnStatement.UseVisualStyleBackColor = false;
            this.btnStatement.Name = "btnStatement";
            this.btnStatement.Click += new System.EventHandler(this.btnStatement_Click);
            // 
            // btnPrintContract
            // 
            this.btnPrintContract.Location = new System.Drawing.Point(376, 12);
            this.btnPrintContract.BackColor = System.Drawing.Color.FromArgb(156, 107, 48);
            this.btnPrintContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintContract.FlatAppearance.BorderSize = 0;
            this.btnPrintContract.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintContract.ForeColor = System.Drawing.Color.White;
            this.btnPrintContract.Size = new System.Drawing.Size(150, 36);
            this.btnPrintContract.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintContract.Text = "🖨 نموذج العقد";
            this.btnPrintContract.UseVisualStyleBackColor = false;
            this.btnPrintContract.Name = "btnPrintContract";
            this.btnPrintContract.Click += new System.EventHandler(this.btnPrintContract_Click);
            // 
            // btnPrintSchedule
            // 
            this.btnPrintSchedule.Location = new System.Drawing.Point(536, 12);
            this.btnPrintSchedule.BackColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.btnPrintSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintSchedule.FlatAppearance.BorderSize = 0;
            this.btnPrintSchedule.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintSchedule.ForeColor = System.Drawing.Color.White;
            this.btnPrintSchedule.Size = new System.Drawing.Size(150, 36);
            this.btnPrintSchedule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintSchedule.Text = "🖨 طباعة الجدول";
            this.btnPrintSchedule.UseVisualStyleBackColor = false;
            this.btnPrintSchedule.Name = "btnPrintSchedule";
            this.btnPrintSchedule.Click += new System.EventHandler(this.btnPrintSchedule_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(696, 12);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(960, 48);
            this.lblHeader.Text = "أقساط العقد";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // ContractDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "أقساط العقد";
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTotals);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "ContractDetailsDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTotals;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnStatement;
        private System.Windows.Forms.Button btnPrintContract;
        private System.Windows.Forms.Button btnPrintSchedule;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;
    }
}
