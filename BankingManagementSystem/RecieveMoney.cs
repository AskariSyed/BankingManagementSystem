using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace BankingManagementSystem
{
    public partial class RecieveMoney : Form
    {
        public RecieveMoney()
        {
            InitializeComponent();
            AccountNumbertxtbox.Text = Convert.ToString(GlobalData.CustomerAccount.accountId);
            AccountTitletxtbox.Text = GlobalData.CurrentCustomer.customerName;
            BranchNumberTxt.Text= Convert.ToString(GlobalData.CustomerAccount.branchID);
            BranchNametxt.Text = GlobalData.CustomerAccount.branchName;
            this.Paint += new PaintEventHandler(RecieveMoney_Paint);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RecieveMoney_Load(object sender, EventArgs e)
        {
            
         
     
        }
        private void RecieveMoney_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 5;
            Color borderColor = Color.FromArgb(255, 191, 0);
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BranchNumberTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void BranchNametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountNumbertxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountTitletxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BankNametxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void CopyDetailsBtn_Click(object sender, EventArgs e)
        {
            string details = "Bank Name: " + BankNametxtBox.Text +
                      "\nAccount Title: " + AccountTitletxtbox.Text +
                      "\nAccount Number: " + AccountNumbertxtbox.Text +
                      "\nBranch Name: " + BranchNametxt.Text +
                      "\nBranch Number: " + BranchNumberTxt.Text;

            Clipboard.SetText(details);
            GlobalData.customizedPopup("Copied to Clipboard!");
            this.Close();
        }

        private void textCopied_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
