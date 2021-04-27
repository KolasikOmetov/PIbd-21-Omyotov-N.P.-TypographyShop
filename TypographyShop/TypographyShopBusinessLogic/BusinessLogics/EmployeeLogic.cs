using System;
using System.Collections.Generic;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.BusinessLogics
{
    public class EmployeeLogic
    {
        private readonly IEmployeeStorage _clientStorage;

        public EmployeeLogic(IEmployeeStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return _clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { _clientStorage.GetElement(model) };
            }
            return _clientStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var element = _clientStorage.GetElement(new EmployeeBindingModel
            {
                EmployeeFIO = model.EmployeeFIO
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть работник с таким ФИО");
            }
            if (model.Id.HasValue)
            {
                _clientStorage.Update(model);
            }
            else
            {
                _clientStorage.Insert(model);
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            var element = _clientStorage.GetElement(new EmployeeBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Работник не найден");
            }
            _clientStorage.Delete(model);
        }
    }
}
