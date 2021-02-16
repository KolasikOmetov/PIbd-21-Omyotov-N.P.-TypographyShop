using System.Collections.Generic;

namespace TypographyShopBusinessLogic.BindingModels
{
	/// <summary>
	/// Изделие, изготавливаемое в магазине
	/// </summary>
	public class PrintedBindingModel
	{
		public int? Id { get; set; }
		public string PrintedName { get; set; }
		public decimal Price { get; set; }
		public Dictionary<int, (string, int)> PrintedComponents { get; set; }
	}
}
