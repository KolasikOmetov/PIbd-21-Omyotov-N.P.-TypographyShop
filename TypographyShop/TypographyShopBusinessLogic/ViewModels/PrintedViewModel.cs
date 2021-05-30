using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using TypographyShopBusinessLogic.Attributes;

namespace TypographyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class PrintedViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PrintedName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 50)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }
}