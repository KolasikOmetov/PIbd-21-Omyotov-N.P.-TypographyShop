﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.HelperModels;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IPrintedStorage _printedStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStoreStorage _storeStorage;
        public ReportLogic(IPrintedStorage printedStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IStoreStorage storeStorage)
        {
            _printedStorage = printedStorage;
            _orderStorage = orderStorage;
            _storeStorage = storeStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportPrintedComponentViewModel> GetPrintedComponent()
        {
            var printeds = _printedStorage.GetFullList();
            var list = new List<ReportPrintedComponentViewModel>();
            foreach (var printed in printeds)
            {
                var record = new ReportPrintedComponentViewModel
                {
                    PrintedName = printed.PrintedName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in printed.PrintedComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportStoreComponentViewModel> GetStoreComponent()
        {
            var stores = _storeStorage.GetFullList();
            var list = new List<ReportStoreComponentViewModel>();
            foreach (var store in stores)
            {
                var record = new ReportStoreComponentViewModel
                {
                    StoreName = store.StoreName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in store.StoreComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PrintedName = x.PrintedName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        public List<OrderReportByDateViewModel> GetOrderReportByDate()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new OrderReportByDateViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Printeds = _printedStorage.GetFullList()
            });
        }

        public void SaveStoresToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateStoresDoc(new StoreWordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Stores = _storeStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SavePrintedComponentToExcelFile(ReportBindingModel model)
        {
            MethodInfo getPrintedComponent = GetType().GetMethod("GetPrintedComponent");
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                PrintedComponents = getPrintedComponent.Invoke(this, new object[0]) as List<ReportPrintedComponentViewModel>
            });
        }
        
        public void SaveStoreComponentToExcelFile(ReportBindingModel model)
        {
            MethodInfo getStoreComponent = GetType().GetMethod("GetStoreComponent");
            SaveToExcel.CreateStoresDoc(new StoresExcelInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                StoreComponents = getStoreComponent.Invoke(this, new object[0]) as List<ReportStoreComponentViewModel>
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            MethodInfo getOrders = GetType().GetMethod("GetOrders");
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = getOrders.Invoke(this, new object[] { model }) as List<ReportOrdersViewModel>
            });
        }

        [Obsolete]
        public void SaveOrderReportByDateToPdfFile(ReportBindingModel model)
        {
            MethodInfo getOrderReportByDate = GetType().GetMethod("GetOrderReportByDate");
            SaveToPdf.CreateDocOrderReportByDate(new PdfInfoOrderReportByDate
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = getOrderReportByDate.Invoke(this, new object[0]) as List<OrderReportByDateViewModel>
            });
        }
    }
}
