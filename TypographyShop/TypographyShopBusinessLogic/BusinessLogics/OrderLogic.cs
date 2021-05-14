using System;
using System.Collections.Generic;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.Enums;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.BusinessLogics
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly object locker = new object();
        private readonly IStoreStorage _storeStorage;
        public OrderLogic(IOrderStorage orderStorage, IStoreStorage storeStorage)
        {
            _orderStorage = orderStorage;
            _storeStorage = storeStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                PrintedId = model.PrintedId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            
            lock (locker)
            {
                var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Требуются_материалы)
                {
                    throw new Exception("Заказ не принят в работу");
                }
                if (order.EmployeeId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                OrderBindingModel updatedOrderBindingModel = new OrderBindingModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    PrintedId = order.PrintedId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                };
                if (!_storeStorage.CheckPrintedsByComponents(order.PrintedId, order.Count))
                {
                    updatedOrderBindingModel.Status = OrderStatus.Требуются_материалы;
                }
                else
                {
                    updatedOrderBindingModel.DateImplement = DateTime.Now;
                    updatedOrderBindingModel.Status = OrderStatus.Выполняется;
                    updatedOrderBindingModel.EmployeeId = model.EmployeeId;
                }
                _orderStorage.Update(updatedOrderBindingModel);
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status == OrderStatus.Выполняется)
            {
                _orderStorage.Update(new OrderBindingModel
                {
                    Id = order.Id,
                    PrintedId = order.PrintedId,
                    EmployeeId = order.EmployeeId,
                    ClientId = order.ClientId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    Status = OrderStatus.Готов
                });
            }
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                PrintedId = order.PrintedId,
                ClientId = order.ClientId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}
