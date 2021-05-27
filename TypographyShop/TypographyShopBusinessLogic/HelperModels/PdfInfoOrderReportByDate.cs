using System.Collections.Generic;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.HelperModels
{
    class PdfInfoOrderReportByDate
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<OrderReportByDateViewModel> Orders { get; set; }
    }
}
