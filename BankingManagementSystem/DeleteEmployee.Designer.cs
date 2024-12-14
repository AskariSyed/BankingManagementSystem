namespace BankingManagementSystem
{
    partial class DeleteEmployee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DATEOFBIRTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRANCH_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hire_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteEmployeeBtn = new System.Windows.Forms.Button();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.SearchBySalaryBTn = new System.Windows.Forms.Button();
            this.SearchByPositionButton = new System.Windows.Forms.Button();
            this.SearchbyBranchIDBtn = new System.Windows.Forms.Button();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn_UpdatePersonalINfor_Form = new System.Windows.Forms.Button();
            this.EMPLOYEE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeLogsDataGridTable = new System.Windows.Forms.DataGridView();
            this.FIRST_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTipForFullName = new System.Windows.Forms.ToolTip(this.components);
            this.AccountSummary_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.AttributeTxtBox = new System.Windows.Forms.TextBox();
            this.SearchByEmployeeNumber_btn = new System.Windows.Forms.Button();
            this.SearchByCNIC_btn = new System.Windows.Forms.Button();
            this.SearchByFirstName_BTN = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeLogsDataGridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DATEOFBIRTH
            // 
            this.DATEOFBIRTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DATEOFBIRTH.HeaderText = "Date Of Birth";
            this.DATEOFBIRTH.MinimumWidth = 6;
            this.DATEOFBIRTH.Name = "DATEOFBIRTH";
            this.DATEOFBIRTH.ReadOnly = true;
            // 
            // CNIC
            // 
            this.CNIC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CNIC.HeaderText = "CNIC";
            this.CNIC.MinimumWidth = 6;
            this.CNIC.Name = "CNIC";
            this.CNIC.ReadOnly = true;
            // 
            // BRANCH_ID
            // 
            this.BRANCH_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BRANCH_ID.HeaderText = "Branch ID";
            this.BRANCH_ID.MinimumWidth = 6;
            this.BRANCH_ID.Name = "BRANCH_ID";
            this.BRANCH_ID.ReadOnly = true;
            // 
            // Salary
            // 
            this.Salary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Salary.HeaderText = "Salary";
            this.Salary.MinimumWidth = 6;
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Position.HeaderText = "Position";
            this.Position.MinimumWidth = 6;
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // Hire_Date
            // 
            this.Hire_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Hire_Date.HeaderText = "Hire Date";
            this.Hire_Date.MinimumWidth = 6;
            this.Hire_Date.Name = "Hire_Date";
            this.Hire_Date.ReadOnly = true;
            // 
            // Phone_Number
            // 
            this.Phone_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phone_Number.HeaderText = "Phone Number";
            this.Phone_Number.MinimumWidth = 6;
            this.Phone_Number.Name = "Phone_Number";
            this.Phone_Number.ReadOnly = true;
            // 
            // DeleteEmployeeBtn
            // 
            this.DeleteEmployeeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.DeleteEmployeeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteEmployeeBtn.Location = new System.Drawing.Point(508, 759);
            this.DeleteEmployeeBtn.Name = "DeleteEmployeeBtn";
            this.DeleteEmployeeBtn.Size = new System.Drawing.Size(222, 28);
            this.DeleteEmployeeBtn.TabIndex = 193;
            this.DeleteEmployeeBtn.Text = "Delete Employee";
            this.DeleteEmployeeBtn.UseVisualStyleBackColor = false;
            this.DeleteEmployeeBtn.Click += new System.EventHandler(this.DeleteEmployeeBtn_Click);
            // 
            // positionComboBox
            // 
            this.positionComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.positionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Items.AddRange(new object[] {
            "Teller",
            "Manager",
            "Clerk",
            "Loan Officer",
            "Accountant",
            "Customer Service",
            "HR Specialist",
            "IT Support"});
            this.positionComboBox.Location = new System.Drawing.Point(681, 337);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(218, 24);
            this.positionComboBox.TabIndex = 191;
            this.positionComboBox.SelectedIndexChanged += new System.EventHandler(this.positionComboBox_SelectedIndexChanged);
            // 
            // SearchBySalaryBTn
            // 
            this.SearchBySalaryBTn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchBySalaryBTn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchBySalaryBTn.Location = new System.Drawing.Point(938, 271);
            this.SearchBySalaryBTn.Name = "SearchBySalaryBTn";
            this.SearchBySalaryBTn.Size = new System.Drawing.Size(150, 28);
            this.SearchBySalaryBTn.TabIndex = 190;
            this.SearchBySalaryBTn.Text = "Search By Salary";
            this.SearchBySalaryBTn.UseVisualStyleBackColor = false;
            this.SearchBySalaryBTn.Click += new System.EventHandler(this.SearchBySalaryBTn_Click);
            // 
            // SearchByPositionButton
            // 
            this.SearchByPositionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByPositionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByPositionButton.Location = new System.Drawing.Point(395, 335);
            this.SearchByPositionButton.Name = "SearchByPositionButton";
            this.SearchByPositionButton.Size = new System.Drawing.Size(216, 28);
            this.SearchByPositionButton.TabIndex = 189;
            this.SearchByPositionButton.Text = "Search By Position";
            this.SearchByPositionButton.UseVisualStyleBackColor = false;
            this.SearchByPositionButton.Click += new System.EventHandler(this.SearchByPositionButton_Click);
            // 
            // SearchbyBranchIDBtn
            // 
            this.SearchbyBranchIDBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchbyBranchIDBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchbyBranchIDBtn.Location = new System.Drawing.Point(759, 271);
            this.SearchbyBranchIDBtn.Name = "SearchbyBranchIDBtn";
            this.SearchbyBranchIDBtn.Size = new System.Drawing.Size(150, 28);
            this.SearchbyBranchIDBtn.TabIndex = 188;
            this.SearchbyBranchIDBtn.Text = "Search By Branch ID";
            this.SearchbyBranchIDBtn.UseVisualStyleBackColor = false;
            this.SearchbyBranchIDBtn.Click += new System.EventHandler(this.SearchbyBranchIDBtn_Click);
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // LAST_NAME
            // 
            this.LAST_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LAST_NAME.HeaderText = "Last Name";
            this.LAST_NAME.MinimumWidth = 6;
            this.LAST_NAME.Name = "LAST_NAME";
            this.LAST_NAME.ReadOnly = true;
            // 
            // Exit_btn_UpdatePersonalINfor_Form
            // 
            this.Exit_btn_UpdatePersonalINfor_Form.AccessibleName = "Exit_btn_btn_HomeFormUser";
            this.Exit_btn_UpdatePersonalINfor_Form.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn_UpdatePersonalINfor_Form.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_btn_UpdatePersonalINfor_Form.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_btn_UpdatePersonalINfor_Form.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn_UpdatePersonalINfor_Form.Location = new System.Drawing.Point(1252, 16);
            this.Exit_btn_UpdatePersonalINfor_Form.Name = "Exit_btn_UpdatePersonalINfor_Form";
            this.Exit_btn_UpdatePersonalINfor_Form.Size = new System.Drawing.Size(31, 33);
            this.Exit_btn_UpdatePersonalINfor_Form.TabIndex = 186;
            this.Exit_btn_UpdatePersonalINfor_Form.Text = "X";
            this.Exit_btn_UpdatePersonalINfor_Form.UseVisualStyleBackColor = false;
            // 
            // EMPLOYEE_ID
            // 
            this.EMPLOYEE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EMPLOYEE_ID.HeaderText = "Employee ID";
            this.EMPLOYEE_ID.MinimumWidth = 6;
            this.EMPLOYEE_ID.Name = "EMPLOYEE_ID";
            this.EMPLOYEE_ID.ReadOnly = true;
            // 
            // EmployeeLogsDataGridTable
            // 
            this.EmployeeLogsDataGridTable.AllowUserToAddRows = false;
            this.EmployeeLogsDataGridTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            this.EmployeeLogsDataGridTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeLogsDataGridTable.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.EmployeeLogsDataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeLogsDataGridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EMPLOYEE_ID,
            this.FIRST_NAME,
            this.LAST_NAME,
            this.Email,
            this.Phone_Number,
            this.Hire_Date,
            this.Position,
            this.Salary,
            this.BRANCH_ID,
            this.CNIC,
            this.DATEOFBIRTH});
            this.EmployeeLogsDataGridTable.GridColor = System.Drawing.SystemColors.InactiveBorder;
            this.EmployeeLogsDataGridTable.Location = new System.Drawing.Point(12, 369);
            this.EmployeeLogsDataGridTable.Name = "EmployeeLogsDataGridTable";
            this.EmployeeLogsDataGridTable.ReadOnly = true;
            this.EmployeeLogsDataGridTable.RowHeadersWidth = 51;
            this.EmployeeLogsDataGridTable.RowTemplate.Height = 24;
            this.EmployeeLogsDataGridTable.Size = new System.Drawing.Size(1271, 384);
            this.EmployeeLogsDataGridTable.TabIndex = 187;
            // 
            // FIRST_NAME
            // 
            this.FIRST_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FIRST_NAME.DividerWidth = 2;
            this.FIRST_NAME.HeaderText = "First Name";
            this.FIRST_NAME.MinimumWidth = 6;
            this.FIRST_NAME.Name = "FIRST_NAME";
            this.FIRST_NAME.ReadOnly = true;
            // 
            // AccountSummary_label_HOmePageUSerForm
            // 
            this.AccountSummary_label_HOmePageUSerForm.AutoSize = true;
            this.AccountSummary_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.AccountSummary_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountSummary_label_HOmePageUSerForm.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.AccountSummary_label_HOmePageUSerForm.Location = new System.Drawing.Point(52, 163);
            this.AccountSummary_label_HOmePageUSerForm.Name = "AccountSummary_label_HOmePageUSerForm";
            this.AccountSummary_label_HOmePageUSerForm.Size = new System.Drawing.Size(255, 50);
            this.AccountSummary_label_HOmePageUSerForm.TabIndex = 184;
            this.AccountSummary_label_HOmePageUSerForm.Text = "Search Employee";
            // 
            // AttributeTxtBox
            // 
            this.AttributeTxtBox.Location = new System.Drawing.Point(395, 243);
            this.AttributeTxtBox.Name = "AttributeTxtBox";
            this.AttributeTxtBox.Size = new System.Drawing.Size(504, 22);
            this.AttributeTxtBox.TabIndex = 183;
            // 
            // SearchByEmployeeNumber_btn
            // 
            this.SearchByEmployeeNumber_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByEmployeeNumber_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByEmployeeNumber_btn.Location = new System.Drawing.Point(519, 271);
            this.SearchByEmployeeNumber_btn.Name = "SearchByEmployeeNumber_btn";
            this.SearchByEmployeeNumber_btn.Size = new System.Drawing.Size(211, 28);
            this.SearchByEmployeeNumber_btn.TabIndex = 182;
            this.SearchByEmployeeNumber_btn.Text = "Search By Employee Number";
            this.SearchByEmployeeNumber_btn.UseVisualStyleBackColor = false;
            this.SearchByEmployeeNumber_btn.Click += new System.EventHandler(this.SearchByEmployeeNumber_btn_Click);
            // 
            // SearchByCNIC_btn
            // 
            this.SearchByCNIC_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByCNIC_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByCNIC_btn.Location = new System.Drawing.Point(340, 271);
            this.SearchByCNIC_btn.Name = "SearchByCNIC_btn";
            this.SearchByCNIC_btn.Size = new System.Drawing.Size(150, 28);
            this.SearchByCNIC_btn.TabIndex = 181;
            this.SearchByCNIC_btn.Text = "Search By CNIC";
            this.SearchByCNIC_btn.UseVisualStyleBackColor = false;
            this.SearchByCNIC_btn.Click += new System.EventHandler(this.SearchByCNIC_btn_Click);
            // 
            // SearchByFirstName_BTN
            // 
            this.SearchByFirstName_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchByFirstName_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchByFirstName_BTN.Location = new System.Drawing.Point(161, 271);
            this.SearchByFirstName_BTN.Name = "SearchByFirstName_BTN";
            this.SearchByFirstName_BTN.Size = new System.Drawing.Size(150, 28);
            this.SearchByFirstName_BTN.TabIndex = 180;
            this.SearchByFirstName_BTN.Text = "Search By First Name";
            this.SearchByFirstName_BTN.UseVisualStyleBackColor = false;
            this.SearchByFirstName_BTN.Click += new System.EventHandler(this.SearchByFirstName_BTN_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankingManagementSystem.Properties.Resources.New_Logo_1;
            this.pictureBox2.Location = new System.Drawing.Point(343, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(608, 315);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 185;
            this.pictureBox2.TabStop = false;
            // 
            // DeleteEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 803);
            this.Controls.Add(this.DeleteEmployeeBtn);
            this.Controls.Add(this.positionComboBox);
            this.Controls.Add(this.SearchBySalaryBTn);
            this.Controls.Add(this.SearchByPositionButton);
            this.Controls.Add(this.SearchbyBranchIDBtn);
            this.Controls.Add(this.Exit_btn_UpdatePersonalINfor_Form);
            this.Controls.Add(this.EmployeeLogsDataGridTable);
            this.Controls.Add(this.AccountSummary_label_HOmePageUSerForm);
            this.Controls.Add(this.AttributeTxtBox);
            this.Controls.Add(this.SearchByEmployeeNumber_btn);
            this.Controls.Add(this.SearchByCNIC_btn);
            this.Controls.Add(this.SearchByFirstName_BTN);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteEmployee";
            this.Text = "DeleteEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeLogsDataGridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn DATEOFBIRTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRANCH_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hire_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone_Number;
        private System.Windows.Forms.Button DeleteEmployeeBtn;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.Button SearchBySalaryBTn;
        private System.Windows.Forms.Button SearchByPositionButton;
        private System.Windows.Forms.Button SearchbyBranchIDBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_NAME;
        private System.Windows.Forms.Button Exit_btn_UpdatePersonalINfor_Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMPLOYEE_ID;
        private System.Windows.Forms.DataGridView EmployeeLogsDataGridTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIRST_NAME;
        private System.Windows.Forms.ToolTip toolTipForFullName;
        private System.Windows.Forms.Label AccountSummary_label_HOmePageUSerForm;
        private System.Windows.Forms.TextBox AttributeTxtBox;
        private System.Windows.Forms.Button SearchByEmployeeNumber_btn;
        private System.Windows.Forms.Button SearchByCNIC_btn;
        private System.Windows.Forms.Button SearchByFirstName_BTN;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}