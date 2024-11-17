namespace BankingManagementSystem
{
    partial class SendMoney
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
            this.Exit_btn__SendMoney_Form = new System.Windows.Forms.Button();
            this.TransferButton_SendMoneyForm = new System.Windows.Forms.Button();
            this.Email_Label_ForgOPasswordForm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SendingAmountTxtBox = new System.Windows.Forms.MaskedTextBox();
            this.RecieverAccountNotxtBox = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit_btn__SendMoney_Form
            // 
            this.Exit_btn__SendMoney_Form.AccessibleName = "Exit_btn_signinForm";
            this.Exit_btn__SendMoney_Form.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn__SendMoney_Form.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_btn__SendMoney_Form.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_btn__SendMoney_Form.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn__SendMoney_Form.Location = new System.Drawing.Point(557, 12);
            this.Exit_btn__SendMoney_Form.Name = "Exit_btn__SendMoney_Form";
            this.Exit_btn__SendMoney_Form.Size = new System.Drawing.Size(31, 33);
            this.Exit_btn__SendMoney_Form.TabIndex = 90;
            this.Exit_btn__SendMoney_Form.Text = "X";
            this.Exit_btn__SendMoney_Form.UseVisualStyleBackColor = true;
            this.Exit_btn__SendMoney_Form.Click += new System.EventHandler(this.Exit_btn__SendMoney_Form_Click);
            // 
            // TransferButton_SendMoneyForm
            // 
            this.TransferButton_SendMoneyForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.TransferButton_SendMoneyForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransferButton_SendMoneyForm.FlatAppearance.BorderSize = 0;
            this.TransferButton_SendMoneyForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransferButton_SendMoneyForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferButton_SendMoneyForm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TransferButton_SendMoneyForm.Location = new System.Drawing.Point(55, 456);
            this.TransferButton_SendMoneyForm.Name = "TransferButton_SendMoneyForm";
            this.TransferButton_SendMoneyForm.Size = new System.Drawing.Size(482, 51);
            this.TransferButton_SendMoneyForm.TabIndex = 89;
            this.TransferButton_SendMoneyForm.Text = "Transfer";
            this.TransferButton_SendMoneyForm.UseVisualStyleBackColor = false;
            this.TransferButton_SendMoneyForm.Click += new System.EventHandler(this.TransferButton_SendMoneyForm_Click);
            // 
            // Email_Label_ForgOPasswordForm
            // 
            this.Email_Label_ForgOPasswordForm.AutoSize = true;
            this.Email_Label_ForgOPasswordForm.BackColor = System.Drawing.Color.Transparent;
            this.Email_Label_ForgOPasswordForm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.Email_Label_ForgOPasswordForm.ForeColor = System.Drawing.Color.Black;
            this.Email_Label_ForgOPasswordForm.Location = new System.Drawing.Point(51, 315);
            this.Email_Label_ForgOPasswordForm.Name = "Email_Label_ForgOPasswordForm";
            this.Email_Label_ForgOPasswordForm.Size = new System.Drawing.Size(226, 23);
            this.Email_Label_ForgOPasswordForm.TabIndex = 81;
            this.Email_Label_ForgOPasswordForm.Text = "Recievers Account No";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankingManagementSystem.Properties.Resources.askari_bank_seeklogo;
            this.pictureBox1.Location = new System.Drawing.Point(22, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(432, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 91;
            this.label1.Text = "Amount";
            // 
            // SendingAmountTxtBox
            // 
            this.SendingAmountTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SendingAmountTxtBox.Location = new System.Drawing.Point(346, 370);
            this.SendingAmountTxtBox.Mask = "0000000000";
            this.SendingAmountTxtBox.Name = "SendingAmountTxtBox";
            this.SendingAmountTxtBox.Size = new System.Drawing.Size(108, 22);
            this.SendingAmountTxtBox.TabIndex = 92;
            // 
            // RecieverAccountNotxtBox
            // 
            this.RecieverAccountNotxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.RecieverAccountNotxtBox.Location = new System.Drawing.Point(346, 315);
            this.RecieverAccountNotxtBox.Mask = "0000000000";
            this.RecieverAccountNotxtBox.Name = "RecieverAccountNotxtBox";
            this.RecieverAccountNotxtBox.Size = new System.Drawing.Size(108, 22);
            this.RecieverAccountNotxtBox.TabIndex = 93;
            // 
            // SendMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 547);
            this.Controls.Add(this.RecieverAccountNotxtBox);
            this.Controls.Add(this.SendingAmountTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit_btn__SendMoney_Form);
            this.Controls.Add(this.TransferButton_SendMoneyForm);
            this.Controls.Add(this.Email_Label_ForgOPasswordForm);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SendMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendMoney";
            this.Load += new System.EventHandler(this.SendMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit_btn__SendMoney_Form;
        private System.Windows.Forms.Button TransferButton_SendMoneyForm;
        private System.Windows.Forms.Label Email_Label_ForgOPasswordForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox SendingAmountTxtBox;
        private System.Windows.Forms.MaskedTextBox RecieverAccountNotxtBox;
    }
}