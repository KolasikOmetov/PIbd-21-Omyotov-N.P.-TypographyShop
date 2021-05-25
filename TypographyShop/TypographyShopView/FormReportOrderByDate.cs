﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.ViewModels;
using Unity;

namespace TypographyShopView
{
    public partial class FormReportOrderByDate : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportOrderByDate(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriodicByDate",
                "c " + dateTimePickerFrom.Value.ToShortDateString() +
                " по " + dateTimePickerTo.Value.ToShortDateString());
                reportViewer.LocalReport.SetParameters(parameter);

                MethodInfo getOrderReportByDate = logic.GetType().GetMethod("GetOrderReportByDate");
                var dataSource = getOrderReportByDate.Invoke(logic, new object[0]) as List<OrderReportByDateViewModel>;
                ReportDataSource source = new ReportDataSource("DataSetOrdersByDate", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MethodInfo saveOrderReportByDateToPdfFile = logic.GetType().GetMethod("SaveOrderReportByDateToPdfFile");
                        saveOrderReportByDateToPdfFile.Invoke(logic, new object[] { 
                            new ReportBindingModel { FileName = dialog.FileName,
                            DateFrom = dateTimePickerFrom.Value,
                            DateTo = dateTimePickerTo.Value 
                            } 
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
