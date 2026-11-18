namespace RentalManagement.Pages
{
    partial class UnitsPage
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChipAll = new System.Windows.Forms.Button();
            this.btnChipVacant = new System.Windows.Forms.Button();
            this.btnChipRented = new System.Windows.Forms.Button();
            this.btnChipMaintenance = new System.Windows.Forms.Button();
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
            this.flpActions.Controls.Add(this.btnAdd);
            this.flpActions.Controls.Add(this.btnEdit);
            this.flpActions.Controls.Add(this.btnContract);
            this.flpActions.Controls.Add(this.btnPrint);
            this.flpActions.Controls.Add(this.btnExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Size = new System.Drawing.Size(150, 36);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Text = "➕ إضافة وحدة";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(70, 110, 120);
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Size = new System.Drawing.Size(130, 36);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Text = "✏ تعديل";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnContract
            // 
            this.btnContract.BackColor = System.Drawing.Color.FromArgb(62, 125, 58);
            this.btnContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContract.FlatAppearance.BorderSize = 0;
            this.btnContract.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnContract.ForeColor = System.Drawing.Color.White;
            this.btnContract.Size = new System.Drawing.Size(150, 36);
            this.btnContract.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContract.Text = "📝 إبرام عقد";
            this.btnContract.UseVisualStyleBackColor = false;
            this.btnContract.Name = "btnContract";
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
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
            this.flpStatus.Controls.Add(this.btnChipAll);
            this.flpStatus.Controls.Add(this.btnChipVacant);
            this.flpStatus.Controls.Add(this.btnChipRented);
            this.flpStatus.Controls.Add(this.btnChipMaintenance);
            this.flpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpStatus.AutoSize = true;
            this.flpStatus.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.flpStatus.Name = "flpStatus";
            // 
            // btnChipAll
            // 
            this.btnChipAll.BackColor = System.Drawing.Color.White;
            this.btnChipAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipAll.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipAll.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipAll.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipAll.Size = new System.Drawing.Size(150, 34);
            this.btnChipAll.Tag = "";
            this.btnChipAll.Text = "الكل";
            this.btnChipAll.UseVisualStyleBackColor = false;
            this.btnChipAll.Name = "btnChipAll";
            // 
            // btnChipVacant
            // 
            this.btnChipVacant.BackColor = System.Drawing.Color.White;
            this.btnChipVacant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipVacant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipVacant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipVacant.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipVacant.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipVacant.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipVacant.Size = new System.Drawing.Size(150, 34);
            this.btnChipVacant.Tag = "Vacant";
            this.btnChipVacant.Text = "شاغرة";
            this.btnChipVacant.UseVisualStyleBackColor = false;
            this.btnChipVacant.Name = "btnChipVacant";
            // 
            // btnChipRented
            // 
            this.btnChipRented.BackColor = System.Drawing.Color.White;
            this.btnChipRented.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipRented.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipRented.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipRented.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipRented.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipRented.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipRented.Size = new System.Drawing.Size(150, 34);
            this.btnChipRented.Tag = "Rented";
            this.btnChipRented.Text = "مؤجرة";
            this.btnChipRented.UseVisualStyleBackColor = false;
            this.btnChipRented.Name = "btnChipRented";
            // 
            // btnChipMaintenance
            // 
            this.btnChipMaintenance.BackColor = System.Drawing.Color.White;
            this.btnChipMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipMaintenance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipMaintenance.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipMaintenance.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnChipMaintenance.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipMaintenance.Size = new System.Drawing.Size(150, 34);
            this.btnChipMaintenance.Tag = "Maintenance";
            this.btnChipMaintenance.Text = "تحت الصيانة";
            this.btnChipMaintenance.UseVisualStyleBackColor = false;
            this.btnChipMaintenance.Name = "btnChipMaintenance";
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
            this.lblTitle.Font = new System.Drawing.Font("Tajawal", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "الوحدات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // UnitsPage
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
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "UnitsPage";
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Button btnChipAll;
        private System.Windows.Forms.Button btnChipVacant;
        private System.Windows.Forms.Button btnChipRented;
        private System.Windows.Forms.Button btnChipMaintenance;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cmbProperty;
        private System.Windows.Forms.Label lblTitle;
    }
}
