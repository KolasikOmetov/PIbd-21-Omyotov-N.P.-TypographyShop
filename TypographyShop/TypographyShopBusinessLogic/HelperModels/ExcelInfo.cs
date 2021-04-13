using System.Collections.Generic;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPrintedComponentViewModel> PrintedComponents { get; set; }
    }
}
