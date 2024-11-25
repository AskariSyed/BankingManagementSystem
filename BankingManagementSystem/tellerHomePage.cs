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
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
