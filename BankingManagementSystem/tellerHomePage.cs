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
    public partial class tellerHomePage : Form
    {
        public tellerHomePage()
        {
            InitializeComponent();
            
            this.Paint += new PaintEventHandler(TellerHomePage_Paint);
            Employee_NO_Detail_HomepageUSerForm.Text = GlobalData.CurrentEmployee.employeeId.ToString();
            Position_Detail_HomepageUSerForm.Text=GlobalData.CurrentEmployee.position.ToString();
            BranchID_Detail_HomepageUSerForm.Text=GlobalData.CurrentEmployee.branchName.ToString();
            Email_Detail_label_HomePageUserInfoForm.Text=GlobalData.CurrentEmployee.email.ToString();
            Greeting_Label_btn_HomeFormUser.Text="Hello "+ GlobalData.CurrentEmployee.lastName.ToString();

        }

        private void TellerHomePage_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        private void SideLeft_panel_HomePageForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccountNumber_Label_HomePageUSer_Click(object sender, EventArgs e)
        {

        }

        private void AccountSummary_label_HOmePageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void Available_Balance_Label_HomePageUSer_Click(object sender, EventArgs e)
        {

        }

        private void Transacion_Options_label_HOmePageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void OpenNewAccount_TellerHomePage_Click(object sender, EventArgs e)
        {
            OpenNewAccountTeller ac = new OpenNewAccountTeller();
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

        private void CheckCustomerDetailButton_Click(object sender, EventArgs e)
        {
            CheckCustomerDetail checkCustomerDetail = new CheckCustomerDetail();
            checkCustomerDetail.Show();
        }

        private void Exit_btn_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            GlobalData.EmployeeLogout();
            Application.Exit();
        }

        private void Logout_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            GlobalData.EmployeeLogout();
            GlobalData.customizedPopup("Logout Successfull");
            signInpage sign= new signInpage();
            sign.Show();
            this.Close();
        }

        private void GenerateAccountStatement_Click(object sender, EventArgs e)
        {
            TellerAccountStatement ac=new TellerAccountStatement();
            ac.Show();
        }

        private void BranchID_Detail_HomepageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void Greeting_Label_btn_HomeFormUser_Click(object sender, EventArgs e)
        {

        }

        private void AccountTitle_Label_HomePageUSer_Click(object sender, EventArgs e)
        {

        }

        private void Email_Detail_label_HomePageUserInfoForm_Click(object sender, EventArgs e)
        {

        }

        private void Account_type_label_HomeUSerSiginForm_Click(object sender, EventArgs e)
        {

        }

        private void Employee_NO_Detail_HomepageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Account_Statment_btn_HomeFormUser_Click(object sender, EventArgs e)
        {

        }

        private void Privacy_And_Security_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
           EmployeePrivacyAndSecurity employeePrivacyAndSecurity = new EmployeePrivacyAndSecurity();
            employeePrivacyAndSecurity.Show();
        }

        private void TransactionHistory_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.Show();
        }

        private void TermsAndConditions_btn_HomeFormUser_Click(object sender, EventArgs e)
        {

        }

        private void Update_AccountInfo_HomePageUserForm_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchCustomerForUpdate searchCustomerForUpdate = new SearchCustomerForUpdate();
            searchCustomerForUpdate.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.Show();
        }

        private void Position_Detail_HomepageUSerForm_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
