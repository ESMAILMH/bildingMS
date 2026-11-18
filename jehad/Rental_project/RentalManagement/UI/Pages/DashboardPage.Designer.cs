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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tblBody = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.tblStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.tblChart = new System.Windows.Forms.TableLayoutPanel();
            this.lblChart = new System.Windows.Forms.Label();
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.flpQuick = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuickContract = new System.Windows.Forms.Button();
            this.btnQuickPayment = new System.Windows.Forms.Button();
            this.btnQuickTenant = new System.Windows.Forms.Button();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            this.tblBody.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.flpCards.SuspendLayout();
            this.flpQuick.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.tblBody);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlBody.Name = "pnlBody";
            // 
            // tblBody
            // 
            this.tblBody.ColumnCount = 2;
            this.tblBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBody.Controls.Add(this.pnlStatus, 0, 0);
            this.tblBody.Controls.Add(this.pnlChart, 1, 0);
            this.tblBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBody.RowCount = 1;
            this.tblBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBody.Size = new System.Drawing.Size(1060, 300);
            this.tblBody.Name = "tblBody";
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.tblStatus);
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.BackColor = System.Drawing.Color.White;
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(20, 12, 20, 16);
            this.pnlStatus.Size = new System.Drawing.Size(400, 270);
            this.pnlStatus.Name = "pnlStatus";
            // 
            // tblStatus
            // 
            this.tblStatus.AutoScroll = true;
            this.tblStatus.ColumnCount = 3;
            this.tblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStatus.Size = new System.Drawing.Size(360, 200);
            this.tblStatus.Name = "tblStatus";
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Font = new System.Drawing.Font("Tajawal", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(40, 40, 30);
            this.lblStatus.Size = new System.Drawing.Size(380, 34);
            this.lblStatus.Text = "🚪  الوحدات حسب الحالة";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Name = "lblStatus";
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.tblChart);
            this.pnlChart.Controls.Add(this.lblChart);
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Margin = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.pnlChart.Padding = new System.Windows.Forms.Padding(20, 12, 20, 16);
            this.pnlChart.Size = new System.Drawing.Size(400, 270);
            this.pnlChart.Name = "pnlChart";
            // 
            // tblChart
            // 
            this.tblChart.AutoScroll = true;
            this.tblChart.ColumnCount = 3;
            this.tblChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChart.Size = new System.Drawing.Size(360, 200);
            this.tblChart.Name = "tblChart";
            // 
            // lblChart
            // 
            this.lblChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChart.Font = new System.Drawing.Font("Tajawal", 11F, System.Drawing.FontStyle.Bold);
            this.lblChart.ForeColor = System.Drawing.Color.FromArgb(40, 40, 30);
            this.lblChart.Size = new System.Drawing.Size(380, 34);
            this.lblChart.Text = "💰  التحصيل في آخر 6 أشهر";
            this.lblChart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChart.Name = "lblChart";
            // 
            // flpCards
            // 
            this.flpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCards.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.flpCards.Size = new System.Drawing.Size(900, 250);
            this.flpCards.Name = "flpCards";
            // 
            // flpQuick
            // 
            this.flpQuick.Controls.Add(this.btnQuickContract);
            this.flpQuick.Controls.Add(this.btnQuickPayment);
            this.flpQuick.Controls.Add(this.btnQuickTenant);
            this.flpQuick.Controls.Add(this.btnQuickReports);
            this.flpQuick.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpQuick.AutoSize = true;
            this.flpQuick.Padding = new System.Windows.Forms.Padding(0, 4, 0, 6);
            this.flpQuick.Name = "flpQuick";
            // 
            // btnQuickContract
            // 
            this.btnQuickContract.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnQuickContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickContract.FlatAppearance.BorderSize = 0;
            this.btnQuickContract.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickContract.ForeColor = System.Drawing.Color.White;
            this.btnQuickContract.Size = new System.Drawing.Size(150, 36);
            this.btnQuickContract.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickContract.Text = "📝 عقد جديد";
            this.btnQuickContract.UseVisualStyleBackColor = false;
            this.btnQuickContract.Name = "btnQuickContract";
            this.btnQuickContract.Click += new System.EventHandler(this.btnQuickContract_Click);
            // 
            // btnQuickPayment
            // 
            this.btnQuickPayment.BackColor = System.Drawing.Color.FromArgb(201, 149, 43);
            this.btnQuickPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickPayment.FlatAppearance.BorderSize = 0;
            this.btnQuickPayment.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickPayment.ForeColor = System.Drawing.Color.White;
            this.btnQuickPayment.Size = new System.Drawing.Size(150, 36);
            this.btnQuickPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickPayment.Text = "💵 تسجيل دفعة";
            this.btnQuickPayment.UseVisualStyleBackColor = false;
            this.btnQuickPayment.Name = "btnQuickPayment";
            this.btnQuickPayment.Click += new System.EventHandler(this.btnQuickPayment_Click);
            // 
            // btnQuickTenant
            // 
            this.btnQuickTenant.BackColor = System.Drawing.Color.FromArgb(62, 125, 58);
            this.btnQuickTenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickTenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickTenant.FlatAppearance.BorderSize = 0;
            this.btnQuickTenant.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickTenant.ForeColor = System.Drawing.Color.White;
            this.btnQuickTenant.Size = new System.Drawing.Size(150, 36);
            this.btnQuickTenant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickTenant.Text = "👥 مستأجر جديد";
            this.btnQuickTenant.UseVisualStyleBackColor = false;
            this.btnQuickTenant.Name = "btnQuickTenant";
            this.btnQuickTenant.Click += new System.EventHandler(this.btnQuickTenant_Click);
            // 
            // btnQuickReports
            // 
            this.btnQuickReports.BackColor = System.Drawing.Color.FromArgb(70, 110, 120);
            this.btnQuickReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReports.FlatAppearance.BorderSize = 0;
            this.btnQuickReports.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickReports.ForeColor = System.Drawing.Color.White;
            this.btnQuickReports.Size = new System.Drawing.Size(150, 36);
            this.btnQuickReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickReports.Text = "📊 التقارير";
            this.btnQuickReports.UseVisualStyleBackColor = false;
            this.btnQuickReports.Name = "btnQuickReports";
            this.btnQuickReports.Click += new System.EventHandler(this.btnQuickReports_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.lblDate.Size = new System.Drawing.Size(900, 26);
            this.lblDate.Text = "التاريخ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Name = "lblDate";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tajawal", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblTitle.Size = new System.Drawing.Size(900, 44);
            this.lblTitle.Text = "مرحباً";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // DashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 14);
            this.Size = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.flpCards);
            this.Controls.Add(this.flpQuick);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "DashboardPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flpQuick.ResumeLayout(false);
            this.flpQuick.PerformLayout();
            this.flpCards.ResumeLayout(false);
            this.flpCards.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.tblBody.ResumeLayout(false);
            this.tblBody.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TableLayoutPanel tblBody;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.TableLayoutPanel tblStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.TableLayoutPanel tblChart;
        private System.Windows.Forms.Label lblChart;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.FlowLayoutPanel flpQuick;
        private System.Windows.Forms.Button btnQuickContract;
        private System.Windows.Forms.Button btnQuickPayment;
        private System.Windows.Forms.Button btnQuickTenant;
        private System.Windows.Forms.Button btnQuickReports;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
    }
}
