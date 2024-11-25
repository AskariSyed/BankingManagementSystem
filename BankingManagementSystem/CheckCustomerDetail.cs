using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankingManagementSystem
{
    public partial class CheckCustomerDetail : Form
    {
        public CheckCustomerDetail()
        {
            InitializeComponent();
            AccountStatus_Detail_CheckCustomer.Visible = false;
            AccountStatus_Detail_CheckCustomer.Visible = false;
            AccountStatus_label_CheckCustomer.Visible = false;
            AC_Title_Detail_CheckCustomerForm.Visible = false;
            AccountTitle_Label_CheckCustomer.Visible = false;
            cnic_detail_label_CheckCustomer.Visible = false;
            CNIC_Label_CheckCustomer.Visible = false;
            AC_NO_Detail_CheckCustomerForm.Visible   = false;
            AccountNumber_Label_checkCustomer.Visible = false;
            DateOfBirth_Detail_CheckCustomer.Visible = false;
            DateOfBirth_Label_CheckCustomer.Visible = false;
            DateOpened_Detail_CheckCustomer.Visible = false;
            DateOfBirth_Label_CheckCustomer.Visible = false;
            Available_Balance_Detail_CheckCustomerForm.Visible = false;
            Available_Balance_Label_CheckCustomer.Visible = false;
            Account_type_Detail_labelCheckCustomerForm.Visible = false;
            Account_type_label_CheckCustomerForm.Visible = false;
            Branchaname_Detail_CheckCustomer.Visible = false;
            Branchaname_label_CheckCustomer.Visible = false;
            UpdateCustomerInformation_Button.Visible = false;
            BlockCustomerAccount_button.Visible = false;
            SeeAllTransactions_button.Visible = false;  
            DateOpened_Label_CheckCustomer.Visible = false;
            BlockageDescription_Label_CheckCustomer.Visible = false;
            BlockageDescription_Detail_CheckCustomer.Visible=false;
            onlineUserStatusLabelCheckCustomer.Visible = false; 
            OnlineUserStatusDetailCheckCustomer.Visible = false;
            BlockCustomerOnlineUserButton.Visible = false;
            this.Paint += new PaintEventHandler(CheckCustomer_Paint);

        }
        private void CheckCustomer_Paint(object sender, PaintEventArgs e)
        {
            // Define border color and width
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);


            // Draw the border
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CheckCustomerDetail_Load(object sender, EventArgs e)
        {

        }

        private void SearchByName_BTN_Click(object sender, EventArgs e)
        {
            populateCustomer("Name",AttributeTxtBox.Text,"customers");

        }

        private void populateCustomer(string attribute,string value,string table)
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
                        if (reader.HasRows)  // Check if any customer exists
                        {
                            MessageBox.Show("customer found with the given "+attribute);
                            AccountStatus_Detail_CheckCustomer.Visible = true;
                            AccountStatus_label_CheckCustomer.Visible = true;
                            AC_Title_Detail_CheckCustomerForm.Visible = true;
                            AccountTitle_Label_CheckCustomer.Visible = true;
                            cnic_detail_label_CheckCustomer.Visible = true;
                            CNIC_Label_CheckCustomer.Visible = true;
                            AC_NO_Detail_CheckCustomerForm.Visible = true;
                            AccountNumber_Label_checkCustomer.Visible = true;
                            DateOfBirth_Detail_CheckCustomer.Visible = true;
                            DateOfBirth_Label_CheckCustomer.Visible = true;
                            DateOpened_Detail_CheckCustomer.Visible = true;
                            DateOfBirth_Label_CheckCustomer.Visible = true;
                            Available_Balance_Detail_CheckCustomerForm.Visible = true;
                            Available_Balance_Label_CheckCustomer.Visible = true;
                            Account_type_Detail_labelCheckCustomerForm.Visible = true;
                            Account_type_label_CheckCustomerForm.Visible = true;
                            Branchaname_Detail_CheckCustomer.Visible = true;
                            Branchaname_label_CheckCustomer.Visible = true;
                            DateOpened_Label_CheckCustomer.Visible = true;

                            BlockCustomerAccount_button.Visible = true;
                            SeeAllTransactions_button.Visible = true;
                            UpdateCustomerInformation_Button.Visible = true;
                            onlineUserStatusLabelCheckCustomer.Visible = true;
                            OnlineUserStatusDetailCheckCustomer.Visible = true;
                            BlockCustomerOnlineUserButton.Visible = true;
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
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }

            AccountStatus_Detail_CheckCustomer.Text = GlobalData.CustomerAccount.status.ToString();
            AC_Title_Detail_CheckCustomerForm.Text = GlobalData.CurrentCustomer.customerName;
            MessageBox.Show(GlobalData.CurrentCustomer.nationalID);
            cnic_detail_label_CheckCustomer.Text = GlobalData.CurrentCustomer.nationalID;
            AC_NO_Detail_CheckCustomerForm.Text = GlobalData.CustomerAccount.accountId.ToString();
            DateOfBirth_Detail_CheckCustomer.Text = DateTime.Parse(GlobalData.CurrentCustomer.dateOfBirth).ToString("yyyy-MM-dd");
            DateOpened_Detail_CheckCustomer.Text = DateTime.Parse(GlobalData.CustomerAccount.dateOpened).ToString("yyyy-MM-dd");
            Available_Balance_Detail_CheckCustomerForm.Text = GlobalData.CustomerAccount.accountBalance.ToString();
            Account_type_Detail_labelCheckCustomerForm.Text = GlobalData.CustomerAccount.type.ToString();
            Branchaname_Detail_CheckCustomer.Text = GlobalData.CustomerAccount.branchName.ToString();
            OnlineUserStatusDetailCheckCustomer.Text=GlobalData.CurrentCustomer.userStatus;
            if (GlobalData.CustomerAccount.status.ToString() == "Blocked")
            {
                BlockCustomerAccount_button.Text = "Unblock Customer Account";
                BlockageDescription_Detail_CheckCustomer.Visible = true;
                BlockageDescription_Label_CheckCustomer.Visible = true;
                BlockageDescription_Detail_CheckCustomer.Text = "Due to invalid Password Attempts";

            }
            else
            {
                BlockCustomerAccount_button.Text="Block Customer Account";
                BlockageDescription_Detail_CheckCustomer.Visible = false;
                BlockageDescription_Label_CheckCustomer.Visible = false;
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
            string value = AttributeTxtBox.Text; // Assume "6110121909787"
            string formattedValue = null;
            if (value.Length == 13)  // Ensure the input length is correct
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

        private void SearchByName_BTN_MouseHover(object sender, EventArgs e)
        {
            toolTipForFullName.Show("Enter Full Name As Per ID Card !", SearchByName_BTN, 1500);
        }

        private void SearchByCNIC_btn_MouseHover(object sender, EventArgs e)
        {
            toolTipForFullName.Show("Enter CNIC Without Hyphens !", SearchByCNIC_btn, 1500);

        }

        private void SeeAllTransactions_button_Click(object sender, EventArgs e)
        {
            AllTransactionsTable allTransactionsTable = new AllTransactionsTable();
            allTransactionsTable.Show();
        }

        private void BlockCustomerOnlineUserButton_Click(object sender, EventArgs e)
        {
            string query = null;
            if (GlobalData.CurrentCustomer.userStatus == "Blocked")
            {
                query = "update users set status= 'Active',failedLoginAttempt=0 where user_id= :userid ";
            }else
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
                       int rowsAffected= cmd.ExecuteNonQuery();
                        if(rowsAffected>0){
                            MessageBox.Show("User Status Changed SuccessFuly");

                            GlobalData.CurrentCustomer.userStatus= (GlobalData.CurrentCustomer.userStatus == "Blocked") ? "Active" : "Blocked";
                            OnlineUserStatusDetailCheckCustomer.Text = GlobalData.CurrentCustomer.userStatus;
                            BlockCustomerOnlineUserButton.Text= (GlobalData.CurrentCustomer.userStatus == "Blocked") ? "UnBlock Customer Online User" : "Block Customer Online User";
                           
                            int newAuditID =signInpage.GenerateNewLogID();
                            string UpdateUserOnlineAccountQuery = "INSERT INTO AUDITLOG (AUDIT_LOG_ID, USER_ID, ACTION_PERFORMED, ACTION_DATE) " +
                                    "VALUES (:auditLogId, :userId, :actionPerformed, SYSTIMESTAMP)";

                            try
                            {
                                using (OracleCommand updatequerycmd = new OracleCommand(UpdateUserOnlineAccountQuery, conn))
                                {
                                    updatequerycmd.Parameters.Add(new OracleParameter("auditLogId", newAuditID));
                                    updatequerycmd.Parameters.Add(new OracleParameter("userId", "EMP10016"));
                                    updatequerycmd.Parameters.Add(new OracleParameter("actionPerformed",GlobalData.CustomerAccount.accountId+ " User Online account Status Changed to : "+GlobalData.CurrentCustomer.userStatus.ToString()));
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
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } 
            }

        }

        private void BlockCustomerAccount_button_Click(object sender, EventArgs e)
        {
            // Determine the new status based on the current status
            Account.statusType newStatus = (GlobalData.CustomerAccount.status == Account.statusType.Active)
                                            ? Account.statusType.Closed
                                            : Account.statusType.Active;

            // Update the query based on the new status
            string query = $"update account set status= :newStatus where customer_id= :customerid";

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Add the customer ID and the new status as parameters
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
                                    updatequerycmd.Parameters.Add(new OracleParameter("userId", "EMP10016"));
                                    updatequerycmd.Parameters.Add(new OracleParameter("actionPerformed", +GlobalData.CustomerAccount.accountId + " account Status Changed to : "+GlobalData.CustomerAccount.status.ToString()));
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
                            AccountStatus_Detail_CheckCustomer.Text = GlobalData.CurrentCustomer.userStatus;
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
                AccountStatus_Detail_CheckCustomer.Text = GlobalData.CustomerAccount.status.ToString();
            }
            else
            {
                BlockCustomerAccount_button.Text = "Close Customer Account";
                AccountStatus_Detail_CheckCustomer.Text = GlobalData.CustomerAccount.status.ToString();
            }
        }


        private void UpdateCustomerInformation_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
