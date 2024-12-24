namespace BankingManagementSystem
{
    partial class AccessDatabase
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.QueryTxtBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTipForFullName = new System.Windows.Forms.ToolTip(this.components);
            this.QueryResultDataGrid = new System.Windows.Forms.DataGridView();
            this.Exit_btn_UpdatePersonalINfor_Form = new System.Windows.Forms.Button();
            this.runQueryBtn = new System.Windows.Forms.Button();
            this.SearchbyBranchIDBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryResultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // QueryTxtBox
            // 
            this.QueryTxtBox.Location = new System.Drawing.Point(343, 243);
            this.QueryTxtBox.Name = "QueryTxtBox";
            this.QueryTxtBox.Size = new System.Drawing.Size(608, 22);
            this.QueryTxtBox.TabIndex = 197;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankingManagementSystem.Properties.Resources.New_Logo_1;
            this.pictureBox2.Location = new System.Drawing.Point(343, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(608, 315);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 199;
            this.pictureBox2.TabStop = false;
            // 
            // QueryResultDataGrid
            // 
            this.QueryResultDataGrid.AllowUserToAddRows = false;
            this.QueryResultDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            this.QueryResultDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.QueryResultDataGrid.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.QueryResultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QueryResultDataGrid.GridColor = System.Drawing.SystemColors.InactiveBorder;
            this.QueryResultDataGrid.Location = new System.Drawing.Point(12, 369);
            this.QueryResultDataGrid.Name = "QueryResultDataGrid";
            this.QueryResultDataGrid.ReadOnly = true;
            this.QueryResultDataGrid.RowHeadersWidth = 51;
            this.QueryResultDataGrid.RowTemplate.Height = 24;
            this.QueryResultDataGrid.Size = new System.Drawing.Size(1271, 384);
            this.QueryResultDataGrid.TabIndex = 201;
            this.QueryResultDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.QueryResultDataGrid_CellContentClick);
            // 
            // Exit_btn_UpdatePersonalINfor_Form
            // 
            this.Exit_btn_UpdatePersonalINfor_Form.AccessibleName = "Exit_btn_btn_HomeFormUser";
            this.Exit_btn_UpdatePersonalINfor_Form.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn_UpdatePersonalINfor_Form.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_btn_UpdatePersonalINfor_Form.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_btn_UpdatePersonalINfor_Form.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn_UpdatePersonalINfor_Form.Location = new System.Drawing.Point(1252, 16);
            this.Exit_btn_UpdatePersonalINfor_Form.Name = "Exit_btn_UpdatePersonalINfor_Form";
            this.Exit_btn_UpdatePersonalINfor_Form.Size = new System.Drawing.Size(31, 33);
            this.Exit_btn_UpdatePersonalINfor_Form.TabIndex = 200;
            this.Exit_btn_UpdatePersonalINfor_Form.Text = "X";
            this.Exit_btn_UpdatePersonalINfor_Form.UseVisualStyleBackColor = false;
            this.Exit_btn_UpdatePersonalINfor_Form.Click += new System.EventHandler(this.Exit_btn_UpdatePersonalINfor_Form_Click);
            // 
            // runQueryBtn
            // 
            this.runQueryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.runQueryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.runQueryBtn.Location = new System.Drawing.Point(343, 271);
            this.runQueryBtn.Name = "runQueryBtn";
            this.runQueryBtn.Size = new System.Drawing.Size(608, 28);
            this.runQueryBtn.TabIndex = 204;
            this.runQueryBtn.Text = "Run Query";
            this.runQueryBtn.UseVisualStyleBackColor = false;
            this.runQueryBtn.Click += new System.EventHandler(this.runQueryBtn_Click);
            // 
            // SearchbyBranchIDBtn
            // 
            this.SearchbyBranchIDBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.SearchbyBranchIDBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchbyBranchIDBtn.Location = new System.Drawing.Point(759, 271);
            this.SearchbyBranchIDBtn.Name = "SearchbyBranchIDBtn";
            this.SearchbyBranchIDBtn.Size = new System.Drawing.Size(150, 28);
            this.SearchbyBranchIDBtn.TabIndex = 202;
            this.SearchbyBranchIDBtn.Text = "Search By Branch ID";
            this.SearchbyBranchIDBtn.UseVisualStyleBackColor = false;
            // 
            // AccessDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 803);
            this.Controls.Add(this.QueryTxtBox);
            this.Controls.Add(this.QueryResultDataGrid);
            this.Controls.Add(this.Exit_btn_UpdatePersonalINfor_Form);
            this.Controls.Add(this.runQueryBtn);
            this.Controls.Add(this.SearchbyBranchIDBtn);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccessDatabase";
            this.Text = "AccessDatabase";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryResultDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox QueryTxtBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTipForFullName;
        private System.Windows.Forms.DataGridView QueryResultDataGrid;
        private System.Windows.Forms.Button Exit_btn_UpdatePersonalINfor_Form;
        private System.Windows.Forms.Button runQueryBtn;
        private System.Windows.Forms.Button SearchbyBranchIDBtn;
    }
}