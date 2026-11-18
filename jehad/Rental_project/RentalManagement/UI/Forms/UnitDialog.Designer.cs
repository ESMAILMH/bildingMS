namespace RentalManagement.Forms
{
    partial class UnitDialog
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
            this.lblUnitNo = new System.Windows.Forms.Label();
            this.txtUnitNo = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.numFloor = new System.Windows.Forms.NumericUpDown();
            this.lblArea = new System.Windows.Forms.Label();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.lblRooms = new System.Windows.Forms.Label();
            this.numRooms = new System.Windows.Forms.NumericUpDown();
            this.lblRent = new System.Windows.Forms.Label();
            this.numRent = new System.Windows.Forms.NumericUpDown();
            this.chkMaintenance = new System.Windows.Forms.CheckBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProperty
            // 
            this.lblProperty.AutoSize = false;
            this.lblProperty.Location = new System.Drawing.Point(16, 64);
            this.lblProperty.Size = new System.Drawing.Size(170, 27);
            this.lblProperty.Text = "العقار *";
            this.lblProperty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProperty.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblProperty.Name = "lblProperty";
            // 
            // cmbProperty
            // 
            this.cmbProperty.Location = new System.Drawing.Point(196, 64);
            this.cmbProperty.Size = new System.Drawing.Size(324, 28);
            this.cmbProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProperty.Name = "cmbProperty";
            // 
            // lblUnitNo
            // 
            this.lblUnitNo.AutoSize = false;
            this.lblUnitNo.Location = new System.Drawing.Point(16, 104);
            this.lblUnitNo.Size = new System.Drawing.Size(170, 27);
            this.lblUnitNo.Text = "رقم الوحدة *";
            this.lblUnitNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnitNo.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnitNo.Name = "lblUnitNo";
            // 
            // txtUnitNo
            // 
            this.txtUnitNo.Location = new System.Drawing.Point(196, 104);
            this.txtUnitNo.Size = new System.Drawing.Size(324, 27);
            this.txtUnitNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnitNo.MaxLength = 20;
            this.txtUnitNo.Name = "txtUnitNo";
            // 
            // lblType
            // 
            this.lblType.AutoSize = false;
            this.lblType.Location = new System.Drawing.Point(16, 144);
            this.lblType.Size = new System.Drawing.Size(170, 27);
            this.lblType.Text = "نوع الوحدة *";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblType.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblType.Name = "lblType";
            // 
            // cmbType
            // 
            this.cmbType.Location = new System.Drawing.Point(196, 144);
            this.cmbType.Size = new System.Drawing.Size(324, 28);
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Name = "cmbType";
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = false;
            this.lblFloor.Location = new System.Drawing.Point(16, 184);
            this.lblFloor.Size = new System.Drawing.Size(170, 27);
            this.lblFloor.Text = "الطابق";
            this.lblFloor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFloor.Name = "lblFloor";
            // 
            // numFloor
            // 
            this.numFloor.Location = new System.Drawing.Point(196, 184);
            this.numFloor.Size = new System.Drawing.Size(120, 27);
            this.numFloor.DecimalPlaces = 0;
            this.numFloor.Minimum = new decimal(new int[] { -5, 0, 0, 0 });
            this.numFloor.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.numFloor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numFloor.Name = "numFloor";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = false;
            this.lblArea.Location = new System.Drawing.Point(16, 224);
            this.lblArea.Size = new System.Drawing.Size(170, 27);
            this.lblArea.Text = "المساحة (م²)";
            this.lblArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArea.Name = "lblArea";
            // 
            // numArea
            // 
            this.numArea.Location = new System.Drawing.Point(196, 224);
            this.numArea.Size = new System.Drawing.Size(160, 27);
            this.numArea.DecimalPlaces = 2;
            this.numArea.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numArea.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numArea.ThousandsSeparator = true;
            this.numArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numArea.Name = "numArea";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = false;
            this.lblRooms.Location = new System.Drawing.Point(16, 264);
            this.lblRooms.Size = new System.Drawing.Size(170, 27);
            this.lblRooms.Text = "عدد الغرف";
            this.lblRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRooms.Name = "lblRooms";
            // 
            // numRooms
            // 
            this.numRooms.Location = new System.Drawing.Point(196, 264);
            this.numRooms.Size = new System.Drawing.Size(120, 27);
            this.numRooms.DecimalPlaces = 0;
            this.numRooms.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numRooms.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRooms.Name = "numRooms";
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = false;
            this.lblRent.Location = new System.Drawing.Point(16, 304);
            this.lblRent.Size = new System.Drawing.Size(170, 27);
            this.lblRent.Text = "الإيجار الشهري المقترح *";
            this.lblRent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRent.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.lblRent.Name = "lblRent";
            // 
            // numRent
            // 
            this.numRent.Location = new System.Drawing.Point(196, 304);
            this.numRent.Size = new System.Drawing.Size(200, 27);
            this.numRent.DecimalPlaces = 3;
            this.numRent.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numRent.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numRent.ThousandsSeparator = true;
            this.numRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRent.Name = "numRent";
            // 
            // chkMaintenance
            // 
            this.chkMaintenance.AutoSize = true;
            this.chkMaintenance.Text = "الوحدة تحت الصيانة (لا تُعرض للتأجير)";
            this.chkMaintenance.Location = new System.Drawing.Point(196, 344);
            this.chkMaintenance.Name = "chkMaintenance";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = false;
            this.lblNotes.Location = new System.Drawing.Point(16, 384);
            this.lblNotes.Size = new System.Drawing.Size(170, 27);
            this.lblNotes.Text = "ملاحظات";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Name = "lblNotes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(196, 384);
            this.txtNotes.Size = new System.Drawing.Size(324, 50);
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.MaxLength = 300;
            this.txtNotes.Name = "txtNotes";
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.AutoSize = false;
            this.lblStatusInfo.Location = new System.Drawing.Point(16, 447);
            this.lblStatusInfo.Size = new System.Drawing.Size(504, 44);
            this.lblStatusInfo.ForeColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.lblStatusInfo.Text = "حالة \"مؤجرة\" يضبطها النظام تلقائياً عند إبرام العقد وإنهائه.";
            this.lblStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusInfo.Name = "lblStatusInfo";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(246, 244, 236);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(540, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 12);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(85, 107, 47);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 12);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(122, 118, 100);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Tajawal", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Text = "إلغاء";
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
            this.lblHeader.Size = new System.Drawing.Size(540, 48);
            this.lblHeader.Text = "وحدة";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // UnitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 565);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "وحدة";
            this.Controls.Add(this.lblProperty);
            this.Controls.Add(this.cmbProperty);
            this.Controls.Add(this.lblUnitNo);
            this.Controls.Add(this.txtUnitNo);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.numFloor);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.numArea);
            this.Controls.Add(this.lblRooms);
            this.Controls.Add(this.numRooms);
            this.Controls.Add(this.lblRent);
            this.Controls.Add(this.numRent);
            this.Controls.Add(this.chkMaintenance);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblStatusInfo);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Tajawal", 10F);
            this.Name = "UnitDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.numRent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.ComboBox cmbProperty;
        private System.Windows.Forms.Label lblUnitNo;
        private System.Windows.Forms.TextBox txtUnitNo;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.NumericUpDown numFloor;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.NumericUpDown numRooms;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.NumericUpDown numRent;
        private System.Windows.Forms.CheckBox chkMaintenance;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
