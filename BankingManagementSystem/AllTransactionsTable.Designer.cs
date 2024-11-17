namespace BankingManagementSystem
{
    partial class AllTransactionsTable
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
            this.TransactionDatagridview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // TransactionDatagridview
            // 
            this.TransactionDatagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TransactionDatagridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TransactionDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionDatagridview.Location = new System.Drawing.Point(-2, 0);
            this.TransactionDatagridview.Name = "TransactionDatagridview";
            this.TransactionDatagridview.RowHeadersWidth = 51;
            this.TransactionDatagridview.RowTemplate.Height = 24;
            this.TransactionDatagridview.Size = new System.Drawing.Size(1094, 449);
            this.TransactionDatagridview.TabIndex = 0;
            // 
            // AllTransactionsTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 450);
            this.Controls.Add(this.TransactionDatagridview);
            this.Name = "AllTransactionsTable";
            this.Text = "AllTransactionsTable";
            this.Load += new System.EventHandler(this.AllTransactionsTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDatagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TransactionDatagridview;
    }
}