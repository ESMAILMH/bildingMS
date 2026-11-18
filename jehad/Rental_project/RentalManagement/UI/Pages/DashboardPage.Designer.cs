namespace RentalManagement.Pages
{
    partial class DashboardPage
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
            this.tblCharts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOccupancy = new System.Windows.Forms.Panel();
            this.lblOccTitle = new System.Windows.Forms.Label();
            this.pnlDonut = new System.Windows.Forms.Panel();
            this.pnlCollect = new System.Windows.Forms.Panel();
            this.lblCollectTitle = new System.Windows.Forms.Label();
            this.pnlColumns = new System.Windows.Forms.Panel();
            this.tblCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHero = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.flpQuick = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuickContract = new System.Windows.Forms.Button();
            this.btnQuickPayment = new System.Windows.Forms.Button();
            this.btnQuickTenant = new System.Windows.Forms.Button();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.tblCharts.SuspendLayout();
            this.pnlOccupancy.SuspendLayout();
            this.pnlCollect.SuspendLayout();
            this.tblCards.SuspendLayout();
            this.pnlHero.SuspendLayout();
            this.flpQuick.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblCharts
            // 
            this.tblCharts.ColumnCount = 2;
            this.tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tblCharts.Controls.Add(this.pnlOccupancy, 0, 0);
            this.tblCharts.Controls.Add(this.pnlCollect, 1, 0);
            this.tblCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCharts.RowCount = 1;
            this.tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCharts.Name = "tblCharts";
            // 
            // pnlOccupancy
            // 
            this.pnlOccupancy.Controls.Add(this.pnlDonut);
            this.pnlOccupancy.Controls.Add(this.lblOccTitle);
            this.pnlOccupancy.BackColor = System.Drawing.Color.White;
            this.pnlOccupancy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOccupancy.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.pnlOccupancy.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlOccupancy.Name = "pnlOccupancy";
            // 
            // lblOccTitle
            // 
            this.lblOccTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOccTitle.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            this.lblOccTitle.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblOccTitle.Size = new System.Drawing.Size(400, 34);
            this.lblOccTitle.Text = "نسبة الإشغال";
            this.lblOccTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOccTitle.Name = "lblOccTitle";
            // 
            // pnlDonut
            // 
            this.pnlDonut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDonut.Name = "pnlDonut";
            this.pnlDonut.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDonut_Paint);
            // 
            // pnlCollect
            // 
            this.pnlCollect.Controls.Add(this.pnlColumns);
            this.pnlCollect.Controls.Add(this.lblCollectTitle);
            this.pnlCollect.BackColor = System.Drawing.Color.White;
            this.pnlCollect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCollect.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.pnlCollect.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlCollect.Name = "pnlCollect";
            // 
            // lblCollectTitle
            // 
            this.lblCollectTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCollectTitle.Font = new System.Drawing.Font("Tajawal", 12F, System.Drawing.FontStyle.Bold);
            this.lblCollectTitle.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblCollectTitle.Size = new System.Drawing.Size(400, 34);
            this.lblCollectTitle.Text = "التحصيل في آخر 6 أشهر (د.ل)";
            this.lblCollectTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCollectTitle.Name = "lblCollectTitle";
            // 
            // pnlColumns
            // 
            this.pnlColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumns.Name = "pnlColumns";
            this.pnlColumns.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlColumns_Paint);
            // 
            // tblCards
            // 
            this.tblCards.ColumnCount = 4;
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblCards.RowCount = 2;
            this.tblCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCards.Size = new System.Drawing.Size(1100, 270);
            this.tblCards.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tblCards.Name = "tblCards";
            // 
            // pnlHero
            // 
            this.pnlHero.Controls.Add(this.flpQuick);
            this.pnlHero.Controls.Add(this.lblDate);
            this.pnlHero.Controls.Add(this.lblTitle);
            this.pnlHero.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.pnlHero.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHero.Padding = new System.Windows.Forms.Padding(24, 14, 24, 10);
            this.pnlHero.Size = new System.Drawing.Size(1100, 132);
            this.pnlHero.Name = "pnlHero";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tajawal", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Size = new System.Drawing.Size(1000, 38);
            this.lblTitle.Text = "مرحباً";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(232, 226, 190);
            this.lblDate.Size = new System.Drawing.Size(1000, 26);
            this.lblDate.Text = "التاريخ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Name = "lblDate";
            // 
            // flpQuick
            // 
            this.flpQuick.Controls.Add(this.btnQuickContract);
            this.flpQuick.Controls.Add(this.btnQuickPayment);
            this.flpQuick.Controls.Add(this.btnQuickTenant);
            this.flpQuick.Controls.Add(this.btnQuickReports);
            this.flpQuick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQuick.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpQuick.Name = "flpQuick";
            // 
            // btnQuickContract
            // 
            this.btnQuickContract.BackColor = System.Drawing.Color.FromArgb(201, 149, 43);
            this.btnQuickContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickContract.FlatAppearance.BorderSize = 0;
            this.btnQuickContract.Font = new System.Drawing.Font("Tajawal", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickContract.ForeColor = System.Drawing.Color.White;
            this.btnQuickContract.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnQuickContract.Size = new System.Drawing.Size(140, 38);
            this.btnQuickContract.Text = "عقد جديد";
            this.btnQuickContract.UseVisualStyleBackColor = false;
            this.btnQuickContract.Name = "btnQuickContract";
            this.btnQuickContract.Click += new System.EventHandler(this.btnQuickContract_Click);
            // 
            // btnQuickPayment
            // 
            this.btnQuickPayment.BackColor = System.Drawing.Color.FromArgb(62, 125, 58);
            this.btnQuickPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickPayment.FlatAppearance.BorderSize = 0;
            this.btnQuickPayment.Font = new System.Drawing.Font("Tajawal", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickPayment.ForeColor = System.Drawing.Color.White;
            this.btnQuickPayment.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnQuickPayment.Size = new System.Drawing.Size(140, 38);
            this.btnQuickPayment.Text = "تسجيل دفعة";
            this.btnQuickPayment.UseVisualStyleBackColor = false;
            this.btnQuickPayment.Name = "btnQuickPayment";
            this.btnQuickPayment.Click += new System.EventHandler(this.btnQuickPayment_Click);
            // 
            // btnQuickTenant
            // 
            this.btnQuickTenant.BackColor = System.Drawing.Color.FromArgb(70, 110, 120);
            this.btnQuickTenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickTenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickTenant.FlatAppearance.BorderSize = 0;
            this.btnQuickTenant.Font = new System.Drawing.Font("Tajawal", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickTenant.ForeColor = System.Drawing.Color.White;
            this.btnQuickTenant.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnQuickTenant.Size = new System.Drawing.Size(140, 38);
            this.btnQuickTenant.Text = "مستأجر جديد";
            this.btnQuickTenant.UseVisualStyleBackColor = false;
            this.btnQuickTenant.Name = "btnQuickTenant";
            this.btnQuickTenant.Click += new System.EventHandler(this.btnQuickTenant_Click);
            // 
            // btnQuickReports
            // 
            this.btnQuickReports.BackColor = System.Drawing.Color.FromArgb(156, 107, 48);
            this.btnQuickReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReports.FlatAppearance.BorderSize = 0;
            this.btnQuickReports.Font = new System.Drawing.Font("Tajawal", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickReports.ForeColor = System.Drawing.Color.White;
            this.btnQuickReports.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnQuickReports.Size = new System.Drawing.Size(140, 38);
            this.btnQuickReports.Text = "التقارير";
            this.btnQuickReports.UseVisualStyleBackColor = false;
            this.btnQuickReports.Name = "btnQuickReports";
            this.btnQuickReports.Click += new System.EventHandler(this.btnQuickReports_Click);
            // 
            // DashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.Size = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.tblCharts);
            this.Controls.Add(this.tblCards);
            this.Controls.Add(this.pnlHero);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "DashboardPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flpQuick.ResumeLayout(false);
            this.flpQuick.PerformLayout();
            this.pnlHero.ResumeLayout(false);
            this.pnlHero.PerformLayout();
            this.tblCards.ResumeLayout(false);
            this.tblCards.PerformLayout();
            this.pnlCollect.ResumeLayout(false);
            this.pnlCollect.PerformLayout();
            this.pnlOccupancy.ResumeLayout(false);
            this.pnlOccupancy.PerformLayout();
            this.tblCharts.ResumeLayout(false);
            this.tblCharts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblCharts;
        private System.Windows.Forms.Panel pnlOccupancy;
        private System.Windows.Forms.Label lblOccTitle;
        private System.Windows.Forms.Panel pnlDonut;
        private System.Windows.Forms.Panel pnlCollect;
        private System.Windows.Forms.Label lblCollectTitle;
        private System.Windows.Forms.Panel pnlColumns;
        private System.Windows.Forms.TableLayoutPanel tblCards;
        private System.Windows.Forms.Panel pnlHero;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.FlowLayoutPanel flpQuick;
        private System.Windows.Forms.Button btnQuickContract;
        private System.Windows.Forms.Button btnQuickPayment;
        private System.Windows.Forms.Button btnQuickTenant;
        private System.Windows.Forms.Button btnQuickReports;
    }
}
