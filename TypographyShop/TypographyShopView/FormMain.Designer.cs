namespace TypographyShopView
{
	partial class FormMain
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
            this.menuStripTypography = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOrderPaid = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonRefreshList = new System.Windows.Forms.Button();
            this.menuStripTypography.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripTypography
            // 
            this.menuStripTypography.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripTypography.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнениеСкладаToolStripMenuItem});
            this.menuStripTypography.Location = new System.Drawing.Point(0, 0);
            this.menuStripTypography.Name = "menuStripTypography";
            this.menuStripTypography.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStripTypography.Size = new System.Drawing.Size(1101, 35);
            this.menuStripTypography.TabIndex = 0;
            this.menuStripTypography.Text = "menuStripTypography";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(139, 29);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.КомпонентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.ИзделияToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.СкладыToolStripMenuItem_Click);
            // 
            // пополнениеСкладаToolStripMenuItem
            // 
            this.пополнениеСкладаToolStripMenuItem.Name = "пополнениеСкладаToolStripMenuItem";
            this.пополнениеСкладаToolStripMenuItem.Size = new System.Drawing.Size(189, 29);
            this.пополнениеСкладаToolStripMenuItem.Text = "Пополнение склада";
            this.пополнениеСкладаToolStripMenuItem.Click += new System.EventHandler(this.ПополнениеСкладаToolStripMenuItem_Click);
            // 
            // buttonOrderPaid
            // 
            this.buttonOrderPaid.Location = new System.Drawing.Point(790, 449);
            this.buttonOrderPaid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOrderPaid.Name = "buttonOrderPaid";
            this.buttonOrderPaid.Size = new System.Drawing.Size(278, 35);
            this.buttonOrderPaid.TabIndex = 9;
            this.buttonOrderPaid.Text = "Заказ оплачен";
            this.buttonOrderPaid.UseVisualStyleBackColor = true;
            this.buttonOrderPaid.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(790, 308);
            this.buttonOrderReady.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(278, 35);
            this.buttonOrderReady.TabIndex = 8;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(790, 175);
            this.buttonTakeOrderInWork.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(278, 35);
            this.buttonTakeOrderInWork.TabIndex = 7;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(790, 60);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(278, 35);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "Создать заказ";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView.Location = new System.Drawing.Point(0, 42);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(753, 580);
            this.dataGridView.TabIndex = 5;
            // 
            // buttonRefreshList
            // 
            this.buttonRefreshList.Location = new System.Drawing.Point(790, 572);
            this.buttonRefreshList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRefreshList.Name = "buttonRefreshList";
            this.buttonRefreshList.Size = new System.Drawing.Size(278, 35);
            this.buttonRefreshList.TabIndex = 9;
            this.buttonRefreshList.Text = "Обновить список";
            this.buttonRefreshList.UseVisualStyleBackColor = true;
            this.buttonRefreshList.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 626);
            this.Controls.Add(this.buttonRefreshList);
            this.Controls.Add(this.buttonOrderPaid);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStripTypography);
            this.MainMenuStrip = this.menuStripTypography;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Типография";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripTypography.ResumeLayout(false);
            this.menuStripTypography.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStripTypography;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
		private System.Windows.Forms.Button buttonOrderPaid;
		private System.Windows.Forms.Button buttonOrderReady;
		private System.Windows.Forms.Button buttonTakeOrderInWork;
		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonRefreshList;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнениеСкладаToolStripMenuItem;
    }
}