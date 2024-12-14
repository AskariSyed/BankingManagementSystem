namespace BankingManagementSystem
{
    partial class CheckEmployeeLogs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            this.Exit_btn_UpdatePersonalINfor_Form = new System.Windows.Forms.Button();
            this.AccountSummary_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.AttributeTxtBox = new System.Windows.Forms.TextBox();
            this.SearchByEmployeeNumber_btn = new System.Windows.Forms.Button();
            this.SearchByCNIC_btn = new System.Windows.Forms.Button();
            this.SearchByFirstName_BTN = new System.Windows.Forms.Button();
            this.toolTipForFullName = new System.Windows.Forms.ToolTip(this.components);
            this.EmployeeLogsDataGridTable = new System.Windows.Forms.DataGridView();
            this.AuditLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionPerformed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeLogsDataGridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit_btn_UpdatePersonalINfor_Form
            // 
            this.Exit_btn_UpdatePersonalINfor_Form.AccessibleName = "Exit_btn_btn_HomeFormUser";
            this.Exit_btn_UpdatePersonalINfor_Form.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn_UpdatePersonalINfor_Form.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_btn_UpdatePersonalINfor_Form.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_btn_UpdatePersonalINfor_Form.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn_UpdatePersonalINfor_Form.Location = new System.Drawing.Point(1006, 23);
            this.Exit_btn_UpdatePersonalINfor_Form.Name = "Exit_btn_UpdatePersonalINfor_Form";
            this.Exit_btn_UpdatePersonalINfor_Form.Size = new System.Drawing.Size(31, 33);
            this.Exit_btn_UpdatePersonalINfor_Form.TabIndex = 161;
            this.Exit_btn_UpdatePersonalINfor_Form.Text = "X";
            this.Exit_btn_UpdatePersonalINfor_Form.UseVisualStyleBackColor = false;
            this.Exit_btn_UpdatePersonalINfor_Form.Click += new System.EventHandler(this.Exit_btn_UpdatePersonalINfor_Form_Click);
            // 
            // AccountSummary_label_HOmePageUSerForm
            // 
            this.AccountSummary_label_HOmePageUSerForm.AutoSize = true;
            this.AccountSummary_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.AccountSummary_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountSummary_label_HOmePageUSerForm.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.AccountSummary_label_HOmePageUSerForm.Location = new System.Drawing.Point(52, 65);
            this.AccountSummary_label_HOmePageUSerForm.Name = "AccountSummary_label_HOmePageUSerForm";
            this.AccountSummary_label_HOmePageUSerForm.Size = new System.Drawing.Size(309, 50);
            this.AccountSummary_label_HOmePageUSerForm.TabIndex = 156;
            this.AccountSummary_label_HOmePageUSerForm.Text = "Check Employee Logs";
            this.AccountSummary_label_HOmePageUSerForm.Click += new System.EventHandler(this.AccountSummary_label_HOmePageUSerForm_Click);
            // 
            // AttributeTxtBox
            // 
            this.AttributeTxtBox.Location = new System.Drawing.Point(265, 174);
            this.AttributeTxtBox.Name = "AttributeTxtBox";
            this.AttributeTxtBox.Size = new System.Drawing.Size(499, 22);
            this.AttributeTxtBox.TabIndex = 155;
            this.AttributeTxtBox.TextChanged += new System.EventHandler(this.AttributeTxtBox_TextChanged);
            // 
            // SearchByEmployeeNumber_btn
            // 
            this.SearchByEmployeeNumber_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByEmployeeNumber_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByEmployeeNumber_btn.Location = new System.Drawing.Point(684, 215);
            this.SearchByEmployeeNumber_btn.Name = "SearchByEmployeeNumber_btn";
            this.SearchByEmployeeNumber_btn.Size = new System.Drawing.Size(240, 28);
            this.SearchByEmployeeNumber_btn.TabIndex = 154;
            this.SearchByEmployeeNumber_btn.Text = "Search By Employee Number";
            this.SearchByEmployeeNumber_btn.UseVisualStyleBackColor = false;
            this.SearchByEmployeeNumber_btn.Click += new System.EventHandler(this.SearchByEmployeeNumber_btn_Click);
            // 
            // SearchByCNIC_btn
            // 
            this.SearchByCNIC_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByCNIC_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByCNIC_btn.Location = new System.Drawing.Point(408, 215);
            this.SearchByCNIC_btn.Name = "SearchByCNIC_btn";
            this.SearchByCNIC_btn.Size = new System.Drawing.Size(240, 28);
            this.SearchByCNIC_btn.TabIndex = 153;
            this.SearchByCNIC_btn.Text = "Search By CNIC";
            this.SearchByCNIC_btn.UseVisualStyleBackColor = false;
            this.SearchByCNIC_btn.Click += new System.EventHandler(this.SearchByCNIC_btn_Click);
            // 
            // SearchByFirstName_BTN
            // 
            this.SearchByFirstName_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByFirstName_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByFirstName_BTN.Location = new System.Drawing.Point(132, 215);
            this.SearchByFirstName_BTN.Name = "SearchByFirstName_BTN";
            this.SearchByFirstName_BTN.Size = new System.Drawing.Size(240, 28);
            this.SearchByFirstName_BTN.TabIndex = 152;
            this.SearchByFirstName_BTN.Text = "Search By First Name";
            this.SearchByFirstName_BTN.UseVisualStyleBackColor = false;
            this.SearchByFirstName_BTN.Click += new System.EventHandler(this.SearchByFirstName_BTN_Click);
            // 
            // toolTipForFullName
            // 
            this.toolTipForFullName.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipForFullName_Popup);
            // 
            // EmployeeLogsDataGridTable
            // 
            this.EmployeeLogsDataGridTable.AllowUserToAddRows = false;
            this.EmployeeLogsDataGridTable.AllowUserToDeleteRows = false;
            this.EmployeeLogsDataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeLogsDataGridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuditLogID,
            this.ActionPerformed,
            this.ActionDate});
            this.EmployeeLogsDataGridTable.Location = new System.Drawing.Point(11, 285);
            this.EmployeeLogsDataGridTable.Name = "EmployeeLogsDataGridTable";
            this.EmployeeLogsDataGridTable.ReadOnly = true;
            this.EmployeeLogsDataGridTable.RowHeadersWidth = 51;
            this.EmployeeLogsDataGridTable.RowTemplate.Height = 24;
            this.EmployeeLogsDataGridTable.Size = new System.Drawing.Size(1026, 384);
            this.EmployeeLogsDataGridTable.TabIndex = 163;
            this.EmployeeLogsDataGridTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeeLogsDataGridTable_CellContentClick);
            // 
            // AuditLogID
            // 
            this.AuditLogID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuditLogID.DividerWidth = 2;
            this.AuditLogID.HeaderText = "Audit Log ID";
            this.AuditLogID.MinimumWidth = 6;
            this.AuditLogID.Name = "AuditLogID";
            this.AuditLogID.ReadOnly = true;
            // 
            // ActionPerformed
            // 
            this.ActionPerformed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionPerformed.DividerWidth = 2;
            this.ActionPerformed.HeaderText = "Action Performed";
            this.ActionPerformed.MinimumWidth = 6;
            this.ActionPerformed.Name = "ActionPerformed";
            this.ActionPerformed.ReadOnly = true;
            // 
            // ActionDate
            // 
            this.ActionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionDate.DividerWidth = 2;
            this.ActionDate.HeaderText = "Action Date And Time";
            this.ActionDate.MinimumWidth = 6;
            this.ActionDate.Name = "ActionDate";
            this.ActionDate.ReadOnly = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankingManagementSystem.Properties.Resources.New_Logo_1;
            this.pictureBox2.Location = new System.Drawing.Point(12, 314);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1025, 315);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 160;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // CheckEmployeeLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 752);
            this.Controls.Add(this.Exit_btn_UpdatePersonalINfor_Form);
            this.Controls.Add(this.AccountSummary_label_HOmePageUSerForm);
            this.Controls.Add(this.AttributeTxtBox);
            this.Controls.Add(this.SearchByEmployeeNumber_btn);
            this.Controls.Add(this.SearchByCNIC_btn);
            this.Controls.Add(this.SearchByFirstName_BTN);
            this.Controls.Add(this.EmployeeLogsDataGridTable);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckEmployeeLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckEmployeeLogs";
            this.Load += new System.EventHandler(this.CheckEmployeeLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeLogsDataGridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Exit_btn_UpdatePersonalINfor_Form;
        private System.Windows.Forms.Label AccountSummary_label_HOmePageUSerForm;
        private System.Windows.Forms.TextBox AttributeTxtBox;
        private System.Windows.Forms.Button SearchByEmployeeNumber_btn;
        private System.Windows.Forms.Button SearchByCNIC_btn;
        private System.Windows.Forms.Button SearchByFirstName_BTN;
        private System.Windows.Forms.ToolTip toolTipForFullName;
        private System.Windows.Forms.DataGridView EmployeeLogsDataGridTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionPerformed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionDate;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}