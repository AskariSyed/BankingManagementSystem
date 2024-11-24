using System.Windows.Forms;

namespace BankingManagementSystem
{
    partial class HomePageCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageCustomers));
            this.SideLeft_panel_HomePageForm = new System.Windows.Forms.Panel();
            this.Account_Statment_btn_HomeFormUser = new System.Windows.Forms.Button();
            this.Privacy_And_Security_btn_HomeFormUser = new System.Windows.Forms.Button();
            this.TransactionHistory_btn_HomeFormUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Logout_btn_HomeFormUser = new System.Windows.Forms.Button();
            this.TermsAndConditions_btn_HomeFormUser = new System.Windows.Forms.Button();
            this.Update_AccountInfo_HomePageUserForm = new System.Windows.Forms.Button();
            this.Exit_btn_btn_HomeFormUser = new System.Windows.Forms.Button();
            this.Greeting_Label_btn_HomeFormUser = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.AccountSummary_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.AccountNumber_Label_HomePageUSer = new System.Windows.Forms.Label();
            this.AC_NO_Detail_HomepageUSerForm = new System.Windows.Forms.Label();
            this.Available_Balance_Label_HomePageUSer = new System.Windows.Forms.Label();
            this.Available_Balance_Detail_HomepageUSerForm = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SendMoney_btn_HomepgeCustomerForm = new System.Windows.Forms.Button();
            this.Account_type_Detail_label_HomePageUserInfoForm = new System.Windows.Forms.Label();
            this.Account_type_label_HomeUSerSiginForm = new System.Windows.Forms.Label();
            this.Transacion_Options_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.AC_Title_Detail_HomepageUSerForm = new System.Windows.Forms.Label();
            this.AccountTitle_Label_HomePageUSer = new System.Windows.Forms.Label();
            this.Recent_Transaction_label_HOmePageUSerForm = new System.Windows.Forms.Label();
            this.TransactionsTable_HomePageUser = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SideLeft_panel_HomePageForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsTable_HomePageUser)).BeginInit();
            this.SuspendLayout();
            // 
            // SideLeft_panel_HomePageForm
            // 
            this.SideLeft_panel_HomePageForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SideLeft_panel_HomePageForm.Controls.Add(this.Account_Statment_btn_HomeFormUser);
            this.SideLeft_panel_HomePageForm.Controls.Add(this.Privacy_And_Security_btn_HomeFormUser);
            this.SideLeft_panel_HomePageForm.Controls.Add(this.TransactionHistory_btn_HomeFormUser);
            this.SideLeft_panel_HomePageForm.Controls.Add(this.pictureBox1);
            this.SideLeft_panel_HomePageForm.Controls.Add(this.Logout_btn_HomeFormUser);
            this.SideLeft_panel_HomePageForm.Controls.Add(this.TermsAndConditions_btn_HomeFormUser);
            this.SideLeft_panel_HomePageForm.Controls.Add(this.Update_AccountInfo_HomePageUserForm);
            this.SideLeft_panel_HomePageForm.Location = new System.Drawing.Point(0, -1);
            this.SideLeft_panel_HomePageForm.Name = "SideLeft_panel_HomePageForm";
            this.SideLeft_panel_HomePageForm.Size = new System.Drawing.Size(302, 806);
            this.SideLeft_panel_HomePageForm.TabIndex = 0;
            this.SideLeft_panel_HomePageForm.Paint += new System.Windows.Forms.PaintEventHandler(this.SideLeft_panel_HomePageForm_Paint);
            // 
            // Account_Statment_btn_HomeFormUser
            // 
            this.Account_Statment_btn_HomeFormUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.Account_Statment_btn_HomeFormUser.FlatAppearance.BorderSize = 0;
            this.Account_Statment_btn_HomeFormUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Account_Statment_btn_HomeFormUser.ForeColor = System.Drawing.Color.White;
            this.Account_Statment_btn_HomeFormUser.Location = new System.Drawing.Point(50, 442);
            this.Account_Statment_btn_HomeFormUser.Name = "Account_Statment_btn_HomeFormUser";
            this.Account_Statment_btn_HomeFormUser.Size = new System.Drawing.Size(184, 30);
            this.Account_Statment_btn_HomeFormUser.TabIndex = 9;
            this.Account_Statment_btn_HomeFormUser.Text = "Account Statement";
            this.Account_Statment_btn_HomeFormUser.UseVisualStyleBackColor = false;
            this.Account_Statment_btn_HomeFormUser.Click += new System.EventHandler(this.Account_Statment_btn_HomeFormUser_Click);
            // 
            // Privacy_And_Security_btn_HomeFormUser
            // 
            this.Privacy_And_Security_btn_HomeFormUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.Privacy_And_Security_btn_HomeFormUser.FlatAppearance.BorderSize = 0;
            this.Privacy_And_Security_btn_HomeFormUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Privacy_And_Security_btn_HomeFormUser.ForeColor = System.Drawing.Color.White;
            this.Privacy_And_Security_btn_HomeFormUser.Location = new System.Drawing.Point(50, 375);
            this.Privacy_And_Security_btn_HomeFormUser.Name = "Privacy_And_Security_btn_HomeFormUser";
            this.Privacy_And_Security_btn_HomeFormUser.Size = new System.Drawing.Size(184, 30);
            this.Privacy_And_Security_btn_HomeFormUser.TabIndex = 8;
            this.Privacy_And_Security_btn_HomeFormUser.Text = "Privacy And Security";
            this.Privacy_And_Security_btn_HomeFormUser.UseVisualStyleBackColor = false;
            this.Privacy_And_Security_btn_HomeFormUser.Click += new System.EventHandler(this.Privacy_And_Security_btn_HomeFormUser_Click);
            // 
            // TransactionHistory_btn_HomeFormUser
            // 
            this.TransactionHistory_btn_HomeFormUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.TransactionHistory_btn_HomeFormUser.FlatAppearance.BorderSize = 0;
            this.TransactionHistory_btn_HomeFormUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransactionHistory_btn_HomeFormUser.ForeColor = System.Drawing.Color.White;
            this.TransactionHistory_btn_HomeFormUser.Location = new System.Drawing.Point(50, 308);
            this.TransactionHistory_btn_HomeFormUser.Name = "TransactionHistory_btn_HomeFormUser";
            this.TransactionHistory_btn_HomeFormUser.Size = new System.Drawing.Size(184, 30);
            this.TransactionHistory_btn_HomeFormUser.TabIndex = 7;
            this.TransactionHistory_btn_HomeFormUser.Text = "Transaction History";
            this.TransactionHistory_btn_HomeFormUser.UseVisualStyleBackColor = false;
            this.TransactionHistory_btn_HomeFormUser.Click += new System.EventHandler(this.TransactionHistory_btn_HomeFormUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(17, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 197);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Logout_btn_HomeFormUser
            // 
            this.Logout_btn_HomeFormUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.Logout_btn_HomeFormUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout_btn_HomeFormUser.FlatAppearance.BorderSize = 0;
            this.Logout_btn_HomeFormUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logout_btn_HomeFormUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_btn_HomeFormUser.ForeColor = System.Drawing.Color.White;
            this.Logout_btn_HomeFormUser.Location = new System.Drawing.Point(50, 711);
            this.Logout_btn_HomeFormUser.Name = "Logout_btn_HomeFormUser";
            this.Logout_btn_HomeFormUser.Size = new System.Drawing.Size(184, 44);
            this.Logout_btn_HomeFormUser.TabIndex = 6;
            this.Logout_btn_HomeFormUser.Text = "Logout";
            this.Logout_btn_HomeFormUser.UseVisualStyleBackColor = false;
            this.Logout_btn_HomeFormUser.Click += new System.EventHandler(this.Logout_btn_HomeFormUser_Click);
            // 
            // TermsAndConditions_btn_HomeFormUser
            // 
            this.TermsAndConditions_btn_HomeFormUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.TermsAndConditions_btn_HomeFormUser.FlatAppearance.BorderSize = 0;
            this.TermsAndConditions_btn_HomeFormUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TermsAndConditions_btn_HomeFormUser.ForeColor = System.Drawing.Color.White;
            this.TermsAndConditions_btn_HomeFormUser.Location = new System.Drawing.Point(50, 509);
            this.TermsAndConditions_btn_HomeFormUser.Name = "TermsAndConditions_btn_HomeFormUser";
            this.TermsAndConditions_btn_HomeFormUser.Size = new System.Drawing.Size(184, 30);
            this.TermsAndConditions_btn_HomeFormUser.TabIndex = 5;
            this.TermsAndConditions_btn_HomeFormUser.Text = "Terms and Conditions";
            this.TermsAndConditions_btn_HomeFormUser.UseVisualStyleBackColor = false;
            this.TermsAndConditions_btn_HomeFormUser.Click += new System.EventHandler(this.TermsAndConditions_btn_HomeFormUser_Click);
            // 
            // Update_AccountInfo_HomePageUserForm
            // 
            this.Update_AccountInfo_HomePageUserForm.BackColor = System.Drawing.Color.RoyalBlue;
            this.Update_AccountInfo_HomePageUserForm.FlatAppearance.BorderSize = 0;
            this.Update_AccountInfo_HomePageUserForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_AccountInfo_HomePageUserForm.ForeColor = System.Drawing.Color.White;
            this.Update_AccountInfo_HomePageUserForm.Location = new System.Drawing.Point(50, 241);
            this.Update_AccountInfo_HomePageUserForm.Name = "Update_AccountInfo_HomePageUserForm";
            this.Update_AccountInfo_HomePageUserForm.Size = new System.Drawing.Size(184, 30);
            this.Update_AccountInfo_HomePageUserForm.TabIndex = 1;
            this.Update_AccountInfo_HomePageUserForm.Text = "Update Perosnal Info";
            this.Update_AccountInfo_HomePageUserForm.UseVisualStyleBackColor = false;
            this.Update_AccountInfo_HomePageUserForm.Click += new System.EventHandler(this.Update_AccountInfo_HomePageUserForm_Click);
            // 
            // Exit_btn_btn_HomeFormUser
            // 
            this.Exit_btn_btn_HomeFormUser.AccessibleName = "Exit_btn_btn_HomeFormUser";
            this.Exit_btn_btn_HomeFormUser.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn_btn_HomeFormUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_btn_btn_HomeFormUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_btn_btn_HomeFormUser.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn_btn_HomeFormUser.Location = new System.Drawing.Point(1183, 12);
            this.Exit_btn_btn_HomeFormUser.Name = "Exit_btn_btn_HomeFormUser";
            this.Exit_btn_btn_HomeFormUser.Size = new System.Drawing.Size(31, 33);
            this.Exit_btn_btn_HomeFormUser.TabIndex = 20;
            this.Exit_btn_btn_HomeFormUser.Text = "X";
            this.Exit_btn_btn_HomeFormUser.UseVisualStyleBackColor = false;
            this.Exit_btn_btn_HomeFormUser.Click += new System.EventHandler(this.Exit_btn_btn_HomeFormUser_Click);
            // 
            // Greeting_Label_btn_HomeFormUser
            // 
            this.Greeting_Label_btn_HomeFormUser.AutoSize = true;
            this.Greeting_Label_btn_HomeFormUser.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Greeting_Label_btn_HomeFormUser.Location = new System.Drawing.Point(336, 47);
            this.Greeting_Label_btn_HomeFormUser.Name = "Greeting_Label_btn_HomeFormUser";
            this.Greeting_Label_btn_HomeFormUser.Size = new System.Drawing.Size(181, 30);
            this.Greeting_Label_btn_HomeFormUser.TabIndex = 21;
            this.Greeting_Label_btn_HomeFormUser.Text = "Hello Hassan";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 803);
            this.splitter1.TabIndex = 22;
            this.splitter1.TabStop = false;
            // 
            // AccountSummary_label_HOmePageUSerForm
            // 
            this.AccountSummary_label_HOmePageUSerForm.AutoSize = true;
            this.AccountSummary_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.AccountSummary_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountSummary_label_HOmePageUSerForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.AccountSummary_label_HOmePageUSerForm.Location = new System.Drawing.Point(332, 95);
            this.AccountSummary_label_HOmePageUSerForm.Name = "AccountSummary_label_HOmePageUSerForm";
            this.AccountSummary_label_HOmePageUSerForm.Size = new System.Drawing.Size(273, 50);
            this.AccountSummary_label_HOmePageUSerForm.TabIndex = 28;
            this.AccountSummary_label_HOmePageUSerForm.Text = "Account Summary ";
            // 
            // AccountNumber_Label_HomePageUSer
            // 
            this.AccountNumber_Label_HomePageUSer.AutoSize = true;
            this.AccountNumber_Label_HomePageUSer.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountNumber_Label_HomePageUSer.Location = new System.Drawing.Point(337, 170);
            this.AccountNumber_Label_HomePageUSer.Name = "AccountNumber_Label_HomePageUSer";
            this.AccountNumber_Label_HomePageUSer.Size = new System.Drawing.Size(117, 24);
            this.AccountNumber_Label_HomePageUSer.TabIndex = 29;
            this.AccountNumber_Label_HomePageUSer.Text = "Account Number : ";
            this.AccountNumber_Label_HomePageUSer.Click += new System.EventHandler(this.AccountNumber_Label_HomePageUSer_Click);
            // 
            // AC_NO_Detail_HomepageUSerForm
            // 
            this.AC_NO_Detail_HomepageUSerForm.AutoSize = true;
            this.AC_NO_Detail_HomepageUSerForm.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AC_NO_Detail_HomepageUSerForm.Location = new System.Drawing.Point(528, 170);
            this.AC_NO_Detail_HomepageUSerForm.Name = "AC_NO_Detail_HomepageUSerForm";
            this.AC_NO_Detail_HomepageUSerForm.Size = new System.Drawing.Size(86, 24);
            this.AC_NO_Detail_HomepageUSerForm.TabIndex = 30;
            this.AC_NO_Detail_HomepageUSerForm.Text = "8907648729\r\n";
            // 
            // Available_Balance_Label_HomePageUSer
            // 
            this.Available_Balance_Label_HomePageUSer.AutoSize = true;
            this.Available_Balance_Label_HomePageUSer.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Available_Balance_Label_HomePageUSer.Location = new System.Drawing.Point(337, 242);
            this.Available_Balance_Label_HomePageUSer.Name = "Available_Balance_Label_HomePageUSer";
            this.Available_Balance_Label_HomePageUSer.Size = new System.Drawing.Size(120, 24);
            this.Available_Balance_Label_HomePageUSer.TabIndex = 31;
            this.Available_Balance_Label_HomePageUSer.Text = "Available Balance : ";
            // 
            // Available_Balance_Detail_HomepageUSerForm
            // 
            this.Available_Balance_Detail_HomepageUSerForm.AutoSize = true;
            this.Available_Balance_Detail_HomepageUSerForm.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Available_Balance_Detail_HomepageUSerForm.Location = new System.Drawing.Point(552, 242);
            this.Available_Balance_Detail_HomepageUSerForm.Name = "Available_Balance_Detail_HomepageUSerForm";
            this.Available_Balance_Detail_HomepageUSerForm.Size = new System.Drawing.Size(53, 24);
            this.Available_Balance_Detail_HomepageUSerForm.TabIndex = 32;
            this.Available_Balance_Detail_HomepageUSerForm.Text = "50,000\r\n";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(728, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 44);
            this.button1.TabIndex = 10;
            this.button1.Text = "Recieve Money";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SendMoney_btn_HomepgeCustomerForm
            // 
            this.SendMoney_btn_HomepgeCustomerForm.BackColor = System.Drawing.Color.RoyalBlue;
            this.SendMoney_btn_HomepgeCustomerForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendMoney_btn_HomepgeCustomerForm.FlatAppearance.BorderSize = 0;
            this.SendMoney_btn_HomepgeCustomerForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendMoney_btn_HomepgeCustomerForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendMoney_btn_HomepgeCustomerForm.ForeColor = System.Drawing.Color.White;
            this.SendMoney_btn_HomepgeCustomerForm.Location = new System.Drawing.Point(350, 418);
            this.SendMoney_btn_HomepgeCustomerForm.Name = "SendMoney_btn_HomepgeCustomerForm";
            this.SendMoney_btn_HomepgeCustomerForm.Size = new System.Drawing.Size(255, 44);
            this.SendMoney_btn_HomepgeCustomerForm.TabIndex = 33;
            this.SendMoney_btn_HomepgeCustomerForm.Text = "Send Money";
            this.SendMoney_btn_HomepgeCustomerForm.UseVisualStyleBackColor = false;
            this.SendMoney_btn_HomepgeCustomerForm.Click += new System.EventHandler(this.SendMoney_btn_HomepgeCustomerForm_Click);
            // 
            // Account_type_Detail_label_HomePageUserInfoForm
            // 
            this.Account_type_Detail_label_HomePageUserInfoForm.AutoSize = true;
            this.Account_type_Detail_label_HomePageUserInfoForm.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account_type_Detail_label_HomePageUserInfoForm.Location = new System.Drawing.Point(929, 248);
            this.Account_type_Detail_label_HomePageUserInfoForm.Name = "Account_type_Detail_label_HomePageUserInfoForm";
            this.Account_type_Detail_label_HomePageUserInfoForm.Size = new System.Drawing.Size(54, 24);
            this.Account_type_Detail_label_HomePageUserInfoForm.TabIndex = 35;
            this.Account_type_Detail_label_HomePageUserInfoForm.Text = "Savings";
            this.Account_type_Detail_label_HomePageUserInfoForm.Click += new System.EventHandler(this.Account_type_Detail_label_HomePageUserInfoForm_Click);
            // 
            // Account_type_label_HomeUSerSiginForm
            // 
            this.Account_type_label_HomeUSerSiginForm.AutoSize = true;
            this.Account_type_label_HomeUSerSiginForm.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account_type_label_HomeUSerSiginForm.Location = new System.Drawing.Point(738, 248);
            this.Account_type_label_HomeUSerSiginForm.Name = "Account_type_label_HomeUSerSiginForm";
            this.Account_type_label_HomeUSerSiginForm.Size = new System.Drawing.Size(95, 24);
            this.Account_type_label_HomeUSerSiginForm.TabIndex = 34;
            this.Account_type_label_HomeUSerSiginForm.Text = "Account Type : ";
            // 
            // Transacion_Options_label_HOmePageUSerForm
            // 
            this.Transacion_Options_label_HOmePageUSerForm.AutoSize = true;
            this.Transacion_Options_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.Transacion_Options_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transacion_Options_label_HOmePageUSerForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.Transacion_Options_label_HOmePageUSerForm.Location = new System.Drawing.Point(332, 311);
            this.Transacion_Options_label_HOmePageUSerForm.Name = "Transacion_Options_label_HOmePageUSerForm";
            this.Transacion_Options_label_HOmePageUSerForm.Size = new System.Drawing.Size(291, 50);
            this.Transacion_Options_label_HOmePageUSerForm.TabIndex = 36;
            this.Transacion_Options_label_HOmePageUSerForm.Text = "Transaction Options";
            // 
            // AC_Title_Detail_HomepageUSerForm
            // 
            this.AC_Title_Detail_HomepageUSerForm.AutoSize = true;
            this.AC_Title_Detail_HomepageUSerForm.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AC_Title_Detail_HomepageUSerForm.Location = new System.Drawing.Point(929, 170);
            this.AC_Title_Detail_HomepageUSerForm.Name = "AC_Title_Detail_HomepageUSerForm";
            this.AC_Title_Detail_HomepageUSerForm.Size = new System.Drawing.Size(163, 24);
            this.AC_Title_Detail_HomepageUSerForm.TabIndex = 38;
            this.AC_Title_Detail_HomepageUSerForm.Text = "Muhammad Hassan Askari";
            // 
            // AccountTitle_Label_HomePageUSer
            // 
            this.AccountTitle_Label_HomePageUSer.AutoSize = true;
            this.AccountTitle_Label_HomePageUSer.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountTitle_Label_HomePageUSer.Location = new System.Drawing.Point(738, 170);
            this.AccountTitle_Label_HomePageUSer.Name = "AccountTitle_Label_HomePageUSer";
            this.AccountTitle_Label_HomePageUSer.Size = new System.Drawing.Size(93, 24);
            this.AccountTitle_Label_HomePageUSer.TabIndex = 37;
            this.AccountTitle_Label_HomePageUSer.Text = "Account Title : ";
            // 
            // Recent_Transaction_label_HOmePageUSerForm
            // 
            this.Recent_Transaction_label_HOmePageUSerForm.AutoSize = true;
            this.Recent_Transaction_label_HOmePageUSerForm.BackColor = System.Drawing.Color.Transparent;
            this.Recent_Transaction_label_HOmePageUSerForm.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recent_Transaction_label_HOmePageUSerForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.Recent_Transaction_label_HOmePageUSerForm.Location = new System.Drawing.Point(332, 527);
            this.Recent_Transaction_label_HOmePageUSerForm.Name = "Recent_Transaction_label_HOmePageUSerForm";
            this.Recent_Transaction_label_HOmePageUSerForm.Size = new System.Drawing.Size(299, 50);
            this.Recent_Transaction_label_HOmePageUSerForm.TabIndex = 39;
            this.Recent_Transaction_label_HOmePageUSerForm.Text = "Recent Transactions";
            // 
            // TransactionsTable_HomePageUser
            // 
            this.TransactionsTable_HomePageUser.AllowUserToAddRows = false;
            this.TransactionsTable_HomePageUser.AllowUserToDeleteRows = false;
            this.TransactionsTable_HomePageUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TransactionsTable_HomePageUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TransactionsTable_HomePageUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TransactionsTable_HomePageUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.TransactionsTable_HomePageUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionsTable_HomePageUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.TransactionsTable_HomePageUser.Location = new System.Drawing.Point(308, 590);
            this.TransactionsTable_HomePageUser.Name = "TransactionsTable_HomePageUser";
            this.TransactionsTable_HomePageUser.ReadOnly = true;
            this.TransactionsTable_HomePageUser.RowHeadersWidth = 51;
            this.TransactionsTable_HomePageUser.RowTemplate.Height = 24;
            this.TransactionsTable_HomePageUser.Size = new System.Drawing.Size(812, 138);
            this.TransactionsTable_HomePageUser.TabIndex = 40;
            this.TransactionsTable_HomePageUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransactionsTable_HomePageUser_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Transaction ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 113;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Transaction Type";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 81;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Transaction Date";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 128;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 104;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.HeaderText = "Branch ID";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 87;
            // 
            // HomePageCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 803);
            this.Controls.Add(this.TransactionsTable_HomePageUser);
            this.Controls.Add(this.Recent_Transaction_label_HOmePageUSerForm);
            this.Controls.Add(this.AC_Title_Detail_HomepageUSerForm);
            this.Controls.Add(this.AccountTitle_Label_HomePageUSer);
            this.Controls.Add(this.Transacion_Options_label_HOmePageUSerForm);
            this.Controls.Add(this.Account_type_Detail_label_HomePageUserInfoForm);
            this.Controls.Add(this.Account_type_label_HomeUSerSiginForm);
            this.Controls.Add(this.SendMoney_btn_HomepgeCustomerForm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Available_Balance_Detail_HomepageUSerForm);
            this.Controls.Add(this.Available_Balance_Label_HomePageUSer);
            this.Controls.Add(this.AC_NO_Detail_HomepageUSerForm);
            this.Controls.Add(this.AccountNumber_Label_HomePageUSer);
            this.Controls.Add(this.AccountSummary_label_HOmePageUSerForm);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Greeting_Label_btn_HomeFormUser);
            this.Controls.Add(this.Exit_btn_btn_HomeFormUser);
            this.Controls.Add(this.SideLeft_panel_HomePageForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomePageCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePageCustomers";
            this.Load += new System.EventHandler(this.HomePageCustomers_Load);
            this.SideLeft_panel_HomePageForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsTable_HomePageUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SideLeft_panel_HomePageForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Logout_btn_HomeFormUser;
        private System.Windows.Forms.Button TermsAndConditions_btn_HomeFormUser;
        private System.Windows.Forms.Button Update_AccountInfo_HomePageUserForm;
        private System.Windows.Forms.Button Account_Statment_btn_HomeFormUser;
        private System.Windows.Forms.Button Privacy_And_Security_btn_HomeFormUser;
        private System.Windows.Forms.Button TransactionHistory_btn_HomeFormUser;
        private System.Windows.Forms.Button Exit_btn_btn_HomeFormUser;
        private System.Windows.Forms.Label Greeting_Label_btn_HomeFormUser;
        private System.Windows.Forms.Splitter splitter1;
        private Label AccountSummary_label_HOmePageUSerForm;
        private Label AccountNumber_Label_HomePageUSer;
        private Label AC_NO_Detail_HomepageUSerForm;
        private Label Available_Balance_Label_HomePageUSer;
        private Label Available_Balance_Detail_HomepageUSerForm;
        private Button button1;
        private Button SendMoney_btn_HomepgeCustomerForm;
        private Label Account_type_Detail_label_HomePageUserInfoForm;
        private Label Account_type_label_HomeUSerSiginForm;
        private Label Transacion_Options_label_HOmePageUSerForm;
        private Label AC_Title_Detail_HomepageUSerForm;
        private Label AccountTitle_Label_HomePageUSer;
        private Label Recent_Transaction_label_HOmePageUSerForm;
        private DataGridView TransactionsTable_HomePageUser;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }


}