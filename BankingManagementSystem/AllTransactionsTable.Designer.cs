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
            this.TransactionDatagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TransactionDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionDatagridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransactionDatagridview.Location = new System.Drawing.Point(0, 0);
            this.TransactionDatagridview.Name = "TransactionDatagridview";
            this.TransactionDatagridview.RowHeadersWidth = 51;
            this.TransactionDatagridview.RowTemplate.Height = 24;
            this.TransactionDatagridview.Size = new System.Drawing.Size(1457, 356);
            this.TransactionDatagridview.TabIndex = 0;
            this.TransactionDatagridview.DataSourceChanged += new System.EventHandler(this.TransactionDatagridview_DataSourceChanged_1);
            this.TransactionDatagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransactionDatagridview_CellContentClick);
            // 
            // AllTransactionsTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.ClientSize = new System.Drawing.Size(1457, 356);
            this.Controls.Add(this.TransactionDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AllTransactionsTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AllTransactionsTable";
            this.Load += new System.EventHandler(this.AllTransactionsTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDatagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TransactionDatagridview;
    }
}