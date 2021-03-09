﻿using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace TypographyShopBusinessLogic.Interfaces
{
	public interface IStoreStorage
	{

		List<StoreViewModel> GetFullList();
		List<StoreViewModel> GetFilteredList(StoreBindingModel model);
		StoreViewModel GetElement(StoreBindingModel model);
		void Insert(StoreBindingModel model);
		void Update(StoreBindingModel model);
		void Delete(StoreBindingModel model);
	}
}
