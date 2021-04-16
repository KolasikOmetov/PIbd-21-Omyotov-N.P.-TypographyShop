using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TypographyShopBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class PrintedBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string PrintedName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }
}
