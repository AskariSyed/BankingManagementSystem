namespace BankingManagementSystem
{
    partial class InitiateCredit
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
            this.SendingAmountTxtBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit_btn__SendMoney_Form = new System.Windows.Forms.Button();
            this.TransferButton_SendMoneyForm = new System.Windows.Forms.Button();
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
            this.CustomerAccountNotxtBox.TabIndex = 100;
            this.CustomerAccountNotxtBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.CustomerAccountNotxtBox_MaskInputRejected);
            // 
            // SendingAmountTxtBox
            // 
            this.SendingAmountTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SendingAmountTxtBox.Location = new System.Drawing.Point(341, 384);
            this.SendingAmountTxtBox.Mask = "0000000000";
            this.SendingAmountTxtBox.Name = "SendingAmountTxtBox";
            this.SendingAmountTxtBox.Size = new System.Drawing.Size(108, 22);
            this.SendingAmountTxtBox.TabIndex = 99;
            this.SendingAmountTxtBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.SendingAmountTxtBox_MaskInputRejected);
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
            this.label1.TabIndex = 98;
            this.label1.Text = "Amount";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.Exit_btn__SendMoney_Form.TabIndex = 97;
            this.Exit_btn__SendMoney_Form.Text = "X";
            this.Exit_btn__SendMoney_Form.UseVisualStyleBackColor = true;
            this.Exit_btn__SendMoney_Form.Click += new System.EventHandler(this.Exit_btn__SendMoney_Form_Click);
            // 
            // TransferButton_SendMoneyForm
            // 
            this.TransferButton_SendMoneyForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.TransferButton_SendMoneyForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransferButton_SendMoneyForm.FlatAppearance.BorderSize = 0;
            this.TransferButton_SendMoneyForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TransferButton_SendMoneyForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferButton_SendMoneyForm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TransferButton_SendMoneyForm.Location = new System.Drawing.Point(50, 470);
            this.TransferButton_SendMoneyForm.Name = "TransferButton_SendMoneyForm";
            this.TransferButton_SendMoneyForm.Size = new System.Drawing.Size(482, 51);
            this.TransferButton_SendMoneyForm.TabIndex = 96;
            this.TransferButton_SendMoneyForm.Text = "Initiate Credit";
            this.TransferButton_SendMoneyForm.UseVisualStyleBackColor = false;
            this.TransferButton_SendMoneyForm.Click += new System.EventHandler(this.TransferButton_SendMoneyForm_Click);
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
            this.Customer_Label_ForgOPasswordForm.TabIndex = 95;
            this.Customer_Label_ForgOPasswordForm.Text = "Customer Account No";
            this.Customer_Label_ForgOPasswordForm.Click += new System.EventHandler(this.Customer_Label_ForgOPasswordForm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankingManagementSystem.Properties.Resources.New_Logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 94;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // InitiateCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 547);
            this.Controls.Add(this.CustomerAccountNotxtBox);
            this.Controls.Add(this.SendingAmountTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit_btn__SendMoney_Form);
            this.Controls.Add(this.TransferButton_SendMoneyForm);
            this.Controls.Add(this.Customer_Label_ForgOPasswordForm);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InitiateCredit";
            this.Text = "InitiateCredit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox CustomerAccountNotxtBox;
        private System.Windows.Forms.MaskedTextBox SendingAmountTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit_btn__SendMoney_Form;
        private System.Windows.Forms.Button TransferButton_SendMoneyForm;
        private System.Windows.Forms.Label Customer_Label_ForgOPasswordForm;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}