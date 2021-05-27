using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using TypographyShopBusinessLogic.Attributes;
using TypographyShopBusinessLogic.Enums;

namespace TypographyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? EmployeeId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int PrintedId { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", width: 150)]
        public string EmployeeFIO { get; set; }
        [Column(title: "Клиент", width: 150, alignment: DataGridViewContentAlignment.BottomRight)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Изделие", width: 150)]
        [DataMember]
        public string PrintedName { get; set; }
        [Column(title: "Количество", width: 100, alignment: DataGridViewContentAlignment.BottomRight)]
        [DataMember]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 50, alignment: DataGridViewContentAlignment.BottomRight, readOnly: false)]
        [DataMember]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создания", width: 100, dateType: "d M y" )]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 100)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}
