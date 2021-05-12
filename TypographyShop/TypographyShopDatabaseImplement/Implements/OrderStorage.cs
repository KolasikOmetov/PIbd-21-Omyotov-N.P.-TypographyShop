using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.Enums;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopBusinessLogic.ViewModels;
using TypographyShopDatabaseImplement.Models;

namespace TypographyShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new TypographyShopDatabase())
            {
                return context.Orders.Include(rec => rec.Printed).Include(rec => rec.Client).Include(rec => rec.Employee).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    PrintedId = rec.PrintedId,
                    ClientId = rec.ClientId,
                    EmployeeId = rec.EmployeeId,
                    PrintedName = rec.Printed.PrintedName,
                    ClientFIO = rec.Client.ClientFIO,
                    EmployeeFIO = rec.EmployeeId.HasValue ? rec.Employee.EmployeeFIO : string.Empty,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                }).ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TypographyShopDatabase())
            {
                return context.Orders.Include(rec => rec.Printed).Include(rec => rec.Client).Include(rec => rec.Employee).Where(rec => (model.Status == OrderStatus.Требуются_материалы && rec.Status == OrderStatus.Требуются_материалы) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) || (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status == OrderStatus.Принят) || (model.EmployeeId.HasValue && rec.EmployeeId == model.EmployeeId && rec.Status == OrderStatus.Выполняется)).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    PrintedId = rec.PrintedId,
                    ClientId = rec.ClientId,
                    EmployeeId = rec.EmployeeId,
                    PrintedName = rec.Printed.PrintedName,
                    ClientFIO = rec.Client.ClientFIO,
                    EmployeeFIO = rec.EmployeeId.HasValue ? rec.Employee.EmployeeFIO : string.Empty,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                }).ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TypographyShopDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ? new OrderViewModel
                {
                    Id = order.Id,
                    PrintedId = order.PrintedId,
                    ClientId = order.ClientId,
                    EmployeeId = order.EmployeeId,
                    PrintedName = context.Printeds.Include(pr => pr.Orders).FirstOrDefault(rec => rec.Id == order.PrintedId)?.PrintedName,
                    ClientFIO = context.Clients.Include(pr => pr.Order).FirstOrDefault(rec => rec.Id == order.ClientId)?.ClientFIO,
                    EmployeeFIO = order.Employee?.EmployeeFIO,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } : null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new TypographyShopDatabase())
            {
                if (model.ClientId.HasValue == false)
                {
                    throw new Exception("Клиент не указан");
                }
                Order order = new Order
                {
                    PrintedId = model.PrintedId,
                    ClientId = (int)model.ClientId,
                    EmployeeId = model.EmployeeId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new TypographyShopDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.PrintedId = model.PrintedId;
                element.ClientId = (int)model.ClientId;
                element.EmployeeId = model.EmployeeId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new TypographyShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TypographyShopDatabase())
            {
                Printed printed = context.Printeds.FirstOrDefault(rec => rec.Id == model.PrintedId);
                if (printed != null)
                {
                    if (printed.Orders == null)
                    {
                        printed.Orders = new List<Order>();
                    }
                    printed.Orders.Add(order);
                    context.Printeds.Update(printed);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Изделие не найден");
                }
                Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.ClientId);
                if (client != null)
                {
                    if (client.Order == null)
                    {
                        client.Order = new List<Order>();
                    }
                    client.Order.Add(order);
                    context.Clients.Update(client);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
                Employee employee = context.Employees.FirstOrDefault(rec => rec.Id == model.EmployeeId);
                if (employee != null)
                {
                    if (employee.Order == null)
                    {
                        employee.Order = new List<Order>();
                    }
                    employee.Order.Add(order);
                    context.Employees.Update(employee);
                    context.SaveChanges();
                }
            }
            return order;
        }
    }
}