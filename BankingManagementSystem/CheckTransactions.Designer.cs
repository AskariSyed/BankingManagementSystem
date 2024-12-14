namespace BankingManagementSystem
{
    partial class CheckTransactions
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
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionPerformed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn_UpdatePersonalINfor_Form = new System.Windows.Forms.Button();
            this.TransactionDataGridTable = new System.Windows.Forms.DataGridView();
            this.ReferenceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTipForFullName = new System.Windows.Forms.ToolTip(this.components);
            this.AccountSummary_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.AttributeTxtBox = new System.Windows.Forms.TextBox();
            this.SearchByReferenceId_btn = new System.Windows.Forms.Button();
            this.SearchByTransaction_btn = new System.Windows.Forms.Button();
            this.SearchByAccountNo_BTN = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDataGridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // BranchID
            // 
            this.BranchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BranchID.HeaderText = "BranchID";
            this.BranchID.MinimumWidth = 6;
            this.BranchID.Name = "BranchID";
            this.BranchID.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // ActionDate
            // 
            this.ActionDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionDate.DividerWidth = 2;
            this.ActionDate.HeaderText = "Transaction Date ";
            this.ActionDate.MinimumWidth = 6;
            this.ActionDate.Name = "ActionDate";
            this.ActionDate.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // TransactionType
            // 
            this.TransactionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TransactionType.HeaderText = "Transaction Type";
            this.TransactionType.MinimumWidth = 6;
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.ReadOnly = true;
            // 
            // ActionPerformed
            // 
            this.ActionPerformed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionPerformed.DividerWidth = 2;
            this.ActionPerformed.HeaderText = "Account Number";
            this.ActionPerformed.MinimumWidth = 6;
            this.ActionPerformed.Name = "ActionPerformed";
            this.ActionPerformed.ReadOnly = true;
            // 
            // AuditLogID
            // 
            this.AuditLogID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuditLogID.DividerWidth = 2;
            this.AuditLogID.HeaderText = "Transaction ID";
            this.AuditLogID.MinimumWidth = 6;
            this.AuditLogID.Name = "AuditLogID";
            this.AuditLogID.ReadOnly = true;
            // 
            // Exit_btn_UpdatePersonalINfor_Form
            // 
            this.Exit_btn_UpdatePersonalINfor_Form.AccessibleName = "Exit_btn_btn_HomeFormUser";
            this.Exit_btn_UpdatePersonalINfor_Form.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn_UpdatePersonalINfor_Form.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_btn_UpdatePersonalINfor_Form.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_btn_UpdatePersonalINfor_Form.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn_UpdatePersonalINfor_Form.Location = new System.Drawing.Point(1006, 28);
            this.Exit_btn_UpdatePersonalINfor_Form.Name = "Exit_btn_UpdatePersonalINfor_Form";
            this.Exit_btn_UpdatePersonalINfor_Form.Size = new System.Drawing.Size(31, 33);
            this.Exit_btn_UpdatePersonalINfor_Form.TabIndex = 171;
            this.Exit_btn_UpdatePersonalINfor_Form.Text = "X";
            this.Exit_btn_UpdatePersonalINfor_Form.UseVisualStyleBackColor = false;
            this.Exit_btn_UpdatePersonalINfor_Form.Click += new System.EventHandler(this.Exit_btn_UpdatePersonalINfor_Form_Click);
            // 
            // TransactionDataGridTable
            // 
            this.TransactionDataGridTable.AllowUserToAddRows = false;
            this.TransactionDataGridTable.AllowUserToDeleteRows = false;
            this.TransactionDataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionDataGridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuditLogID,
            this.ActionPerformed,
            this.TransactionType,
            this.Amount,
            this.ActionDate,
            this.Description,
            this.BranchID,
            this.ReferenceID});
            this.TransactionDataGridTable.Location = new System.Drawing.Point(11, 290);
            this.TransactionDataGridTable.Name = "TransactionDataGridTable";
            this.TransactionDataGridTable.ReadOnly = true;
            this.TransactionDataGridTable.RowHeadersWidth = 51;
            this.TransactionDataGridTable.RowTemplate.Height = 24;
            this.TransactionDataGridTable.Size = new System.Drawing.Size(1026, 384);
            this.TransactionDataGridTable.TabIndex = 172;
            // 
            // ReferenceID
            // 
            this.ReferenceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReferenceID.HeaderText = "Reference ID";
            this.ReferenceID.MinimumWidth = 6;
            this.ReferenceID.Name = "ReferenceID";
            this.ReferenceID.ReadOnly = true;
            // 
            // toolTipForFullName
            // 
            this.toolTipForFullName.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // AccountSummary_label_HOmePageUSerForm
            // 
            this.AccountSummary_label_HOmePageUSerForm.AutoSize = true;
            this.AccountSummary_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.AccountSummary_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountSummary_label_HOmePageUSerForm.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.AccountSummary_label_HOmePageUSerForm.Location = new System.Drawing.Point(52, 70);
            this.AccountSummary_label_HOmePageUSerForm.Name = "AccountSummary_label_HOmePageUSerForm";
            this.AccountSummary_label_HOmePageUSerForm.Size = new System.Drawing.Size(272, 50);
            this.AccountSummary_label_HOmePageUSerForm.TabIndex = 169;
            this.AccountSummary_label_HOmePageUSerForm.Text = "Check Transaction";
            // 
            // AttributeTxtBox
            // 
            this.AttributeTxtBox.Location = new System.Drawing.Point(265, 179);
            this.AttributeTxtBox.Name = "AttributeTxtBox";
            this.AttributeTxtBox.Size = new System.Drawing.Size(499, 22);
            this.AttributeTxtBox.TabIndex = 168;
            // 
            // SearchByReferenceId_btn
            // 
            this.SearchByReferenceId_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByReferenceId_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByReferenceId_btn.Location = new System.Drawing.Point(684, 220);
            this.SearchByReferenceId_btn.Name = "SearchByReferenceId_btn";
            this.SearchByReferenceId_btn.Size = new System.Drawing.Size(187, 28);
            this.SearchByReferenceId_btn.TabIndex = 167;
            this.SearchByReferenceId_btn.Text = "Search By Reference ID";
            this.SearchByReferenceId_btn.UseVisualStyleBackColor = false;
            this.SearchByReferenceId_btn.Click += new System.EventHandler(this.SearchByReferenceId_btn_Click);
            // 
            // SearchByTransaction_btn
            // 
            this.SearchByTransaction_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByTransaction_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByTransaction_btn.Location = new System.Drawing.Point(408, 220);
            this.SearchByTransaction_btn.Name = "SearchByTransaction_btn";
            this.SearchByTransaction_btn.Size = new System.Drawing.Size(187, 28);
            this.SearchByTransaction_btn.TabIndex = 166;
            this.SearchByTransaction_btn.Text = "Search By Transaction ID";
            this.SearchByTransaction_btn.UseVisualStyleBackColor = false;
            this.SearchByTransaction_btn.Click += new System.EventHandler(this.SearchByTransaction_btn_Click);
            // 
            // SearchByAccountNo_BTN
            // 
            this.SearchByAccountNo_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByAccountNo_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByAccountNo_BTN.Location = new System.Drawing.Point(132, 220);
            this.SearchByAccountNo_BTN.Name = "SearchByAccountNo_BTN";
            this.SearchByAccountNo_BTN.Size = new System.Drawing.Size(187, 28);
            this.SearchByAccountNo_BTN.TabIndex = 165;
            this.SearchByAccountNo_BTN.Text = "Search By Account No";
            this.SearchByAccountNo_BTN.UseVisualStyleBackColor = false;
            this.SearchByAccountNo_BTN.Click += new System.EventHandler(this.SearchByAccountNo_BTN_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankingManagementSystem.Properties.Resources.New_Logo_1;
            this.pictureBox2.Location = new System.Drawing.Point(12, 319);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1025, 315);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 170;
            this.pictureBox2.TabStop = false;
            // 
            // CheckTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 752);
            this.Controls.Add(this.Exit_btn_UpdatePersonalINfor_Form);
            this.Controls.Add(this.TransactionDataGridTable);
            this.Controls.Add(this.AccountSummary_label_HOmePageUSerForm);
            this.Controls.Add(this.AttributeTxtBox);
            this.Controls.Add(this.SearchByReferenceId_btn);
            this.Controls.Add(this.SearchByTransaction_btn);
            this.Controls.Add(this.SearchByAccountNo_BTN);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckTransactions";
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDataGridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn BranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionPerformed;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditLogID;
        private System.Windows.Forms.Button Exit_btn_UpdatePersonalINfor_Form;
        private System.Windows.Forms.DataGridView TransactionDataGridTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceID;
        private System.Windows.Forms.ToolTip toolTipForFullName;
        private System.Windows.Forms.Label AccountSummary_label_HOmePageUSerForm;
        private System.Windows.Forms.TextBox AttributeTxtBox;
        private System.Windows.Forms.Button SearchByReferenceId_btn;
        private System.Windows.Forms.Button SearchByTransaction_btn;
        private System.Windows.Forms.Button SearchByAccountNo_BTN;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}