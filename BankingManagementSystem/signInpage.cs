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
    public partial class signInpage : Form
    {
        public signInpage()
        {
            InitializeComponent();
        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Signup_btn_signinForm_Click(object sender, EventArgs e)
        {
            SignupPage signupPage = new SignupPage();
            this.Hide();
            signupPage.Show();
        }

        private void signInpage_Load(object sender, EventArgs e)
        {

        }

        private void AKBL_logoimage_picturebox_signin_page_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_btn_SigninForm_Click(object sender, EventArgs e)
        {
            HomePageCustomers homePageCustomers = new HomePageCustomers();  
            this.Hide();
            homePageCustomers.Show();

        }
    }
}
