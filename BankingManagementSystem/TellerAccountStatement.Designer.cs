namespace BankingManagementSystem
{
    partial class TellerAccountStatement
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
            this.Exit_btn__SendMoney_Form = new System.Windows.Forms.Button();
            this.TransferButton_SendMoneyForm = new System.Windows.Forms.Button();
            this.Email_Label_ForgOPasswordForm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GenerateFullAccountStatement = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerAccountNotxtBox
            // 
            this.CustomerAccountNotxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.CustomerAccountNotxtBox.Location = new System.Drawing.Point(406, 332);
            this.CustomerAccountNotxtBox.Mask = "0000000000";
            this.CustomerAccountNotxtBox.Name = "CustomerAccountNotxtBox";
            this.CustomerAccountNotxtBox.Size = new System.Drawing.Size(108, 22);
            this.CustomerAccountNotxtBox.TabIndex = 100;
            this.CustomerAccountNotxtBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.RecieverAccountNotxtBox_MaskInputRejected);
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
            this.TransferButton_SendMoneyForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransferButton_SendMoneyForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferButton_SendMoneyForm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TransferButton_SendMoneyForm.Location = new System.Drawing.Point(60, 584);
            this.TransferButton_SendMoneyForm.Name = "TransferButton_SendMoneyForm";
            this.TransferButton_SendMoneyForm.Size = new System.Drawing.Size(482, 51);
            this.TransferButton_SendMoneyForm.TabIndex = 96;
            this.TransferButton_SendMoneyForm.Text = "Generate Account Statement";
            this.TransferButton_SendMoneyForm.UseVisualStyleBackColor = false;
            this.TransferButton_SendMoneyForm.Click += new System.EventHandler(this.TransferButton_SendMoneyForm_Click);
            // 
            // Email_Label_ForgOPasswordForm
            // 
            this.Email_Label_ForgOPasswordForm.AutoSize = true;
            this.Email_Label_ForgOPasswordForm.BackColor = System.Drawing.Color.Transparent;
            this.Email_Label_ForgOPasswordForm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.Email_Label_ForgOPasswordForm.ForeColor = System.Drawing.Color.Black;
            this.Email_Label_ForgOPasswordForm.Location = new System.Drawing.Point(89, 332);
            this.Email_Label_ForgOPasswordForm.Name = "Email_Label_ForgOPasswordForm";
            this.Email_Label_ForgOPasswordForm.Size = new System.Drawing.Size(224, 23);
            this.Email_Label_ForgOPasswordForm.TabIndex = 95;
            this.Email_Label_ForgOPasswordForm.Text = "Customer Account No";
            this.Email_Label_ForgOPasswordForm.Click += new System.EventHandler(this.Email_Label_ForgOPasswordForm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankingManagementSystem.Properties.Resources.New_Logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(17, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(432, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 94;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(313, 491);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(229, 22);
            this.fromDatePicker.TabIndex = 101;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(313, 536);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(229, 22);
            this.toDatePicker.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(112, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 103;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(125, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 104;
            this.label2.Text = "To Date";
            // 
            // GenerateFullAccountStatement
            // 
            this.GenerateFullAccountStatement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.GenerateFullAccountStatement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateFullAccountStatement.FlatAppearance.BorderSize = 0;
            this.GenerateFullAccountStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateFullAccountStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateFullAccountStatement.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.GenerateFullAccountStatement.Location = new System.Drawing.Point(60, 384);
            this.GenerateFullAccountStatement.Name = "GenerateFullAccountStatement";
            this.GenerateFullAccountStatement.Size = new System.Drawing.Size(482, 51);
            this.GenerateFullAccountStatement.TabIndex = 105;
            this.GenerateFullAccountStatement.Text = "Generate Full Account Statement";
            this.GenerateFullAccountStatement.UseVisualStyleBackColor = false;
            this.GenerateFullAccountStatement.Click += new System.EventHandler(this.GenerateFullAccountStatement_Click);
            // 
            // TellerAccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 672);
            this.Controls.Add(this.GenerateFullAccountStatement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.CustomerAccountNotxtBox);
            this.Controls.Add(this.Exit_btn__SendMoney_Form);
            this.Controls.Add(this.TransferButton_SendMoneyForm);
            this.Controls.Add(this.Email_Label_ForgOPasswordForm);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TellerAccountStatement";
            this.Text = "TellerAccountStatement";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox CustomerAccountNotxtBox;
        private System.Windows.Forms.Button Exit_btn__SendMoney_Form;
        private System.Windows.Forms.Button TransferButton_SendMoneyForm;
        private System.Windows.Forms.Label Email_Label_ForgOPasswordForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GenerateFullAccountStatement;
    }
}