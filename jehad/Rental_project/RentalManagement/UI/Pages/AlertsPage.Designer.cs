namespace RentalManagement.Pages
{
    partial class AlertsPage
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
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChipOverdue = new System.Windows.Forms.Button();
            this.btnChipExpiring = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProperty = new System.Windows.Forms.Label();
            this.cmbProperty = new System.Windows.Forms.ComboBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.flpStatus.SuspendLayout();
            this.flpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(221, 216, 196);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pnlGrid.Name = "pnlGrid";
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Name = "grid";
            // 
            // lblCount
            // 
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.lblCount.Size = new System.Drawing.Size(900, 28);
            this.lblCount.Text = "";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCount.Name = "lblCount";
            // 
            // flpActions
            // 
            this.flpActions.Controls.Add(this.btnPay);
            this.flpActions.Controls.Add(this.btnDetails);
            this.flpActions.Controls.Add(this.btnRenew);
            this.flpActions.Controls.Add(this.btnEnd);
            this.flpActions.Controls.Add(this.btnPrint);
            this.flpActions.Controls.Add(this.btnExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(62, 125, 58);
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Size = new System.Drawing.Size(140, 36);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPay.Text = "💵 تسجيل دفعة";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Name = "btnPay";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.FromArgb(70, 110, 120);
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Size = new System.Drawing.Size(140, 36);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDetails.Text = "📋 أقساط العقد";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.FromArgb(201, 149, 43);
            this.btnRenew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.FlatAppearance.BorderSize = 0;
            this.btnRenew.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.Size = new System.Drawing.Size(140, 36);
            this.btnRenew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRenew.Text = "🔄 تجديد العقد";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnEnd.ForeColor = System.Drawing.Color.White;
            this.btnEnd.Size = new System.Drawing.Size(140, 36);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnd.Text = "⏹ إنهاء العقد";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Size = new System.Drawing.Size(130, 36);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Text = "🖨 طباعة";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(62, 125, 58);
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Size = new System.Drawing.Size(100, 36);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // flpStatus
            // 
            this.flpStatus.Controls.Add(this.btnChipOverdue);
            this.flpStatus.Controls.Add(this.btnChipExpiring);
            this.flpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpStatus.AutoSize = true;
            this.flpStatus.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.flpStatus.Name = "flpStatus";
            // 
            // btnChipOverdue
            // 
            this.btnChipOverdue.BackColor = System.Drawing.Color.White;
            this.btnChipOverdue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipOverdue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipOverdue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipOverdue.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipOverdue.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipOverdue.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipOverdue.Size = new System.Drawing.Size(150, 34);
            this.btnChipOverdue.Tag = "overdue";
            this.btnChipOverdue.Text = "أقساط متأخرة";
            this.btnChipOverdue.UseVisualStyleBackColor = false;
            this.btnChipOverdue.Name = "btnChipOverdue";
            // 
            // btnChipExpiring
            // 
            this.btnChipExpiring.BackColor = System.Drawing.Color.White;
            this.btnChipExpiring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipExpiring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipExpiring.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipExpiring.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipExpiring.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipExpiring.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipExpiring.Size = new System.Drawing.Size(150, 34);
            this.btnChipExpiring.Tag = "expiring";
            this.btnChipExpiring.Text = "عقود تنتهي قريباً";
            this.btnChipExpiring.UseVisualStyleBackColor = false;
            this.btnChipExpiring.Name = "btnChipExpiring";
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblProperty);
            this.flpFilters.Controls.Add(this.cmbProperty);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.AutoSize = true;
            this.flpFilters.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.flpFilters.Name = "flpFilters";
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = true;
            this.lblProperty.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblProperty.Text = "العقار:";
            this.lblProperty.Name = "lblProperty";
            // 
            // cmbProperty
            // 
            this.cmbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbProperty.Size = new System.Drawing.Size(260, 28);
            this.cmbProperty.Name = "cmbProperty";
            // 
            // lblNote
            // 
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.lblNote.Size = new System.Drawing.Size(900, 26);
            this.lblNote.Text = "—";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNote.Name = "lblNote";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tajawal", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "التنبيهات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // AlertsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpStatus);
            this.Controls.Add(this.flpFilters);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "AlertsPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.flpStatus.ResumeLayout(false);
            this.flpStatus.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.flpActions.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Button btnChipOverdue;
        private System.Windows.Forms.Button btnChipExpiring;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cmbProperty;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblTitle;
    }
}
