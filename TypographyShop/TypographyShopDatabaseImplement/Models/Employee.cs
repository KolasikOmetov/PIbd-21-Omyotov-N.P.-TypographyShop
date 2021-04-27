using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypographyShopDatabaseImplement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeFIO { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
        [ForeignKey("EmployeeId")]
        public List<Order> Order { get; set; }
    }
}
