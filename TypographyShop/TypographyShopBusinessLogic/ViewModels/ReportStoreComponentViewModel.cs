using System;
using System.Collections.Generic;

namespace TypographyShopBusinessLogic.ViewModels
{
    public class ReportStoreComponentViewModel
    {
        public string StoreName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
