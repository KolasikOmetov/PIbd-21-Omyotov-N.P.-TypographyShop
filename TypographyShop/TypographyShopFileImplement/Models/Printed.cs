using System.Collections.Generic;

namespace TypographyShopFileImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Printed
    {
        public int Id { get; set; }
        public string PrintedName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> PrintedComponents { get; set; }
    }
}