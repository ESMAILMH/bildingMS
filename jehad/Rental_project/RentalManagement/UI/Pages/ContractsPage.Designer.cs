namespace RentalManagement.Pages
{
    partial class ContractsPage
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnPrintContract = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChipActive = new System.Windows.Forms.Button();
            this.btnChipEnded = new System.Windows.Forms.Button();
            this.btnChipTerminated = new System.Windows.Forms.Button();
            this.btnChipAll = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblProperty = new System.Windows.Forms.Label();
            this.cmbProperty = new System.Windows.Forms.ComboBox();
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
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(222, 226, 232);
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
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblCount.Size = new System.Drawing.Size(900, 28);
            this.lblCount.Text = "";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCount.Name = "lblCount";
            // 
            // flpActions
            // 
            this.flpActions.Controls.Add(this.btnNew);
            this.flpActions.Controls.Add(this.btnDetails);
            this.flpActions.Controls.Add(this.btnPay);
            this.flpActions.Controls.Add(this.btnPrintContract);
            this.flpActions.Controls.Add(this.btnRenew);
            this.flpActions.Controls.Add(this.btnEnd);
            this.flpActions.Controls.Add(this.btnTerminate);
            this.flpActions.Controls.Add(this.btnPrint);
            this.flpActions.Controls.Add(this.btnExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Size = new System.Drawing.Size(140, 36);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNew.Text = "📝 عقد جديد";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Name = "btnNew";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Size = new System.Drawing.Size(120, 36);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDetails.Text = "📋 الأقساط";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Size = new System.Drawing.Size(140, 36);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPay.Text = "💵 تسجيل دفعة";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Name = "btnPay";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnPrintContract
            // 
            this.btnPrintContract.BackColor = System.Drawing.Color.FromArgb(111, 66, 193);
            this.btnPrintContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintContract.FlatAppearance.BorderSize = 0;
            this.btnPrintContract.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintContract.ForeColor = System.Drawing.Color.White;
            this.btnPrintContract.Size = new System.Drawing.Size(150, 36);
            this.btnPrintContract.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintContract.Text = "🖨 نموذج العقد";
            this.btnPrintContract.UseVisualStyleBackColor = false;
            this.btnPrintContract.Name = "btnPrintContract";
            this.btnPrintContract.Click += new System.EventHandler(this.btnPrintContract_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.FromArgb(214, 137, 16);
            this.btnRenew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.FlatAppearance.BorderSize = 0;
            this.btnRenew.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.Size = new System.Drawing.Size(110, 36);
            this.btnRenew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRenew.Text = "🔄 تجديد";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnEnd.ForeColor = System.Drawing.Color.White;
            this.btnEnd.Size = new System.Drawing.Size(110, 36);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnd.Text = "⏹ إنهاء";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnTerminate
            // 
            this.btnTerminate.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnTerminate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminate.FlatAppearance.BorderSize = 0;
            this.btnTerminate.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnTerminate.ForeColor = System.Drawing.Color.White;
            this.btnTerminate.Size = new System.Drawing.Size(110, 36);
            this.btnTerminate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTerminate.Text = "⛔ فسخ";
            this.btnTerminate.UseVisualStyleBackColor = false;
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
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
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
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
            this.flpStatus.Controls.Add(this.btnChipActive);
            this.flpStatus.Controls.Add(this.btnChipEnded);
            this.flpStatus.Controls.Add(this.btnChipTerminated);
            this.flpStatus.Controls.Add(this.btnChipAll);
            this.flpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpStatus.AutoSize = true;
            this.flpStatus.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.flpStatus.Name = "flpStatus";
            // 
            // btnChipActive
            // 
            this.btnChipActive.BackColor = System.Drawing.Color.White;
            this.btnChipActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipActive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipActive.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipActive.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipActive.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipActive.Size = new System.Drawing.Size(150, 34);
            this.btnChipActive.Tag = "Active";
            this.btnChipActive.Text = "نشطة";
            this.btnChipActive.UseVisualStyleBackColor = false;
            this.btnChipActive.Name = "btnChipActive";
            // 
            // btnChipEnded
            // 
            this.btnChipEnded.BackColor = System.Drawing.Color.White;
            this.btnChipEnded.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipEnded.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipEnded.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipEnded.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipEnded.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipEnded.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipEnded.Size = new System.Drawing.Size(150, 34);
            this.btnChipEnded.Tag = "Ended";
            this.btnChipEnded.Text = "منتهية";
            this.btnChipEnded.UseVisualStyleBackColor = false;
            this.btnChipEnded.Name = "btnChipEnded";
            // 
            // btnChipTerminated
            // 
            this.btnChipTerminated.BackColor = System.Drawing.Color.White;
            this.btnChipTerminated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipTerminated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipTerminated.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipTerminated.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipTerminated.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipTerminated.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipTerminated.Size = new System.Drawing.Size(150, 34);
            this.btnChipTerminated.Tag = "Terminated";
            this.btnChipTerminated.Text = "مفسوخة";
            this.btnChipTerminated.UseVisualStyleBackColor = false;
            this.btnChipTerminated.Name = "btnChipTerminated";
            // 
            // btnChipAll
            // 
            this.btnChipAll.BackColor = System.Drawing.Color.White;
            this.btnChipAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipAll.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipAll.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipAll.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipAll.Size = new System.Drawing.Size(150, 34);
            this.btnChipAll.Tag = "";
            this.btnChipAll.Text = "الكل";
            this.btnChipAll.UseVisualStyleBackColor = false;
            this.btnChipAll.Name = "btnChipAll";
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblSearch);
            this.flpFilters.Controls.Add(this.txtSearch);
            this.flpFilters.Controls.Add(this.lblProperty);
            this.flpFilters.Controls.Add(this.cmbProperty);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.AutoSize = true;
            this.flpFilters.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.flpFilters.Name = "flpFilters";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblSearch.Text = "بحث:";
            this.lblSearch.Name = "lblSearch";
            // 
            // txtSearch
            // 
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.txtSearch.Size = new System.Drawing.Size(260, 27);
            this.txtSearch.Name = "txtSearch";
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
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "عقود الإيجار";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // ContractsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpStatus);
            this.Controls.Add(this.flpFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "ContractsPage";
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
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnPrintContract;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Button btnChipActive;
        private System.Windows.Forms.Button btnChipEnded;
        private System.Windows.Forms.Button btnChipTerminated;
        private System.Windows.Forms.Button btnChipAll;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cmbProperty;
        private System.Windows.Forms.Label lblTitle;
    }
}
