namespace BankingManagementSystem
{
    partial class CheckCustomerLogs
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
            this.BlockCustomerOnlineUserButton = new System.Windows.Forms.Button();
            this.Exit_btn_UpdatePersonalINfor_Form = new System.Windows.Forms.Button();
            this.BlockCustomerAccount_button = new System.Windows.Forms.Button();
            this.UpdateCustomerInformation_Button = new System.Windows.Forms.Button();
            this.SeeAllTransactions_button = new System.Windows.Forms.Button();
            this.AccountSummary_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.AttributeTxtBox = new System.Windows.Forms.TextBox();
            this.SearchByAccountNumber_btn = new System.Windows.Forms.Button();
            this.SearchByCNIC_btn = new System.Windows.Forms.Button();
            this.SearchByName_BTN = new System.Windows.Forms.Button();
            this.toolTipForFullName = new System.Windows.Forms.ToolTip(this.components);
            this.AuditLogDataGridTable = new System.Windows.Forms.DataGridView();
            this.AuditLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionPerformed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AuditLogDataGridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // BlockCustomerOnlineUserButton
            // 
            this.BlockCustomerOnlineUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.BlockCustomerOnlineUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BlockCustomerOnlineUserButton.Location = new System.Drawing.Point(794, 701);
            this.BlockCustomerOnlineUserButton.Name = "BlockCustomerOnlineUserButton";
            this.BlockCustomerOnlineUserButton.Size = new System.Drawing.Size(223, 28);
            this.BlockCustomerOnlineUserButton.TabIndex = 150;
            this.BlockCustomerOnlineUserButton.Text = "Unblock Customer Online User";
            this.BlockCustomerOnlineUserButton.UseVisualStyleBackColor = false;
            this.BlockCustomerOnlineUserButton.Click += new System.EventHandler(this.BlockCustomerOnlineUserButton_Click);
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
            this.Exit_btn_UpdatePersonalINfor_Form.TabIndex = 149;
            this.Exit_btn_UpdatePersonalINfor_Form.Text = "X";
            this.Exit_btn_UpdatePersonalINfor_Form.UseVisualStyleBackColor = false;
            this.Exit_btn_UpdatePersonalINfor_Form.Click += new System.EventHandler(this.Exit_btn_UpdatePersonalINfor_Form_Click);
            // 
            // BlockCustomerAccount_button
            // 
            this.BlockCustomerAccount_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.BlockCustomerAccount_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BlockCustomerAccount_button.Location = new System.Drawing.Point(541, 701);
            this.BlockCustomerAccount_button.Name = "BlockCustomerAccount_button";
            this.BlockCustomerAccount_button.Size = new System.Drawing.Size(223, 28);
            this.BlockCustomerAccount_button.TabIndex = 147;
            this.BlockCustomerAccount_button.Text = "Activate Customer Account";
            this.BlockCustomerAccount_button.UseVisualStyleBackColor = false;
            this.BlockCustomerAccount_button.Click += new System.EventHandler(this.BlockCustomerAccount_button_Click);
            // 
            // UpdateCustomerInformation_Button
            // 
            this.UpdateCustomerInformation_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.UpdateCustomerInformation_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateCustomerInformation_Button.Location = new System.Drawing.Point(288, 701);
            this.UpdateCustomerInformation_Button.Name = "UpdateCustomerInformation_Button";
            this.UpdateCustomerInformation_Button.Size = new System.Drawing.Size(223, 28);
            this.UpdateCustomerInformation_Button.TabIndex = 146;
            this.UpdateCustomerInformation_Button.Text = "Update Customer Information";
            this.UpdateCustomerInformation_Button.UseVisualStyleBackColor = false;
            this.UpdateCustomerInformation_Button.Click += new System.EventHandler(this.UpdateCustomerInformation_Button_Click);
            // 
            // SeeAllTransactions_button
            // 
            this.SeeAllTransactions_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SeeAllTransactions_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SeeAllTransactions_button.Location = new System.Drawing.Point(35, 701);
            this.SeeAllTransactions_button.Name = "SeeAllTransactions_button";
            this.SeeAllTransactions_button.Size = new System.Drawing.Size(223, 28);
            this.SeeAllTransactions_button.TabIndex = 145;
            this.SeeAllTransactions_button.Text = "See All Transactions";
            this.SeeAllTransactions_button.UseVisualStyleBackColor = false;
            this.SeeAllTransactions_button.Click += new System.EventHandler(this.SeeAllTransactions_button_Click);
            // 
            // AccountSummary_label_HOmePageUSerForm
            // 
            this.AccountSummary_label_HOmePageUSerForm.AutoSize = true;
            this.AccountSummary_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.AccountSummary_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountSummary_label_HOmePageUSerForm.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.AccountSummary_label_HOmePageUSerForm.Location = new System.Drawing.Point(52, 65);
            this.AccountSummary_label_HOmePageUSerForm.Name = "AccountSummary_label_HOmePageUSerForm";
            this.AccountSummary_label_HOmePageUSerForm.Size = new System.Drawing.Size(314, 50);
            this.AccountSummary_label_HOmePageUSerForm.TabIndex = 124;
            this.AccountSummary_label_HOmePageUSerForm.Text = "Check Customer Logs";
            this.AccountSummary_label_HOmePageUSerForm.Click += new System.EventHandler(this.AccountSummary_label_HOmePageUSerForm_Click);
            // 
            // AttributeTxtBox
            // 
            this.AttributeTxtBox.Location = new System.Drawing.Point(265, 174);
            this.AttributeTxtBox.Name = "AttributeTxtBox";
            this.AttributeTxtBox.Size = new System.Drawing.Size(499, 22);
            this.AttributeTxtBox.TabIndex = 123;
            this.AttributeTxtBox.TextChanged += new System.EventHandler(this.AttributeTxtBox_TextChanged);
            // 
            // SearchByAccountNumber_btn
            // 
            this.SearchByAccountNumber_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByAccountNumber_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByAccountNumber_btn.Location = new System.Drawing.Point(684, 215);
            this.SearchByAccountNumber_btn.Name = "SearchByAccountNumber_btn";
            this.SearchByAccountNumber_btn.Size = new System.Drawing.Size(187, 28);
            this.SearchByAccountNumber_btn.TabIndex = 122;
            this.SearchByAccountNumber_btn.Text = "Search By Account Number";
            this.SearchByAccountNumber_btn.UseVisualStyleBackColor = false;
            this.SearchByAccountNumber_btn.Click += new System.EventHandler(this.SearchByAccountNumber_btn_Click);
            this.SearchByAccountNumber_btn.MouseHover += new System.EventHandler(this.SearchByAccountNumber_btn_MouseHover);
            // 
            // SearchByCNIC_btn
            // 
            this.SearchByCNIC_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByCNIC_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByCNIC_btn.Location = new System.Drawing.Point(408, 215);
            this.SearchByCNIC_btn.Name = "SearchByCNIC_btn";
            this.SearchByCNIC_btn.Size = new System.Drawing.Size(187, 28);
            this.SearchByCNIC_btn.TabIndex = 121;
            this.SearchByCNIC_btn.Text = "Search By CNIC";
            this.SearchByCNIC_btn.UseVisualStyleBackColor = false;
            this.SearchByCNIC_btn.Click += new System.EventHandler(this.SearchByCNIC_btn_Click);
            this.SearchByCNIC_btn.MouseHover += new System.EventHandler(this.SearchByCNIC_btn_MouseHover);
            // 
            // SearchByName_BTN
            // 
            this.SearchByName_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByName_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByName_BTN.Location = new System.Drawing.Point(132, 215);
            this.SearchByName_BTN.Name = "SearchByName_BTN";
            this.SearchByName_BTN.Size = new System.Drawing.Size(187, 28);
            this.SearchByName_BTN.TabIndex = 120;
            this.SearchByName_BTN.Text = "Search By Name";
            this.SearchByName_BTN.UseVisualStyleBackColor = false;
            this.SearchByName_BTN.Click += new System.EventHandler(this.SearchByName_BTN_Click);
            this.SearchByName_BTN.MouseHover += new System.EventHandler(this.SearchByName_BTN_MouseHover);
            // 
            // toolTipForFullName
            // 
            this.toolTipForFullName.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipForFullName_Popup);
            // 
            // AuditLogDataGridTable
            // 
            this.AuditLogDataGridTable.AllowUserToAddRows = false;
            this.AuditLogDataGridTable.AllowUserToDeleteRows = false;
            this.AuditLogDataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuditLogDataGridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuditLogID,
            this.ActionPerformed,
            this.ActionDate});
            this.AuditLogDataGridTable.Location = new System.Drawing.Point(11, 285);
            this.AuditLogDataGridTable.Name = "AuditLogDataGridTable";
            this.AuditLogDataGridTable.ReadOnly = true;
            this.AuditLogDataGridTable.RowHeadersWidth = 51;
            this.AuditLogDataGridTable.RowTemplate.Height = 24;
            this.AuditLogDataGridTable.Size = new System.Drawing.Size(1026, 384);
            this.AuditLogDataGridTable.TabIndex = 151;
            this.AuditLogDataGridTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AuditLogDataGridTable_CellContentClick);
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
            this.pictureBox2.TabIndex = 148;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // CheckCustomerLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 752);
            this.Controls.Add(this.AuditLogDataGridTable);
            this.Controls.Add(this.BlockCustomerOnlineUserButton);
            this.Controls.Add(this.Exit_btn_UpdatePersonalINfor_Form);
            this.Controls.Add(this.BlockCustomerAccount_button);
            this.Controls.Add(this.UpdateCustomerInformation_Button);
            this.Controls.Add(this.SeeAllTransactions_button);
            this.Controls.Add(this.AccountSummary_label_HOmePageUSerForm);
            this.Controls.Add(this.AttributeTxtBox);
            this.Controls.Add(this.SearchByAccountNumber_btn);
            this.Controls.Add(this.SearchByCNIC_btn);
            this.Controls.Add(this.SearchByName_BTN);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckCustomerLogs";
            this.Text = "CheckCustomerLogs";
            this.Load += new System.EventHandler(this.CheckCustomerLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuditLogDataGridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BlockCustomerOnlineUserButton;
        private System.Windows.Forms.Button Exit_btn_UpdatePersonalINfor_Form;
        private System.Windows.Forms.Button BlockCustomerAccount_button;
        private System.Windows.Forms.Button UpdateCustomerInformation_Button;
        private System.Windows.Forms.Button SeeAllTransactions_button;
        private System.Windows.Forms.Label AccountSummary_label_HOmePageUSerForm;
        private System.Windows.Forms.TextBox AttributeTxtBox;
        private System.Windows.Forms.Button SearchByAccountNumber_btn;
        private System.Windows.Forms.Button SearchByCNIC_btn;
        private System.Windows.Forms.Button SearchByName_BTN;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTipForFullName;
        private System.Windows.Forms.DataGridView AuditLogDataGridTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionPerformed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionDate;
    }
}