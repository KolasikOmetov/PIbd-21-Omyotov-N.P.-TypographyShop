using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.ViewModels;
using Unity;

namespace TypographyShopView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly PrintedLogic _logicP;
        private readonly OrderLogic _logicO;
        private readonly ClientLogic _logicC;
        public FormCreateOrder(PrintedLogic logicP, OrderLogic logicO, ClientLogic logicC)
        {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
            _logicC = logicC;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<PrintedViewModel> listPrinteds = _logicP.Read(null);
                if (listPrinteds != null)
                {
                    comboBoxPrinted.DisplayMember = "PrintedName";
                    comboBoxPrinted.ValueMember = "Id";
                    comboBoxPrinted.DataSource = listPrinteds;
                    comboBoxPrinted.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список изделий");
                }
                List<ClientViewModel> listClients = _logicC.Read(null);
                if (listClients != null)
                {
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listClients;
                    comboBoxClient.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список клиентов");
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
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    PrintedId = Convert.ToInt32(comboBoxPrinted.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
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
