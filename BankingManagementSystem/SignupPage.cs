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
    public partial class SignupPage : Form
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void SignupPage_Load(object sender, EventArgs e)
        {

        }

        private void SignIn_btn_signUpForm_Click(object sender, EventArgs e)
        {
            signInpage signInpage = new signInpage();
            this.Hide();
            signInpage.Show();
        }

        private void Exit_btn_signinForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
