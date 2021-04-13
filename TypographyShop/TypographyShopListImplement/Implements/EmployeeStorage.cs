using System;
using System.Collections.Generic;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopBusinessLogic.ViewModels;
using TypographyShopListImplement.Models;

namespace TypographyShopListImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private readonly DataListSingleton source;

        public EmployeeStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<EmployeeViewModel> GetFullList()
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            foreach (var employee in source.Employees)
            {
                result.Add(CreateModel(employee));
            }
            return result;
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            foreach (var employee in source.Employees)
            {
                if (employee.EmployeeFIO.Contains(model.EmployeeFIO))
                {
                    result.Add(CreateModel(employee));
                }
            }
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var employee in source.Employees)
            {
                if (employee.Id == model.Id)
                {
                    return CreateModel(employee);
                }
            }
            return null;
        }

        public void Insert(EmployeeBindingModel model)
        {
            Employee tempEmployee = new Employee { Id = 1 };
            foreach (var employee in source.Employees)
            {
                if (employee.Id >= tempEmployee.Id)
                {
                    tempEmployee.Id = employee.Id + 1;
                }
            }
            source.Employees.Add(CreateModel(model, tempEmployee));
        }

        public void Update(EmployeeBindingModel model)
        {
            Employee tempEmployee = null;
            foreach (var employee in source.Employees)
            {
                if (employee.Id == model.Id)
                {
                    tempEmployee = employee;
                }
            }
            if (tempEmployee == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempEmployee);
        }

        public void Delete(EmployeeBindingModel model)
        {
            for (int i = 0; i < source.Employees.Count; ++i)
            {
                if (source.Employees[i].Id == model.Id.Value)
                {
                    source.Employees.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private Employee CreateModel(EmployeeBindingModel model, Employee employee)
        {
            employee.EmployeeFIO = model.EmployeeFIO;
            employee.PauseTime = model.PauseTime;
            employee.WorkingTime = model.WorkingTime;
            return employee;
        }

        private EmployeeViewModel CreateModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeFIO = employee.EmployeeFIO,
                PauseTime = employee.PauseTime,
                WorkingTime = employee.WorkingTime
            };
        }
    }
}
