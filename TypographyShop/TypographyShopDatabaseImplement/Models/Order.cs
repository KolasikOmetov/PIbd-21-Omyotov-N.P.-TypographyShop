using System;
using System.ComponentModel.DataAnnotations;
using TypographyShopBusinessLogic.Enums;

namespace TypographyShopDatabaseImplement.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int PrintedId { get; set; }
        public virtual Printed Printed { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
