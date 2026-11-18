namespace RentalManagement.Forms
{
    partial class MainForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSecMain = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.lblSecOps = new System.Windows.Forms.Label();
            this.btnContracts = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.lblSecData = new System.Windows.Forms.Label();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnUnits = new System.Windows.Forms.Button();
            this.btnTenants = new System.Windows.Forms.Button();
            this.lblSecAdmin = new System.Windows.Forms.Label();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flpUser = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.flpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name = "pnlContent";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.flpMenu);
            this.pnlSidebar.Controls.Add(this.lblFooter);
            this.pnlSidebar.Controls.Add(this.pnlUser);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Size = new System.Drawing.Size(240, 700);
            this.pnlSidebar.Name = "pnlSidebar";
            // 
            // flpMenu
            // 
            this.flpMenu.Controls.Add(this.lblSecMain);
            this.flpMenu.Controls.Add(this.btnDashboard);
            this.flpMenu.Controls.Add(this.btnAlerts);
            this.flpMenu.Controls.Add(this.lblSecOps);
            this.flpMenu.Controls.Add(this.btnContracts);
            this.flpMenu.Controls.Add(this.btnPayments);
            this.flpMenu.Controls.Add(this.lblSecData);
            this.flpMenu.Controls.Add(this.btnProperties);
            this.flpMenu.Controls.Add(this.btnUnits);
            this.flpMenu.Controls.Add(this.btnTenants);
            this.flpMenu.Controls.Add(this.lblSecAdmin);
            this.flpMenu.Controls.Add(this.btnReports);
            this.flpMenu.Controls.Add(this.btnUsers);
            this.flpMenu.Controls.Add(this.btnAudit);
            this.flpMenu.AutoScroll = false;
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenu.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.flpMenu.WrapContents = false;
            this.flpMenu.Name = "flpMenu";
            // 
            // lblSecMain
            // 
            this.lblSecMain.Font = new System.Drawing.Font("Tajawal", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecMain.ForeColor = System.Drawing.Color.FromArgb(176, 180, 140);
            this.lblSecMain.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblSecMain.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblSecMain.Size = new System.Drawing.Size(224, 24);
            this.lblSecMain.Text = "الرئيسية";
            this.lblSecMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecMain.Name = "lblSecMain";
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnDashboard.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(224, 38);
            this.btnDashboard.Tag = "Dashboard";
            this.btnDashboard.Text = "🏠   الشاشة الرئيسية";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnAlerts
            // 
            this.btnAlerts.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnAlerts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlerts.FlatAppearance.BorderSize = 0;
            this.btnAlerts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnAlerts.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnAlerts.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnAlerts.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnAlerts.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnAlerts.Size = new System.Drawing.Size(224, 38);
            this.btnAlerts.Tag = "Alerts";
            this.btnAlerts.Text = "⏰   التنبيهات";
            this.btnAlerts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlerts.UseVisualStyleBackColor = false;
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Click += new System.EventHandler(this.Menu_Click);
            // 
            // lblSecOps
            // 
            this.lblSecOps.Font = new System.Drawing.Font("Tajawal", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecOps.ForeColor = System.Drawing.Color.FromArgb(176, 180, 140);
            this.lblSecOps.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblSecOps.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblSecOps.Size = new System.Drawing.Size(224, 24);
            this.lblSecOps.Text = "العمليات";
            this.lblSecOps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecOps.Name = "lblSecOps";
            // 
            // btnContracts
            // 
            this.btnContracts.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnContracts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContracts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContracts.FlatAppearance.BorderSize = 0;
            this.btnContracts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnContracts.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnContracts.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnContracts.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnContracts.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnContracts.Size = new System.Drawing.Size(224, 38);
            this.btnContracts.Tag = "Contracts";
            this.btnContracts.Text = "📄   عقود الإيجار";
            this.btnContracts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContracts.UseVisualStyleBackColor = false;
            this.btnContracts.Name = "btnContracts";
            this.btnContracts.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.FlatAppearance.BorderSize = 0;
            this.btnPayments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnPayments.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnPayments.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnPayments.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnPayments.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnPayments.Size = new System.Drawing.Size(224, 38);
            this.btnPayments.Tag = "Payments";
            this.btnPayments.Text = "💵   الدفعات والإيصالات";
            this.btnPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Click += new System.EventHandler(this.Menu_Click);
            // 
            // lblSecData
            // 
            this.lblSecData.Font = new System.Drawing.Font("Tajawal", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecData.ForeColor = System.Drawing.Color.FromArgb(176, 180, 140);
            this.lblSecData.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblSecData.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblSecData.Size = new System.Drawing.Size(224, 24);
            this.lblSecData.Text = "البيانات الأساسية";
            this.lblSecData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecData.Name = "lblSecData";
            // 
            // btnProperties
            // 
            this.btnProperties.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProperties.FlatAppearance.BorderSize = 0;
            this.btnProperties.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnProperties.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnProperties.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnProperties.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnProperties.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnProperties.Size = new System.Drawing.Size(224, 38);
            this.btnProperties.Tag = "Properties";
            this.btnProperties.Text = "🏢   العقارات";
            this.btnProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProperties.UseVisualStyleBackColor = false;
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnUnits
            // 
            this.btnUnits.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnUnits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnits.FlatAppearance.BorderSize = 0;
            this.btnUnits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnUnits.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnUnits.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnUnits.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnUnits.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnUnits.Size = new System.Drawing.Size(224, 38);
            this.btnUnits.Tag = "Units";
            this.btnUnits.Text = "🚪   الوحدات";
            this.btnUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnits.UseVisualStyleBackColor = false;
            this.btnUnits.Name = "btnUnits";
            this.btnUnits.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnTenants
            // 
            this.btnTenants.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnTenants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTenants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTenants.FlatAppearance.BorderSize = 0;
            this.btnTenants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnTenants.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnTenants.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnTenants.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnTenants.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnTenants.Size = new System.Drawing.Size(224, 38);
            this.btnTenants.Tag = "Tenants";
            this.btnTenants.Text = "👥   المستأجرون";
            this.btnTenants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTenants.UseVisualStyleBackColor = false;
            this.btnTenants.Name = "btnTenants";
            this.btnTenants.Click += new System.EventHandler(this.Menu_Click);
            // 
            // lblSecAdmin
            // 
            this.lblSecAdmin.Font = new System.Drawing.Font("Tajawal", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecAdmin.ForeColor = System.Drawing.Color.FromArgb(176, 180, 140);
            this.lblSecAdmin.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblSecAdmin.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblSecAdmin.Size = new System.Drawing.Size(224, 24);
            this.lblSecAdmin.Text = "التقارير والإدارة";
            this.lblSecAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecAdmin.Name = "lblSecAdmin";
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnReports.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnReports.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnReports.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(224, 38);
            this.btnReports.Tag = "Reports";
            this.btnReports.Text = "📊   التقارير";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Name = "btnReports";
            this.btnReports.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnUsers.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnUsers.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(224, 38);
            this.btnUsers.Tag = "Users";
            this.btnUsers.Text = "🔐   المستخدمون";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.BackColor = System.Drawing.Color.FromArgb(44, 56, 30);
            this.btnAudit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudit.FlatAppearance.BorderSize = 0;
            this.btnAudit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 76, 40);
            this.btnAudit.Font = new System.Drawing.Font("Tajawal", 10.5F);
            this.btnAudit.ForeColor = System.Drawing.Color.FromArgb(226, 228, 210);
            this.btnAudit.Margin = new System.Windows.Forms.Padding(8, 1, 8, 1);
            this.btnAudit.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnAudit.Size = new System.Drawing.Size(224, 38);
            this.btnAudit.Tag = "Audit";
            this.btnAudit.Text = "📜   سجل العمليات";
            this.btnAudit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAudit.UseVisualStyleBackColor = false;
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Click += new System.EventHandler(this.Menu_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFooter.Font = new System.Drawing.Font("Tajawal", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(176, 180, 140);
            this.lblFooter.Size = new System.Drawing.Size(240, 34);
            this.lblFooter.Text = "نظام إدارة العقارات والإيجارات";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFooter.Name = "lblFooter";
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.lblAvatar);
            this.pnlUser.Controls.Add(this.lblUserName);
            this.pnlUser.Controls.Add(this.lblUserRole);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUser.Size = new System.Drawing.Size(240, 64);
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(52, 66, 36);
            this.pnlUser.Name = "pnlUser";
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblAvatar.Font = new System.Drawing.Font("Tajawal", 14F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(14, 11);
            this.lblAvatar.Size = new System.Drawing.Size(42, 42);
            this.lblAvatar.Text = "م";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAvatar.Name = "lblAvatar";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoEllipsis = true;
            this.lblUserName.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(64, 8);
            this.lblUserName.Size = new System.Drawing.Size(166, 26);
            this.lblUserName.Text = "اسم المستخدم";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserName.Name = "lblUserName";
            // 
            // lblUserRole
            // 
            this.lblUserRole.Font = new System.Drawing.Font("Tajawal", 9F);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(176, 180, 140);
            this.lblUserRole.Location = new System.Drawing.Point(64, 34);
            this.lblUserRole.Size = new System.Drawing.Size(166, 22);
            this.lblUserRole.Text = "الدور";
            this.lblUserRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserRole.Name = "lblUserRole";
            // 
            // pnlBrand
            // 
            this.pnlBrand.Controls.Add(this.lblLogo);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Size = new System.Drawing.Size(240, 56);
            this.pnlBrand.Name = "pnlBrand";
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Tajawal", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblLogo.Text = "🏢  إدارة العقارات";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogo.Name = "lblLogo";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.flpUser);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1200, 58);
            this.pnlHeader.Name = "pnlHeader";
            // 
            // flpUser
            // 
            this.flpUser.Controls.Add(this.btnLogout);
            this.flpUser.Controls.Add(this.btnChangePassword);
            this.flpUser.Controls.Add(this.btnSettings);
            this.flpUser.AutoSize = true;
            this.flpUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpUser.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpUser.Padding = new System.Windows.Forms.Padding(8, 10, 8, 0);
            this.flpUser.WrapContents = false;
            this.flpUser.Name = "flpUser";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(166, 61, 47);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Size = new System.Drawing.Size(130, 36);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Text = "تسجيل الخروج";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Size = new System.Drawing.Size(150, 36);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangePassword.Text = "تغيير كلمة المرور";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(70, 110, 120);
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Size = new System.Drawing.Size(130, 36);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSettings.Text = "⚙ الإعدادات";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPageTitle.Font = new System.Drawing.Font("Tajawal", 13F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.lblPageTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblPageTitle.Size = new System.Drawing.Size(520, 58);
            this.lblPageTitle.Text = "الشاشة الرئيسية";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPageTitle.Name = "lblPageTitle";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Text = "نظام إدارة العقارات والإيجارات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.flpUser.ResumeLayout(false);
            this.flpUser.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.flpMenu.ResumeLayout(false);
            this.flpMenu.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Label lblSecMain;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.Label lblSecOps;
        private System.Windows.Forms.Button btnContracts;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Label lblSecData;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnUnits;
        private System.Windows.Forms.Button btnTenants;
        private System.Windows.Forms.Label lblSecAdmin;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flpUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblPageTitle;
    }
}
