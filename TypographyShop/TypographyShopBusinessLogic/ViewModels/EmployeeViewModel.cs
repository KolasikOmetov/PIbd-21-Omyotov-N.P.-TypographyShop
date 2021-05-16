using System.ComponentModel;

namespace TypographyShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО исполнителя")]
        public string EmployeeFIO { get; set; }
        [DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }
        [DisplayName("Время на перерыв")]
        public int PauseTime { get; set; }
    }
}
