namespace TypographyShopView
{
    partial class FormMessages
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.textBoxPage = new System.Windows.Forms.TextBox();
			this.labelPage = new System.Windows.Forms.Label();
			this.buttonTo = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(8, 8);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 62;
			this.dataGridView.RowTemplate.Height = 28;
			this.dataGridView.Size = new System.Drawing.Size(517, 277);
			this.dataGridView.TabIndex = 0;
			// 
			// textBoxPage
			// 
			this.textBoxPage.Location = new System.Drawing.Point(74, 308);
			this.textBoxPage.Name = "textBoxPage";
			this.textBoxPage.Size = new System.Drawing.Size(35, 20);
			this.textBoxPage.TabIndex = 1;
			// 
			// labelPage
			// 
			this.labelPage.AutoSize = true;
			this.labelPage.Location = new System.Drawing.Point(13, 308);
			this.labelPage.Name = "labelPage";
			this.labelPage.Size = new System.Drawing.Size(55, 13);
			this.labelPage.TabIndex = 2;
			this.labelPage.Text = "Страница";
			// 
			// buttonTo
			// 
			this.buttonTo.Location = new System.Drawing.Point(135, 304);
			this.buttonTo.Name = "buttonTo";
			this.buttonTo.Size = new System.Drawing.Size(75, 23);
			this.buttonTo.TabIndex = 3;
			this.buttonTo.Text = "Перейти";
			this.buttonTo.UseVisualStyleBackColor = true;
			this.buttonTo.Click += new System.EventHandler(this.buttonTo_Click);
			// 
			// FormMessages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(533, 351);
			this.Controls.Add(this.buttonTo);
			this.Controls.Add(this.labelPage);
			this.Controls.Add(this.textBoxPage);
			this.Controls.Add(this.dataGridView);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormMessages";
			this.Text = "Письма";
			this.Load += new System.EventHandler(this.FormMessages_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.TextBox textBoxPage;
		private System.Windows.Forms.Label labelPage;
		private System.Windows.Forms.Button buttonTo;
	}
}