namespace BankingManagementSystem
{
    partial class EnterOTPFromEmployeeForUpdate
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
            this.EnterOTP_txtBox_UpdateUserInfoForm = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.VerifyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnterOTP_txtBox_UpdateUserInfoForm
            // 
            this.EnterOTP_txtBox_UpdateUserInfoForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterOTP_txtBox_UpdateUserInfoForm.ForeColor = System.Drawing.Color.Gray;
            this.EnterOTP_txtBox_UpdateUserInfoForm.Location = new System.Drawing.Point(181, 68);
            this.EnterOTP_txtBox_UpdateUserInfoForm.Name = "EnterOTP_txtBox_UpdateUserInfoForm";
            this.EnterOTP_txtBox_UpdateUserInfoForm.Size = new System.Drawing.Size(206, 34);
            this.EnterOTP_txtBox_UpdateUserInfoForm.TabIndex = 97;
            this.EnterOTP_txtBox_UpdateUserInfoForm.Text = "Enter OTP";
            this.EnterOTP_txtBox_UpdateUserInfoForm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EnterOTP_txtBox_UpdateUserInfoForm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EnterOTP_txtBox_UpdateUserInfoForm_MouseClick);
            this.EnterOTP_txtBox_UpdateUserInfoForm.TextChanged += new System.EventHandler(this.EnterOTP_txtBox_UpdateUserInfoForm_TextChanged);
            this.EnterOTP_txtBox_UpdateUserInfoForm.MouseLeave += new System.EventHandler(this.EnterOTP_txtBox_UpdateUserInfoForm_MouseLeave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Agency FB", 12F);
            this.textBox1.ForeColor = System.Drawing.Color.SpringGreen;
            this.textBox1.Location = new System.Drawing.Point(70, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(431, 40);
            this.textBox1.TabIndex = 98;
            this.textBox1.Text = "Email With Verification Code Has been Sent to Customer\'s Email Address";
            // 
            // VerifyBtn
            // 
            this.VerifyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyBtn.Location = new System.Drawing.Point(57, 121);
            this.VerifyBtn.Name = "VerifyBtn";
            this.VerifyBtn.Size = new System.Drawing.Size(457, 41);
            this.VerifyBtn.TabIndex = 99;
            this.VerifyBtn.Text = "Verify";
            this.VerifyBtn.UseVisualStyleBackColor = true;
            this.VerifyBtn.Click += new System.EventHandler(this.VerifyBtn_Click);
            // 
            // EnterOTPFromEmployeeForUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 201);
            this.Controls.Add(this.VerifyBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EnterOTP_txtBox_UpdateUserInfoForm);
            this.Name = "EnterOTPFromEmployeeForUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter OTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EnterOTP_txtBox_UpdateUserInfoForm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button VerifyBtn;
    }
}