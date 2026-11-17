namespace RentalManagement.Pages
{
    partial class ReportsPage
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblPreviewTitle = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProperty = new System.Windows.Forms.Label();
            this.cmbProperty = new System.Windows.Forms.ComboBox();
            this.lblUnitStatus = new System.Windows.Forms.Label();
            this.cmbUnitStatus = new System.Windows.Forms.ComboBox();
            this.lblContractStatus = new System.Windows.Forms.Label();
            this.cmbContractStatus = new System.Windows.Forms.ComboBox();
            this.lblTenant = new System.Windows.Forms.Label();
            this.cmbTenant = new System.Windows.Forms.ComboBox();
            this.lblContract = new System.Windows.Forms.Label();
            this.cmbContract = new System.Windows.Forms.ComboBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblDays = new System.Windows.Forms.Label();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.lstReports = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.flpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grid);
            this.pnlMain.Controls.Add(this.lblPreviewTitle);
            this.pnlMain.Controls.Add(this.flpButtons);
            this.pnlMain.Controls.Add(this.flpFilters);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlMain.Name = "pnlMain";
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Name = "grid";
            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPreviewTitle.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblPreviewTitle.Size = new System.Drawing.Size(600, 32);
            this.lblPreviewTitle.Text = "";
            this.lblPreviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnShow);
            this.flpButtons.Controls.Add(this.btnPrint);
            this.flpButtons.Controls.Add(this.btnPdf);
            this.flpButtons.Controls.Add(this.btnExcel);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpButtons.AutoSize = true;
            this.flpButtons.BackColor = System.Drawing.Color.White;
            this.flpButtons.Padding = new System.Windows.Forms.Padding(10, 4, 10, 8);
            this.flpButtons.Name = "flpButtons";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Size = new System.Drawing.Size(110, 36);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShow.Text = "👁 عرض";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Name = "btnShow";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Size = new System.Drawing.Size(110, 36);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Text = "🖨 طباعة";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPdf.ForeColor = System.Drawing.Color.White;
            this.btnPdf.Size = new System.Drawing.Size(90, 36);
            this.btnPdf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPdf.Text = "PDF";
            this.btnPdf.UseVisualStyleBackColor = false;
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Size = new System.Drawing.Size(90, 36);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblProperty);
            this.flpFilters.Controls.Add(this.cmbProperty);
            this.flpFilters.Controls.Add(this.lblUnitStatus);
            this.flpFilters.Controls.Add(this.cmbUnitStatus);
            this.flpFilters.Controls.Add(this.lblContractStatus);
            this.flpFilters.Controls.Add(this.cmbContractStatus);
            this.flpFilters.Controls.Add(this.lblTenant);
            this.flpFilters.Controls.Add(this.cmbTenant);
            this.flpFilters.Controls.Add(this.lblContract);
            this.flpFilters.Controls.Add(this.cmbContract);
            this.flpFilters.Controls.Add(this.lblPayment);
            this.flpFilters.Controls.Add(this.cmbPayment);
            this.flpFilters.Controls.Add(this.lblUser);
            this.flpFilters.Controls.Add(this.cmbUser);
            this.flpFilters.Controls.Add(this.lblFrom);
            this.flpFilters.Controls.Add(this.dtpFrom);
            this.flpFilters.Controls.Add(this.lblTo);
            this.flpFilters.Controls.Add(this.dtpTo);
            this.flpFilters.Controls.Add(this.lblDays);
            this.flpFilters.Controls.Add(this.numDays);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.AutoSize = true;
            this.flpFilters.BackColor = System.Drawing.Color.White;
            this.flpFilters.Padding = new System.Windows.Forms.Padding(10, 8, 10, 6);
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
            this.cmbProperty.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbProperty.Size = new System.Drawing.Size(150, 28);
            this.cmbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty.Name = "cmbProperty";
            // 
            // lblUnitStatus
            // 
            this.lblUnitStatus.AutoSize = true;
            this.lblUnitStatus.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblUnitStatus.Text = "حالة الوحدة:";
            this.lblUnitStatus.Name = "lblUnitStatus";
            // 
            // cmbUnitStatus
            // 
            this.cmbUnitStatus.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbUnitStatus.Size = new System.Drawing.Size(180, 28);
            this.cmbUnitStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnitStatus.Name = "cmbUnitStatus";
            // 
            // lblContractStatus
            // 
            this.lblContractStatus.AutoSize = true;
            this.lblContractStatus.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblContractStatus.Text = "حالة العقد:";
            this.lblContractStatus.Name = "lblContractStatus";
            // 
            // cmbContractStatus
            // 
            this.cmbContractStatus.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbContractStatus.Size = new System.Drawing.Size(150, 28);
            this.cmbContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractStatus.Name = "cmbContractStatus";
            // 
            // lblTenant
            // 
            this.lblTenant.AutoSize = true;
            this.lblTenant.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblTenant.Text = "المستأجر:";
            this.lblTenant.Name = "lblTenant";
            // 
            // cmbTenant
            // 
            this.cmbTenant.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbTenant.Size = new System.Drawing.Size(300, 28);
            this.cmbTenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenant.Name = "cmbTenant";
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblContract.Text = "العقد:";
            this.lblContract.Name = "lblContract";
            // 
            // cmbContract
            // 
            this.cmbContract.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbContract.Size = new System.Drawing.Size(300, 28);
            this.cmbContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContract.Name = "cmbContract";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblPayment.Text = "الإيصال:";
            this.lblPayment.Name = "lblPayment";
            // 
            // cmbPayment
            // 
            this.cmbPayment.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbPayment.Size = new System.Drawing.Size(300, 28);
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.Name = "cmbPayment";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblUser.Text = "المستخدم:";
            this.lblUser.Name = "lblUser";
            // 
            // cmbUser
            // 
            this.cmbUser.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbUser.Size = new System.Drawing.Size(150, 28);
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Name = "cmbUser";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblFrom.Text = "من:";
            this.lblFrom.Name = "lblFrom";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.dtpFrom.CustomFormat = "yyyy/MM/dd";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Size = new System.Drawing.Size(150, 27);
            this.dtpFrom.Name = "dtpFrom";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblTo.Text = "إلى:";
            this.lblTo.Name = "lblTo";
            // 
            // dtpTo
            // 
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.dtpTo.CustomFormat = "yyyy/MM/dd";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Size = new System.Drawing.Size(150, 27);
            this.dtpTo.Name = "dtpTo";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblDays.Text = "خلال (يوم):";
            this.lblDays.Name = "lblDays";
            // 
            // numDays
            // 
            this.numDays.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.numDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numDays.Size = new System.Drawing.Size(70, 27);
            this.numDays.Value = new decimal(new int[] { 30, 0, 0, 0 });
            this.numDays.Name = "numDays";
            // 
            // lstReports
            // 
            this.lstReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstReports.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstReports.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.lstReports.IntegralHeight = false;
            this.lstReports.ItemHeight = 34;
            this.lstReports.Size = new System.Drawing.Size(280, 560);
            this.lstReports.Name = "lstReports";
            this.lstReports.SelectedIndexChanged += new System.EventHandler(this.lstReports_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 44);
            this.lblTitle.Text = "التقارير";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.Size = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lstReports);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "ReportsPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.flpButtons.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cmbProperty;
        private System.Windows.Forms.Label lblUnitStatus;
        private System.Windows.Forms.ComboBox cmbUnitStatus;
        private System.Windows.Forms.Label lblContractStatus;
        private System.Windows.Forms.ComboBox cmbContractStatus;
        private System.Windows.Forms.Label lblTenant;
        private System.Windows.Forms.ComboBox cmbTenant;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.ComboBox cmbContract;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.ListBox lstReports;
        private System.Windows.Forms.Label lblTitle;
    }
}
