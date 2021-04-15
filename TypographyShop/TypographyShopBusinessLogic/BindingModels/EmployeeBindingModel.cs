namespace TypographyShopBusinessLogic.BindingModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class EmployeeBindingModel
    {
        public int? Id { get; set; }
        public string EmployeeFIO { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
