using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TypographyShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ReportPrintedComponentViewModel
    {
        [DataMember]
        public string PrintedName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public List<Tuple<string, int>> Components { get; set; }
    }
}
