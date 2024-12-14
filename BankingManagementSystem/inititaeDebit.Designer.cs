namespace BankingManagementSystem
{
    partial class inititaeDebit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerAccountNotxtBox = new System.Windows.Forms.MaskedTextBox();
            this.AmountTxtBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit_btn__SendMoney_Form = new System.Windows.Forms.Button();
            this.inititateButtonButton = new System.Windows.Forms.Button();
            this.Customer_Label_ForgOPasswordForm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerAccountNotxtBox
            // 
            this.CustomerAccountNotxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.CustomerAccountNotxtBox.Location = new System.Drawing.Point(341, 329);
            this.CustomerAccountNotxtBox.Mask = "0000000000";
            this.CustomerAccountNotxtBox.Name = "CustomerAccountNotxtBox";
            this.CustomerAccountNotxtBox.Size = new System.Drawing.Size(108, 22);
            this.CustomerAccountNotxtBox.TabIndex = 107;
            // 
            // AmountTxtBox
            // 
            this.AmountTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.AmountTxtBox.Location = new System.Drawing.Point(341, 384);
            this.AmountTxtBox.Mask = "0000000000";
            this.AmountTxtBox.Name = "AmountTxtBox";
            this.AmountTxtBox.Size = new System.Drawing.Size(108, 22);
            this.AmountTxtBox.TabIndex = 106;
            this.AmountTxtBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.AmountTxtBox_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(46, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 105;
            this.label1.Text = "Amount";
            // 
            // Exit_btn__SendMoney_Form
            // 
            this.Exit_btn__SendMoney_Form.AccessibleName = "Exit_btn_signinForm";
            this.Exit_btn__SendMoney_Form.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn__SendMoney_Form.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_btn__SendMoney_Form.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_btn__SendMoney_Form.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn__SendMoney_Form.Location = new System.Drawing.Point(552, 26);
            this.Exit_btn__SendMoney_Form.Name = "Exit_btn__SendMoney_Form";
            this.Exit_btn__SendMoney_Form.Size = new System.Drawing.Size(31, 33);
            this.Exit_btn__SendMoney_Form.TabIndex = 104;
            this.Exit_btn__SendMoney_Form.Text = "X";
            this.Exit_btn__SendMoney_Form.UseVisualStyleBackColor = true;
            this.Exit_btn__SendMoney_Form.Click += new System.EventHandler(this.Exit_btn__SendMoney_Form_Click);
            // 
            // inititateButtonButton
            // 
            this.inititateButtonButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.inititateButtonButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inititateButtonButton.FlatAppearance.BorderSize = 0;
            this.inititateButtonButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inititateButtonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inititateButtonButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.inititateButtonButton.Location = new System.Drawing.Point(50, 470);
            this.inititateButtonButton.Name = "inititateButtonButton";
            this.inititateButtonButton.Size = new System.Drawing.Size(482, 51);
            this.inititateButtonButton.TabIndex = 103;
            this.inititateButtonButton.Text = "Initiate Debit";
            this.inititateButtonButton.UseVisualStyleBackColor = false;
            this.inititateButtonButton.Click += new System.EventHandler(this.inititateButtonButton_Click);
            // 
            // Customer_Label_ForgOPasswordForm
            // 
            this.Customer_Label_ForgOPasswordForm.AutoSize = true;
            this.Customer_Label_ForgOPasswordForm.BackColor = System.Drawing.Color.Transparent;
            this.Customer_Label_ForgOPasswordForm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.Customer_Label_ForgOPasswordForm.ForeColor = System.Drawing.Color.Black;
            this.Customer_Label_ForgOPasswordForm.Location = new System.Drawing.Point(46, 329);
            this.Customer_Label_ForgOPasswordForm.Name = "Customer_Label_ForgOPasswordForm";
            this.Customer_Label_ForgOPasswordForm.Size = new System.Drawing.Size(224, 23);
            this.Customer_Label_ForgOPasswordForm.TabIndex = 102;
            this.Customer_Label_ForgOPasswordForm.Text = "Customer Account No";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankingManagementSystem.Properties.Resources.New_Logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(17, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(432, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // inititaeDebit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 547);
            this.Controls.Add(this.CustomerAccountNotxtBox);
            this.Controls.Add(this.AmountTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit_btn__SendMoney_Form);
            this.Controls.Add(this.inititateButtonButton);
            this.Controls.Add(this.Customer_Label_ForgOPasswordForm);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "inititaeDebit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "inititaeDebit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox CustomerAccountNotxtBox;
        private System.Windows.Forms.MaskedTextBox AmountTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit_btn__SendMoney_Form;
        private System.Windows.Forms.Button inititateButtonButton;
        private System.Windows.Forms.Label Customer_Label_ForgOPasswordForm;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}