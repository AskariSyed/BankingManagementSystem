﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace BankingManagementSystem
{
    public partial class ManagerHomePage : Form
    {
        public ManagerHomePage()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(paint);
            Greeting_Label_btn_HomeFormUser.Text = "Hello " + GlobalData.CurrentEmployee.lastName;
            Position_Detail_HomepageUSerForm.Text = GlobalData.CurrentEmployee.position.ToString();
            BranchID_Detail_HomepageUSerForm.Text = GlobalData.CurrentEmployee.branchName;
            Email_Detail_label_HomePageUserInfoForm.Text= GlobalData.CurrentEmployee.email;
            Employee_NO_Detail_HomepageUSerForm.Text = GlobalData.CurrentEmployee.employeeId.ToString();

            if (CanViewAuditLog())
            {
                GrantAccess.Text = "Revoke Audit Log View Access To Customers";
                GrantAccess.BackColor = Color.Red;
            }
            else
            {
                GrantAccess.Text = "Grant Audit Log View Access To Customers";
                GrantAccess.BackColor = Color.Green;
            }


        }
        private Boolean CanViewAuditLog()
        {
            string checkAccess = "SELECT COUNT(*) FROM DBA_TAB_PRIVS WHERE GRANTEE = 'C##CUSTOMER1' AND TABLE_NAME = 'AUDITLOG' AND PRIVILEGE = 'SELECT'";
            try
            {
                using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                {
                    conn.Open();
                    using (OracleCommand ocmd = new OracleCommand(checkAccess, conn))
                    {

                        object result = ocmd.ExecuteScalar();
                        if (result != DBNull.Value && Convert.ToInt32(result) > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError("Error while checking access to AuditLog", ex);
                MessageBox.Show("An error occurred while checking access. Please check the log file or try again later.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void paint(object sender, PaintEventArgs e)
        {
            
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void ManagerHomePage_Load(object sender, EventArgs e)
        {

        }

        private void GenerateAccountStatement_Click(object sender, EventArgs e)
        {
            TellerAccountStatement ac = new TellerAccountStatement();
            ac.Show();
        }

        private void InitiateCreditTellerHomePAge_Click(object sender, EventArgs e)
        {
            InitiateCredit initiateCredit = new InitiateCredit();
            initiateCredit.Show();
        }

        private void initiateDebitButton_Click(object sender, EventArgs e)
        {
            inititaeDebit inititaeDebit = new inititaeDebit();
            inititaeDebit.Show();
        }

        private void TransferFundsButton_Click(object sender, EventArgs e)
        {
            TransferFundsTeller transferFundsTeller = new TransferFundsTeller();
            transferFundsTeller.Show();
        }

        private void TransactionHistoryBTn_Click(object sender, EventArgs e)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.Show();
        }

        private void OpenNewAccount_TellerHomePage_Click(object sender, EventArgs e)
        {
            OpenNewAccountTeller ac = new OpenNewAccountTeller();
            ac.Show();
        }

        private void CheckCustomerDetailButton_Click(object sender, EventArgs e)
        {
            CheckCustomerDetail checkCustomerDetail = new CheckCustomerDetail();
            checkCustomerDetail.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchCustomerForUpdate searchCustomerForUpdate = new SearchCustomerForUpdate();    
            searchCustomerForUpdate.Show();
        }

        private void CheckCustomerLogsBtn_Click(object sender, EventArgs e)
        {
            CheckCustomerLogs checkCustomerLogs = new CheckCustomerLogs();
            checkCustomerLogs.Show();
        }

        private void ReverseTranaction_Click(object sender, EventArgs e)
        {
            TransactionReversal transactionReversal = new TransactionReversal();
            transactionReversal.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckTransactions checkTransaction = new CheckTransactions();
            checkTransaction.Show();
        }

        private void SearchEmployee_Click(object sender, EventArgs e)
        {
            SearchEmployee searchEmployee = new SearchEmployee();   
            searchEmployee.Show();
        }

        private void Exit_btn_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            GlobalData.EmployeeLogout();
            Application.Exit();
        }

        private void TransactionHistory_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.Show();
        }

        private void Account_Statment_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            TellerAccountStatement ac = new TellerAccountStatement();
            ac.Show();
        }

        private void AddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();    
            addEmployee.Show();
        }

        private void CheckEmployeeLogs_Click(object sender, EventArgs e)
        {
            CheckEmployeeLogs checkEmployeeLogs = new CheckEmployeeLogs();
            checkEmployeeLogs.Show();
        }

        private void DeleteEmployee_Click(object sender, EventArgs e)
        {
            DeleteEmployee deleteEmployee = new DeleteEmployee();
            deleteEmployee.Show();
        }

        private void Greeting_Label_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
        }

        private void Update_AccountInfo_HomePageUserForm_Click(object sender, EventArgs e)
        {
            CheckCustomerDetail checkCustomerDetail = new CheckCustomerDetail();
            checkCustomerDetail.Show();
        }

        private void Privacy_And_Security_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            EmployeePrivacyAndSecurity employeePrivacyAndSecurity = new EmployeePrivacyAndSecurity();   
            employeePrivacyAndSecurity.Show();
        }

        private void TermsAndConditions_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            TermsAndCondition_HomePageUser termsAndConditions = new TermsAndCondition_HomePageUser();
            termsAndConditions.Show();
        }

        private void Logout_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            GlobalData.EmployeeLogout();
            GlobalData.customizedPopup("Logout Successful");
            signInpage signInpage = new signInpage();
            signInpage.Show();
            this.Close();
        }

        private void Position_Detail_HomepageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void GrantAccess_Click(object sender, EventArgs e)
        {

            if (!CanViewAuditLog())
            {

                string checkAccess = "GRANT SELECT ON auditlog to C##Customer1";
                try
                {
                    using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                    {
                        conn.Open();
                        using (OracleCommand ocmd = new OracleCommand(checkAccess, conn))
                        {

                            object result = ocmd.ExecuteNonQuery();

                        }
                    }
                    GlobalData.customizedPopup("Access Granted Successfully");

                }
                catch (Exception ex)
                {
                    GlobalData.LogError("Error while granting access to AuditLog", ex);
                    MessageBox.Show("An error occurred while granting access. Please check the log file or try again later.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally { 
                 GrantAccess.Text = "Revoke Audit Log View Access To Customers";
                GrantAccess.BackColor = Color.Red;
                }
            }
            else
            {
                string checkAccess = "REVOKE SELECT ON auditlog FROM C##Customer1";
                try
                {
                    using (OracleConnection conn = new OracleConnection(GlobalData.connString))
                    {
                        conn.Open();
                        using (OracleCommand ocmd = new OracleCommand(checkAccess, conn))
                        {

                            object result = ocmd.ExecuteNonQuery();

                        }
                    }
                    GlobalData.customizedPopup("Access Revoked Successfully");
                }
                catch (Exception ex)
                {
                    GlobalData.LogError("Error while revoking access to AuditLog", ex);
                    MessageBox.Show("An error occurred while revoking access. Please check the log file or try again later.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                 
                    GrantAccess.Text = "Grant Audit Log View Access To Customers";
                    GrantAccess.BackColor = Color.Green;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccessDatabase accessDatabase   = new AccessDatabase();
            accessDatabase.Show();
        }
    }
}
