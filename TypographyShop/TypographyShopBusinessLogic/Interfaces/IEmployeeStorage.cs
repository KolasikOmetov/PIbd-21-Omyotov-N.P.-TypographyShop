using System;
using System.Collections.Generic;
using System.Text;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.Interfaces
{
    public interface IEmployeeStorage
    {
        List<EmployeeViewModel> GetFullList();
        List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model);
        EmployeeViewModel GetElement(EmployeeBindingModel model);
        void Insert(EmployeeBindingModel model);
        void Update(EmployeeBindingModel model);
        void Delete(EmployeeBindingModel model);
    }
}
