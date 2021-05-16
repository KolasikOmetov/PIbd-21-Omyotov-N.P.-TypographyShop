using System;
using System.Collections.Generic;
using System.Linq;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopBusinessLogic.ViewModels;
using TypographyShopFileImplement.Models;

namespace TypographyShopFileImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private readonly FileDataListSingleton source;
        public EmployeeStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<EmployeeViewModel> GetFullList()
        {
            return source.Employees
            .Select(CreateModel)
            .ToList();
        }
        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Employees
            .Where(rec => rec.EmployeeFIO.Contains(model.EmployeeFIO))
            .Select(CreateModel)
            .ToList();
        }
        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var employee = source.Employees
            .FirstOrDefault(rec => rec.Id == model.Id);
            return employee != null ? CreateModel(employee) : null;
        }
        public void Insert(EmployeeBindingModel model)
        {
            int maxId = source.Employees.Count > 0 ? source.Employees.Max(rec => rec.Id) : 0;
            var element = new Employee { Id = maxId + 1 };
            source.Employees.Add(CreateModel(model, element));
        }
        public void Update(EmployeeBindingModel model)
        {
            var element = source.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(EmployeeBindingModel model)
        {
            Employee element = source.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Employees.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Employee CreateModel(EmployeeBindingModel model, Employee employee)
        {
            employee.EmployeeFIO = model.EmployeeFIO;
            employee.WorkingTime = model.WorkingTime;
            employee.PauseTime = model.PauseTime;
            return employee;
        }

        private EmployeeViewModel CreateModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeFIO = employee.EmployeeFIO,
                WorkingTime = employee.WorkingTime,
                PauseTime = employee.PauseTime
            };
        }
    }
}
