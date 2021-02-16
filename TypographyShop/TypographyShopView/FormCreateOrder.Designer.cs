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
			this.labelPrinted = new System.Windows.Forms.Label();
			this.comboBoxPrinted = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(239, 119);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 14;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(158, 119);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 13;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// textBoxSum
			// 
			this.textBoxSum.Enabled = false;
			this.textBoxSum.Location = new System.Drawing.Point(96, 79);
			this.textBoxSum.Name = "textBoxSum";
			this.textBoxSum.Size = new System.Drawing.Size(218, 20);
			this.textBoxSum.TabIndex = 20;
			this.textBoxSum.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
			// 
			// labelSum
			// 
			this.labelSum.AutoSize = true;
			this.labelSum.Location = new System.Drawing.Point(13, 82);
			this.labelSum.Name = "labelSum";
			this.labelSum.Size = new System.Drawing.Size(41, 13);
			this.labelSum.TabIndex = 19;
			this.labelSum.Text = "Сумма";
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(96, 44);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(218, 20);
			this.textBoxCount.TabIndex = 18;
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(12, 47);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(66, 13);
			this.labelCount.TabIndex = 17;
			this.labelCount.Text = "Количество";
			// 
			// labelPrinted
			// 
			this.labelPrinted.AutoSize = true;
			this.labelPrinted.Location = new System.Drawing.Point(13, 15);
			this.labelPrinted.Name = "labelPrinted";
			this.labelPrinted.Size = new System.Drawing.Size(51, 13);
			this.labelPrinted.TabIndex = 22;
			this.labelPrinted.Text = "Изделие";
			// 
			// comboBoxPrinted
			// 
			this.comboBoxPrinted.FormattingEnabled = true;
			this.comboBoxPrinted.Location = new System.Drawing.Point(96, 12);
			this.comboBoxPrinted.Name = "comboBoxPrinted";
			this.comboBoxPrinted.Size = new System.Drawing.Size(218, 21);
			this.comboBoxPrinted.TabIndex = 21;
			this.comboBoxPrinted.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPrinted_SelectedIndexChanged);
			// 
			// FormCreateOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 152);
			this.Controls.Add(this.labelPrinted);
			this.Controls.Add(this.comboBoxPrinted);
			this.Controls.Add(this.textBoxSum);
			this.Controls.Add(this.labelSum);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
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
		private System.Windows.Forms.Label labelPrinted;
		private System.Windows.Forms.ComboBox comboBoxPrinted;
	}
}