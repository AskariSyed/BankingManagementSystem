namespace BankingManagementSystem
{
    partial class TransactionHistory
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
            this.ReferenceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionPerformed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn_UpdatePersonalINfor_Form = new System.Windows.Forms.Button();
            this.TransactionGridTable = new System.Windows.Forms.DataGridView();
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTipForFullName = new System.Windows.Forms.ToolTip(this.components);
            this.SearchByAccountNo_BTN = new System.Windows.Forms.Button();
            this.AccountSummary_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.AttributeTxtBox = new System.Windows.Forms.TextBox();
            this.AccountNumber_Label_checkCustomer = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionGridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ReferenceID
            // 
            this.ReferenceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReferenceID.HeaderText = "Reference ID";
            this.ReferenceID.MinimumWidth = 6;
            this.ReferenceID.Name = "ReferenceID";
            this.ReferenceID.ReadOnly = true;
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
            // TransactionGridTable
            // 
            this.TransactionGridTable.AllowUserToAddRows = false;
            this.TransactionGridTable.AllowUserToDeleteRows = false;
            this.TransactionGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionGridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuditLogID,
            this.ActionPerformed,
            this.TransactionType,
            this.Amount,
            this.ActionDate,
            this.Description,
            this.BranchID,
            this.ReferenceID});
            this.TransactionGridTable.Location = new System.Drawing.Point(12, 213);
            this.TransactionGridTable.Name = "TransactionGridTable";
            this.TransactionGridTable.ReadOnly = true;
            this.TransactionGridTable.RowHeadersWidth = 51;
            this.TransactionGridTable.RowTemplate.Height = 24;
            this.TransactionGridTable.Size = new System.Drawing.Size(1026, 457);
            this.TransactionGridTable.TabIndex = 172;
            this.TransactionGridTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransactionGridTable_CellContentClick);
            // 
            // BranchID
            // 
            this.BranchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BranchID.HeaderText = "BranchID";
            this.BranchID.MinimumWidth = 6;
            this.BranchID.Name = "BranchID";
            this.BranchID.ReadOnly = true;
            // 
            // SearchByAccountNo_BTN
            // 
            this.SearchByAccountNo_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByAccountNo_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SearchByAccountNo_BTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchByAccountNo_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByAccountNo_BTN.Location = new System.Drawing.Point(781, 166);
            this.SearchByAccountNo_BTN.Name = "SearchByAccountNo_BTN";
            this.SearchByAccountNo_BTN.Size = new System.Drawing.Size(187, 28);
            this.SearchByAccountNo_BTN.TabIndex = 165;
            this.SearchByAccountNo_BTN.Text = "Search By Account No";
            this.toolTipForFullName.SetToolTip(this.SearchByAccountNo_BTN, "Enter 10 Digit Acount Number");
            this.SearchByAccountNo_BTN.UseMnemonic = false;
            this.SearchByAccountNo_BTN.UseVisualStyleBackColor = false;
            this.SearchByAccountNo_BTN.Click += new System.EventHandler(this.SearchByAccountNo_BTN_Click);
            // 
            // AccountSummary_label_HOmePageUSerForm
            // 
            this.AccountSummary_label_HOmePageUSerForm.AutoSize = true;
            this.AccountSummary_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.AccountSummary_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountSummary_label_HOmePageUSerForm.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.AccountSummary_label_HOmePageUSerForm.Location = new System.Drawing.Point(52, 70);
            this.AccountSummary_label_HOmePageUSerForm.Name = "AccountSummary_label_HOmePageUSerForm";
            this.AccountSummary_label_HOmePageUSerForm.Size = new System.Drawing.Size(287, 50);
            this.AccountSummary_label_HOmePageUSerForm.TabIndex = 169;
            this.AccountSummary_label_HOmePageUSerForm.Text = "Transaction History";
            // 
            // AttributeTxtBox
            // 
            this.AttributeTxtBox.Location = new System.Drawing.Point(220, 169);
            this.AttributeTxtBox.Name = "AttributeTxtBox";
            this.AttributeTxtBox.Size = new System.Drawing.Size(499, 22);
            this.AttributeTxtBox.TabIndex = 168;
            this.AttributeTxtBox.TextChanged += new System.EventHandler(this.AttributeTxtBox_TextChanged);
            this.AttributeTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AttributeTxtBox_KeyDown);
            this.AttributeTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AttributeTxtBox_KeyPress);
            // 
            // AccountNumber_Label_checkCustomer
            // 
            this.AccountNumber_Label_checkCustomer.AutoSize = true;
            this.AccountNumber_Label_checkCustomer.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNumber_Label_checkCustomer.Location = new System.Drawing.Point(57, 166);
            this.AccountNumber_Label_checkCustomer.Name = "AccountNumber_Label_checkCustomer";
            this.AccountNumber_Label_checkCustomer.Size = new System.Drawing.Size(117, 24);
            this.AccountNumber_Label_checkCustomer.TabIndex = 174;
            this.AccountNumber_Label_checkCustomer.Text = "Account Number : ";
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
            // TransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 752);
            this.Controls.Add(this.AccountNumber_Label_checkCustomer);
            this.Controls.Add(this.Exit_btn_UpdatePersonalINfor_Form);
            this.Controls.Add(this.TransactionGridTable);
            this.Controls.Add(this.AccountSummary_label_HOmePageUSerForm);
            this.Controls.Add(this.AttributeTxtBox);
            this.Controls.Add(this.SearchByAccountNo_BTN);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransactionHistory";
            ((System.ComponentModel.ISupportInitialize)(this.TransactionGridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionPerformed;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditLogID;
        private System.Windows.Forms.Button Exit_btn_UpdatePersonalINfor_Form;
        private System.Windows.Forms.DataGridView TransactionGridTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchID;
        private System.Windows.Forms.ToolTip toolTipForFullName;
        private System.Windows.Forms.Label AccountSummary_label_HOmePageUSerForm;
        private System.Windows.Forms.TextBox AttributeTxtBox;
        private System.Windows.Forms.Button SearchByAccountNo_BTN;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label AccountNumber_Label_checkCustomer;
    }
}