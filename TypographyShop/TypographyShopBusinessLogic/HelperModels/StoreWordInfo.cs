using System.Collections.Generic;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.HelperModels
{
    class StoreWordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<StoreViewModel> Stores { get; set; }
    }
}
