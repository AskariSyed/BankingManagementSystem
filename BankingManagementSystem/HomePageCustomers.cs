using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
namespace BankingManagementSystem
{
    public partial class HomePageCustomers : Form
    {
        public HomePageCustomers()
        {
            InitializeComponent();

        }

        public HomePageCustomers(Customer customer)
        {
            InitializeComponent();
            if (customer != null)
            {
                Greeting_Label_btn_HomeFormUser.Text = "Hello " + customer.customerName;
                AC_Title_Detail_HomepageUSerForm.Text = customer.customerName;
                Account account = new Account(customer.customerId);
                GlobalData.CustomerAccount = account;
                AC_NO_Detail_HomepageUSerForm.Text = account.accountId.ToString();
                Available_Balance_Detail_HomepageUSerForm.Text = account.accountBalance.ToString();
                Account_type_Detail_label_HomePageUserInfoForm.Text = account.type.ToString();
                string accountId = GlobalData.CustomerAccount.accountId.ToString();
                LoadTransactions(accountId);

            }
            else
            {
                Greeting_Label_btn_HomeFormUser.Text = "Hello Guest";
            }
        }

        private void HomePageCustomers_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Logout_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            signInpage signInpage = new signInpage();
            this.Show();
            signInpage.Show();

        }

        private void Exit_btn_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Account_Statment_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            BankStatementGenerator asg = new BankStatementGenerator();
            asg.GenerateStatementPDF();
        }
        

        private void Update_AccountInfo_HomePageUserForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePersonalDetailsForm updatePersonalDetailsForm = new UpdatePersonalDetailsForm();

            updatePersonalDetailsForm.Show();

        }

        private void AccountNumber_Label_HomePageUSer_Click(object sender, EventArgs e)
        {

        }

        private void SideLeft_panel_HomePageForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TermsAndConditions_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            TermsAndCondition_HomePageUser termsAndCondition_HomePageUser = new TermsAndCondition_HomePageUser();
            termsAndCondition_HomePageUser.Show();

        }

        private void TransactionsTable_HomePageUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void LoadTransactions(string accountId)
        {
           
            string query = @"SELECT * FROM transaction 
                     WHERE account_id = :accountId 
                     ORDER BY TRANSACTION_DATE DESC 
                     FETCH FIRST 3 ROWS ONLY";

            using (OracleConnection conn = new OracleConnection(GlobalData.connString))
             {
                try
                {
                    conn.Open();
                   
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("accountId", accountId));


                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            TransactionsTable_HomePageUser.Rows.Clear();

                            if (!reader.HasRows)
                            {
                                TransactionsTable_HomePageUser.Hide();
                            }

                            while (reader.Read())
                            {
                               
                                DataGridViewRow row = new DataGridViewRow();
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["TRANSACTION_ID"] });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["TRANSACTION_TYPE"] });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["AMOUNT"] });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["TRANSACTION_DATE"] });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["DESCRIPTION"] });
                                row.Cells.Add(new DataGridViewTextBoxCell { Value = reader["BRANCH_ID"] });

                                TransactionsTable_HomePageUser.Rows.Add(row);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void Account_type_Detail_label_HomePageUserInfoForm_Click(object sender, EventArgs e)
        {

        }

        private void SendMoney_btn_HomepgeCustomerForm_Click(object sender, EventArgs e)
        {
            SendMoney sendMoney = new SendMoney();
            sendMoney.Show();
        }

        private void TransactionHistory_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            AllTransactionsTable allTransactionsTable = new AllTransactionsTable(); 
            allTransactionsTable.Show();
        }
    }
}
