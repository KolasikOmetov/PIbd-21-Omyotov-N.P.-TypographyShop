using System;
using System.Runtime.Serialization;
using TypographyShopBusinessLogic.Enums;

namespace TypographyShopBusinessLogic.BindingModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public int? EmployeeId { get; set; }
        [DataMember]
        public int? ClientId { get; set; }
        [DataMember]
        public int PrintedId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public OrderStatus Status { get; set; }
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DataMember]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public DateTime? DateFrom { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
        [DataMember]
        public bool? FreeOrders { get; set; }
    }
}
