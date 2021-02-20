using System;
using System.Collections.Generic;
using System.Text;

namespace TypographyShopBusinessLogic.BindingModels
{
	/// <summary>
	/// Данные от клиента, для создания заказа
	/// </summary>
	public class CreateOrderBindingModel
	{
		public int PrintedId { get; set; }
		public int Count { get; set; }
		public decimal Sum { get; set; }
	}
}
