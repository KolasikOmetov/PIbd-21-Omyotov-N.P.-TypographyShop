using System.Collections.Generic;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<PrintedViewModel> Printeds { get; set; }
    }
}
