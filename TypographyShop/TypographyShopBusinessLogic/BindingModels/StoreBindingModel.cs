using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TypographyShopBusinessLogic.BindingModels
{
    [DataContract]
    public class StoreBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string StoreName { get; set; }
        [DataMember]
        public string ResponsibleName { get; set; }
        [DataMember]
        public DateTime DateCreation { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> StoreComponents { get; set; }
    }
}
