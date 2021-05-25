using System;
using System.Collections.Generic;
using System.Text;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.HelperModels
{
    class StoresExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportStoreComponentViewModel> StoreComponents { get; set; }
    }
}
