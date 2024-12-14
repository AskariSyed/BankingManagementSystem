using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingManagementSystem
{
    public partial class ManagerHomePage : Form
    {
        public ManagerHomePage()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(paint);
        }
        private void paint(object sender, PaintEventArgs e)
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
    }
}
