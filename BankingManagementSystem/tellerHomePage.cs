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
            BranchID_Detail_HomepageUSerForm.Text=GlobalData.CurrentEmployee.branchId.ToString();
            Email_Detail_label_HomePageUserInfoForm.Text=GlobalData.CurrentEmployee.email.ToString();

        }

        private void TellerHomePage_Paint(object sender, PaintEventArgs e)
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
            this.Close();
        }

        private void Logout_btn_HomeFormUser_Click(object sender, EventArgs e)
        {
            GlobalData.CurrentCustomer = null;
            GlobalData.customizedPopup("LogOut Successfull");
            signInpage sign= new signInpage();
            sign.Show();
            this.Close();
        }
    }
}
