namespace RentalManagement.Forms
{
    partial class ContractDialog
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
            this.lblProperty = new System.Windows.Forms.Label();
            this.cmbProperty = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblTenant = new System.Windows.Forms.Label();
            this.cmbTenant = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmbDuration = new System.Windows.Forms.ComboBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblRent = new System.Windows.Forms.Label();
            this.numRent = new System.Windows.Forms.NumericUpDown();
            this.lblCycle = new System.Windows.Forms.Label();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.numDeposit = new System.Windows.Forms.NumericUpDown();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblScheduleTitle = new System.Windows.Forms.Label();
            this.gridSchedule = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewTenant = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = false;
            this.lblProperty.Location = new System.Drawing.Point(16, 64);
            this.lblProperty.Size = new System.Drawing.Size(140, 27);
            this.lblProperty.Text = "العقار";
            this.lblProperty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProperty.Name = "lblProperty";
            // 
            // cmbProperty
            // 
            this.cmbProperty.Location = new System.Drawing.Point(166, 64);
            this.cmbProperty.Size = new System.Drawing.Size(314, 28);
            this.cmbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty.Name = "cmbProperty";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = false;
            this.lblUnit.Location = new System.Drawing.Point(16, 104);
            this.lblUnit.Size = new System.Drawing.Size(140, 27);
            this.lblUnit.Text = "الوحدة الشاغرة *";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnit.Name = "lblUnit";
            // 
            // cmbUnit
            // 
            this.cmbUnit.Location = new System.Drawing.Point(166, 104);
            this.cmbUnit.Size = new System.Drawing.Size(314, 28);
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.Name = "cmbUnit";
            // 
            // lblTenant
            // 
            this.lblTenant.AutoSize = false;
            this.lblTenant.Location = new System.Drawing.Point(16, 144);
            this.lblTenant.Size = new System.Drawing.Size(140, 27);
            this.lblTenant.Text = "المستأجر *";
            this.lblTenant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTenant.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenant.Name = "lblTenant";
            // 
            // cmbTenant
            // 
            this.cmbTenant.Location = new System.Drawing.Point(166, 144);
            this.cmbTenant.Size = new System.Drawing.Size(314, 28);
            this.cmbTenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenant.Name = "cmbTenant";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = false;
            this.lblStart.Location = new System.Drawing.Point(16, 184);
            this.lblStart.Size = new System.Drawing.Size(140, 27);
            this.lblStart.Text = "تاريخ البداية *";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStart.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStart.Name = "lblStart";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(166, 184);
            this.dtpStart.Size = new System.Drawing.Size(180, 27);
            this.dtpStart.CustomFormat = "yyyy/MM/dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Name = "dtpStart";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = false;
            this.lblDuration.Location = new System.Drawing.Point(16, 224);
            this.lblDuration.Size = new System.Drawing.Size(140, 27);
            this.lblDuration.Text = "المدة";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDuration.Name = "lblDuration";
            // 
            // cmbDuration
            // 
            this.cmbDuration.Location = new System.Drawing.Point(166, 224);
            this.cmbDuration.Size = new System.Drawing.Size(314, 28);
            this.cmbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuration.Name = "cmbDuration";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = false;
            this.lblEnd.Location = new System.Drawing.Point(16, 264);
            this.lblEnd.Size = new System.Drawing.Size(140, 27);
            this.lblEnd.Text = "تاريخ النهاية *";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEnd.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblEnd.Name = "lblEnd";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(166, 264);
            this.dtpEnd.Size = new System.Drawing.Size(180, 27);
            this.dtpEnd.CustomFormat = "yyyy/MM/dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Name = "dtpEnd";
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = false;
            this.lblRent.Location = new System.Drawing.Point(16, 304);
            this.lblRent.Size = new System.Drawing.Size(140, 27);
            this.lblRent.Text = "الإيجار الشهري *";
            this.lblRent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRent.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblRent.Name = "lblRent";
            // 
            // numRent
            // 
            this.numRent.Location = new System.Drawing.Point(166, 304);
            this.numRent.Size = new System.Drawing.Size(200, 27);
            this.numRent.DecimalPlaces = 3;
            this.numRent.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numRent.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numRent.ThousandsSeparator = true;
            this.numRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRent.Name = "numRent";
            // 
            // lblCycle
            // 
            this.lblCycle.AutoSize = false;
            this.lblCycle.Location = new System.Drawing.Point(16, 344);
            this.lblCycle.Size = new System.Drawing.Size(140, 27);
            this.lblCycle.Text = "دورية الدفع *";
            this.lblCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCycle.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblCycle.Name = "lblCycle";
            // 
            // cmbCycle
            // 
            this.cmbCycle.Location = new System.Drawing.Point(166, 344);
            this.cmbCycle.Size = new System.Drawing.Size(314, 28);
            this.cmbCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycle.Name = "cmbCycle";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = false;
            this.lblDeposit.Location = new System.Drawing.Point(16, 384);
            this.lblDeposit.Size = new System.Drawing.Size(140, 27);
            this.lblDeposit.Text = "مبلغ التأمين";
            this.lblDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeposit.Name = "lblDeposit";
            // 
            // numDeposit
            // 
            this.numDeposit.Location = new System.Drawing.Point(166, 384);
            this.numDeposit.Size = new System.Drawing.Size(200, 27);
            this.numDeposit.DecimalPlaces = 3;
            this.numDeposit.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDeposit.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numDeposit.ThousandsSeparator = true;
            this.numDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDeposit.Name = "numDeposit";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = false;
            this.lblNotes.Location = new System.Drawing.Point(16, 424);
            this.lblNotes.Size = new System.Drawing.Size(140, 27);
            this.lblNotes.Text = "ملاحظات";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Name = "lblNotes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(166, 424);
            this.txtNotes.Size = new System.Drawing.Size(314, 50);
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Name = "txtNotes";
            // 
            // lblScheduleTitle
            // 
            this.lblScheduleTitle.AutoSize = false;
            this.lblScheduleTitle.AutoEllipsis = true;
            this.lblScheduleTitle.Location = new System.Drawing.Point(504, 60);
            this.lblScheduleTitle.Size = new System.Drawing.Size(480, 30);
            this.lblScheduleTitle.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblScheduleTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblScheduleTitle.Text = "📅 جدول الأقساط (معاينة قبل الحفظ)";
            this.lblScheduleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScheduleTitle.Name = "lblScheduleTitle";
            // 
            // gridSchedule
            // 
            this.gridSchedule.Location = new System.Drawing.Point(504, 94);
            this.gridSchedule.Size = new System.Drawing.Size(476, 380);
            this.gridSchedule.BackgroundColor = System.Drawing.Color.White;
            this.gridSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSchedule.Name = "gridSchedule";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = false;
            this.lblTotal.AutoEllipsis = true;
            this.lblTotal.Location = new System.Drawing.Point(504, 482);
            this.lblTotal.Size = new System.Drawing.Size(476, 30);
            this.lblTotal.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTotal.Text = "—";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotal.Name = "lblTotal";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnNewTenant);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(1000, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 12);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "حفظ العقد";
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
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnNewTenant
            // 
            this.btnNewTenant.Location = new System.Drawing.Point(296, 12);
            this.btnNewTenant.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnNewTenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewTenant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTenant.FlatAppearance.BorderSize = 0;
            this.btnNewTenant.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnNewTenant.ForeColor = System.Drawing.Color.White;
            this.btnNewTenant.Size = new System.Drawing.Size(160, 36);
            this.btnNewTenant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewTenant.Text = "➕ مستأجر جديد";
            this.btnNewTenant.UseVisualStyleBackColor = false;
            this.btnNewTenant.Name = "btnNewTenant";
            this.btnNewTenant.Click += new System.EventHandler(this.btnNewTenant_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(1000, 48);
            this.lblHeader.Text = "إبرام عقد إيجار جديد";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // ContractDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1000, 555);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إبرام عقد إيجار جديد";
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.cmbProperty);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblTenant);
            this.Controls.Add(this.cmbTenant);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.cmbDuration);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblRent);
            this.Controls.Add(this.numRent);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.cmbCycle);
            this.Controls.Add(this.lblDeposit);
            this.Controls.Add(this.numDeposit);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblScheduleTitle);
            this.Controls.Add(this.gridSchedule);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "ContractDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRent)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cmbProperty;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblTenant;
        private System.Windows.Forms.ComboBox cmbTenant;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.ComboBox cmbDuration;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.NumericUpDown numRent;
        private System.Windows.Forms.Label lblCycle;
        private System.Windows.Forms.ComboBox cmbCycle;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.NumericUpDown numDeposit;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblScheduleTitle;
        private System.Windows.Forms.DataGridView gridSchedule;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewTenant;
        private System.Windows.Forms.Label lblHeader;
    }
}
