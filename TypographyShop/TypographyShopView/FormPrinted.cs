﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.ViewModels;
using Unity;
namespace TypographyShopView
{
    public partial class FormPrinted : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly PrintedLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> printedComponents;
        public FormPrinted(PrintedLogic service)
        {
            InitializeComponent();
            logic = service;
        }
        private void FormPrinted_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PrintedViewModel view = logic.Read(new PrintedBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.PrintedName;
                        textBoxPrice.Text = view.Price.ToString();
                        printedComponents = view.PrintedComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                printedComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (printedComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in printedComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPrintedComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (printedComponents.ContainsKey(form.Id))
                {
                    printedComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    printedComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormPrintedComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = printedComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    printedComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        printedComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (printedComponents == null || printedComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new PrintedBindingModel
                {
                    Id = id,
                    PrintedName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    PrintedComponents = printedComponents
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