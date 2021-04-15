using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopBusinessLogic.ViewModels;
using TypographyShopDatabaseImplement.Models;

namespace TypographyShopDatabaseImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using (var context = new TypographyShopDatabase())
            {
                return context.Employees.Select(rec => new EmployeeViewModel
                {
                    Id = rec.Id,
                    EmployeeFIO = rec.EmployeeFIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime,
                })
                .ToList();
            }
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TypographyShopDatabase())
            {
                return context.Employees
                .Where(rec => rec.EmployeeFIO.Contains(model.EmployeeFIO))
                .Select(rec => new EmployeeViewModel
                {
                    Id = rec.Id,
                    EmployeeFIO = rec.EmployeeFIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime,
                })
                .ToList();
            }
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TypographyShopDatabase())
            {
                var employee = context.Employees
                .FirstOrDefault(rec => rec.EmployeeFIO == model.EmployeeFIO ||
                rec.Id == model.Id);
                return employee != null ?
                new EmployeeViewModel
                {
                    Id = employee.Id,
                    EmployeeFIO = employee.EmployeeFIO,
                    WorkingTime = employee.WorkingTime,
                    PauseTime = employee.PauseTime,
                } :
                null;
            }
        }

        public void Insert(EmployeeBindingModel model)
        {
            using (var context = new TypographyShopDatabase())
            {
                context.Employees.Add(CreateModel(model, new Employee(), context));
                context.SaveChanges();
            }
        }

        public void Update(EmployeeBindingModel model)
        {
            using (var context = new TypographyShopDatabase())
            {
                var element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Работник не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            using (var context = new TypographyShopDatabase())
            {
                Employee element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Employees.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Работник не найден");
                }
            }
        }

        private Employee CreateModel(EmployeeBindingModel model, Employee employee, TypographyShopDatabase database)
        {
            employee.EmployeeFIO = model.EmployeeFIO;
            employee.WorkingTime = model.WorkingTime;
            employee.PauseTime = model.PauseTime;
            return employee;
        }
    }
}
