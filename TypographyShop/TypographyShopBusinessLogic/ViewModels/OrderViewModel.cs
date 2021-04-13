﻿using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using TypographyShopBusinessLogic.Enums;

namespace TypographyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PrintedId { get; set; }
        [DataMember]
        [DisplayName("ФИО Работника")]
        public string EmployeeFIO { get; set; }
        [DataMember]
        [DisplayName("ФИО Клиента")]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("Изделие")]
        public string PrintedName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
