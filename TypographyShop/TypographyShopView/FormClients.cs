using System;
using System.Windows.Forms;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.BusinessLogics;
using Unity;

namespace TypographyShopView
{
    public partial class FormClients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ClientLogic _clientLogic;
        public FormClients(ClientLogic clientLogic)
        {
            InitializeComponent();
            this._clientLogic = clientLogic;
        }
        private void FormClients_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _clientLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].Visible = false;
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
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _clientLogic.Delete(new ClientBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
