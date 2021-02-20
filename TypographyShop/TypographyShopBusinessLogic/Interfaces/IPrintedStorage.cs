using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace TypographyShopBusinessLogic.Interfaces
{
	public interface IPrintedStorage
	{
		List<PrintedViewModel> GetFullList();
		List<PrintedViewModel> GetFilteredList(PrintedBindingModel model);
		PrintedViewModel GetElement(PrintedBindingModel model);
		void Insert(PrintedBindingModel model);
		void Update(PrintedBindingModel model);
		void Delete(PrintedBindingModel model);
	}
}
