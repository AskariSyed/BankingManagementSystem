using System;
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
    public partial class CheckCustomerLogs : Form
    {
        public CheckCustomerLogs()
        {
            InitializeComponent();
            AuditLogDataGridTable.Visible = false;
            SeeAllTransactions_button.Visible = false;
            BlockCustomerAccount_button.Visible = false;
            BlockCustomerOnlineUserButton.Visible = false;
            UpdateCustomerInformation_Button.Visible = false;
            this.Paint += new PaintEventHandler(paint);
        }

        private void CheckCustomerLogs_Load(object sender, EventArgs e)
        {

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

        private void SearchByName_BTN_Click(object sender, EventArgs e)
        {
            populateCustomer("Name", AttributeTxtBox.Text, "customers");
        }


        private void populateCustomer(string attribute, string value, string table)
        {
            string query = $"SELECT customer_id FROM {table} WHERE {attribute} = :value";
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {

                        cmd.Parameters.Add(new OracleParameter("value", value));
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows) 
                        {
                            MessageBox.Show("customer found with the given " + attribute);
                          
                        }
                        else
                        {
                            MessageBox.Show("Reader does not have any value");
                            return;
                        }

                        while (reader.Read())
                        {
                            Customer customer = new Customer("CUS" + reader["customer_id"].ToString());
                            GlobalData.CurrentCustomer = customer;
                            customer.customerId = Convert.ToInt32(reader["customer_id"]);
                            MessageBox.Show(Convert.ToString(reader["customer_id"]));
                            Account account = new Account(customer.customerId);
                            GlobalData.CustomerAccount = account;
                            AuditLogDataGridTable.Visible = true;
                            FetchAuditLogs();
                            UpdateCustomerInformation_Button.Visible = true;    
                            BlockCustomerOnlineUserButton.Visible = true;
                            BlockCustomerAccount_button.Visible = true; 
                            SeeAllTransactions_button.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }

           
            if (GlobalData.CustomerAccount.status.ToString() == "Blocked")
            {
                BlockCustomerAccount_button.Text = "Unblock Customer Account";
            }
            else
            {
                BlockCustomerAccount_button.Text = "Block Customer Account";
            }
            if (GlobalData.CurrentCustomer.userStatus == "Blocked")
            {

                BlockCustomerOnlineUserButton.Text = "UnBlock Customer Online User";
            }
            else
            {
                BlockCustomerOnlineUserButton.Text = "Block Customer Online User";
            }


        }

        private void SearchByCNIC_btn_Click(object sender, EventArgs e)
        {
            string value = AttributeTxtBox.Text;
            string formattedValue = null;
            if (value.Length == 13)
            {
                formattedValue = $"{value.Substring(0, 5)}-{value.Substring(5, 7)}-{value.Substring(12, 1)}";
            }
            else
            {
                MessageBox.Show("Invalid input. Ensure it contains 13 digits.");
                return;
            }
            populateCustomer("NATIONAL_ID", formattedValue, "customers");
        }

        private void SearchByAccountNumber_btn_Click(object sender, EventArgs e)
        {
            if (AttributeTxtBox.Text.Length == 10)
            {
                populateCustomer("ACCOUNT_ID", AttributeTxtBox.Text, "ACCOUNT");
            }
            else
            {
                MessageBox.Show("Please Enter a Valid 10 Digit Account Number ");
                return;
            }
        }

        private void toolTipForFullName_Popup(object sender, PopupEventArgs e)
        {

        }

        private void SearchByName_BTN_MouseHover(object sender, EventArgs e)
        {
            toolTipForFullName.Show("Enter Full Name As Per ID Card !", SearchByName_BTN, 1500);
        }

        private void SearchByCNIC_btn_MouseHover(object sender, EventArgs e)
        {
            toolTipForFullName.Show("Enter CNIC Without Hyphens !", SearchByCNIC_btn, 1500);
        }

        private void SearchByAccountNumber_btn_MouseHover(object sender, EventArgs e)
        {
            toolTipForFullName.Show("Enter Valid 10 Digit Number !", SearchByCNIC_btn, 1500);
        }

        private void AuditLogDataGridTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FetchAuditLogs()
        {
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                string logQuery = "SELECT AUDIT_LOG_ID, ACTION_PERFORMED, ACTION_DATE FROM auditlog WHERE USER_ID = :userId ORDER BY ACTION_DATE desc";

                try
                {
                    conn.Open();
                    using (OracleCommand logCmd = new OracleCommand(logQuery, conn))
                    {
                        logCmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentCustomer.userID));
                        OracleDataReader logReader = logCmd.ExecuteReader();
                        AuditLogDataGridTable.Rows.Clear();

                        if (!logReader.HasRows)
                        {
                            AuditLogDataGridTable.Visible = false;
                            MessageBox.Show("No recent activities found for this user.");
                            return;
                        }
                        while (logReader.Read())
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["AUDIT_LOG_ID"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["ACTION_PERFORMED"] });
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = logReader["ACTION_DATE"] });
                            AuditLogDataGridTable.Rows.Add(row);
                        }
                        AuditLogDataGridTable.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching audit logs: " + ex.Message);
                }
            }
        }

        private void SeeAllTransactions_button_Click(object sender, EventArgs e)
        {
            AllTransactionsTable allTransactionsTable   = new AllTransactionsTable();
            allTransactionsTable.Show();
        }

        private void UpdateCustomerInformation_Button_Click(object sender, EventArgs e)
        {

        }

        private void BlockCustomerAccount_button_Click(object sender, EventArgs e)
        {
            Account.statusType newStatus = (GlobalData.CustomerAccount.status == Account.statusType.Active)
                                            ? Account.statusType.Closed
                                            : Account.statusType.Active;

          
            string query = $"update account set status= :newStatus where customer_id= :customerid";

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
               
                        cmd.Parameters.Add(new OracleParameter("newStatus", newStatus.ToString()));
                        cmd.Parameters.Add(new OracleParameter("customerid", GlobalData.CurrentCustomer.customerId));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            int newAuditID = signInpage.GenerateNewLogID();
                            string UpdateUserOnlineAccountQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                    "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";

                            try
                            {
                                using (OracleCommand updatequerycmd = new OracleCommand(UpdateUserOnlineAccountQuery, conn))
                                {
                                    updatequerycmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                    updatequerycmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentEmployee.userId.ToString()));
                                    updatequerycmd.Parameters.Add(new OracleParameter("actionPerformed", +GlobalData.CustomerAccount.accountId + " account Status Changed to : " + GlobalData.CustomerAccount.status.ToString()));
                                    updatequerycmd.ExecuteNonQuery();
                                    MessageBox.Show("audit log updated");
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            MessageBox.Show("Account Status Changed Successfully");
                            GlobalData.CustomerAccount.status = newStatus;
                            Customer customer = new Customer(GlobalData.CurrentCustomer.userID);
                            GlobalData.CurrentCustomer = customer;
                            BlockCustomerAccount_button.Text = (newStatus == Account.statusType.Active)
                                ? "Close Customer Account"
                                : "Activate Customer Account";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (GlobalData.CustomerAccount.status == Account.statusType.Closed)
            {
                BlockCustomerAccount_button.Text = "Activate Customer Account";
              
            }
            else
            {
                BlockCustomerAccount_button.Text = "Close Customer Account";
                
            }
        }

        private void BlockCustomerOnlineUserButton_Click(object sender, EventArgs e)
        {
            string query = null;
            if (GlobalData.CurrentCustomer.userStatus == "Blocked")
            {
                query = "update users set status= 'Active',failedLoginAttempt=0 where user_id= :userid ";
            }
            else
            {
                query = "update users set status= 'Blocked' where user_id= :userid ";
            }
            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("userid", GlobalData.CurrentCustomer.userID));
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User Status Changed SuccessFuly");

                            GlobalData.CurrentCustomer.userStatus = (GlobalData.CurrentCustomer.userStatus == "Blocked") ? "Active" : "Blocked";
                       
                            BlockCustomerOnlineUserButton.Text = (GlobalData.CurrentCustomer.userStatus == "Blocked") ? "UnBlock Customer Online User" : "Block Customer Online User";

                            int newAuditID = signInpage.GenerateNewLogID();
                            string UpdateUserOnlineAccountQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                    "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";

                            try
                            {
                                using (OracleCommand updatequerycmd = new OracleCommand(UpdateUserOnlineAccountQuery, conn))
                                {
                                    updatequerycmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                    updatequerycmd.Parameters.Add(new OracleParameter("userId", GlobalData.CurrentEmployee.userId.ToString()));
                                    updatequerycmd.Parameters.Add(new OracleParameter("actionPerformed", GlobalData.CustomerAccount.accountId + " User Online account Status Changed to : " + GlobalData.CurrentCustomer.userStatus.ToString()));
                                    updatequerycmd.ExecuteNonQuery();
                                    MessageBox.Show("audit log updated");
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Exit_btn_UpdatePersonalINfor_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccountSummary_label_HOmePageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void AttributeTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

