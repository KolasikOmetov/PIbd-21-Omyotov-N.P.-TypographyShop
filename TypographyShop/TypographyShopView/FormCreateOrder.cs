﻿using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using System.Collections.Generic;

namespace TypographyShopView
{
	public partial class FormCreateOrder : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }
		private readonly PrintedLogic _logicP;
		private readonly OrderLogic _logicO;
		public FormCreateOrder(PrintedLogic logicP, OrderLogic logicO)
		{
			InitializeComponent();
			_logicP = logicP;
			_logicO = logicO;
		}
		private void FormCreateOrder_Load(object sender, EventArgs e)
		{
			try
			{
				List<PrintedViewModel> list = _logicP.Read(null);
				if (list != null)
				{
					comboBoxPrinted.DisplayMember = "PrintedName";
					comboBoxPrinted.ValueMember = "Id";
					comboBoxPrinted.DataSource = list;
					comboBoxPrinted.SelectedItem = null;
				}
                else
                {
					throw new Exception("Не удалось загрузить список изделий");
                }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void CalcSum()
		{
			if (comboBoxPrinted.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
			{
				try
				{
					int id = Convert.ToInt32(comboBoxPrinted.SelectedValue);
					PrintedViewModel Printed = _logicP.Read(new PrintedBindingModel { Id = id })?[0];
					int count = Convert.ToInt32(textBoxCount.Text);
					textBoxSum.Text = (count * Printed?.Price ?? 0).ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void TextBoxCount_TextChanged(object sender, EventArgs e)
		{
			CalcSum();
		}
		private void ComboBoxPrinted_SelectedIndexChanged(object sender, EventArgs e)
		{
			CalcSum();
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxPrinted.SelectedValue == null)
			{
				MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				int count = Convert.ToInt32(textBoxCount.Text);
				if(count < 1)
                {
					throw new Exception("Количество должно быть натуральным числом");
                }
				_logicO.CreateOrder(new CreateOrderBindingModel
				{
					PrintedId = Convert.ToInt32(comboBoxPrinted.SelectedValue),
					Count = count,
					Sum = Convert.ToDecimal(textBoxSum.Text)
				});
				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
