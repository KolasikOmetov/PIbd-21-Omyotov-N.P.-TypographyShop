namespace TypographyShopView
{
	partial class FormCreateOrder
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.comboBoxPrinted = new System.Windows.Forms.ComboBox();
            this.labelPrinted = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(357, 229);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(236, 229);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 35);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Enabled = false;
            this.textBoxSum.Location = new System.Drawing.Point(143, 168);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(325, 26);
            this.textBoxSum.TabIndex = 20;
            this.textBoxSum.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(19, 172);
            this.labelSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(58, 20);
            this.labelSum.TabIndex = 19;
            this.labelSum.Text = "Сумма";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(144, 115);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(324, 26);
            this.textBoxCount.TabIndex = 18;
            this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(20, 118);
            this.labelCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(100, 20);
            this.labelCount.TabIndex = 17;
            this.labelCount.Text = "Количество";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(20, 23);
            this.labelClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(65, 20);
            this.labelClient.TabIndex = 22;
            this.labelClient.Text = "Клиент";
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(144, 18);
            this.comboBoxClient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(325, 28);
            this.comboBoxClient.TabIndex = 21;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPrinted_SelectedIndexChanged);
            // 
            // comboBoxPrinted
            // 
            this.comboBoxPrinted.FormattingEnabled = true;
            this.comboBoxPrinted.Location = new System.Drawing.Point(144, 66);
            this.comboBoxPrinted.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPrinted.Name = "comboBoxPrinted";
            this.comboBoxPrinted.Size = new System.Drawing.Size(325, 28);
            this.comboBoxPrinted.TabIndex = 21;
            this.comboBoxPrinted.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPrinted_SelectedIndexChanged);
            // 
            // labelPrinted
            // 
            this.labelPrinted.AutoSize = true;
            this.labelPrinted.Location = new System.Drawing.Point(20, 74);
            this.labelPrinted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrinted.Name = "labelPrinted";
            this.labelPrinted.Size = new System.Drawing.Size(76, 20);
            this.labelPrinted.TabIndex = 22;
            this.labelPrinted.Text = "Изделие";
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 308);
            this.Controls.Add(this.labelPrinted);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.comboBoxPrinted);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TextBox textBoxSum;
		private System.Windows.Forms.Label labelSum;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.Label labelClient;
		private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.ComboBox comboBoxPrinted;
        private System.Windows.Forms.Label labelPrinted;
    }
}