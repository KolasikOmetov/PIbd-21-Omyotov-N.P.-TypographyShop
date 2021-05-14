﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TypographyShopBusinessLogic.Enums;
using TypographyShopFileImplement.Models;

namespace TypographyShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PrintedFileName = "Printed.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string EmployeeFileName = "Employee.xml";
        private readonly string MessageFileName = "Message.xml";
		private readonly string StoreFileName = "Store.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Printed> Printeds { get; set; }
        public List<Client> Clients { get; set; }
        public List<Employee> Employees { get; set; }
        public List<MessageInfo> Messages { get; set; }
		public List<Store> Stores { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Printeds = LoadPrinteds();
            Clients = LoadClients();
            Employees = LoadEmployees();
            Messages = LoadMessages();
			Stores = LoadStores();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SavePrinteds();
            SaveClients();
            SaveEmployees();
            SaveMessages();
			SaveStores();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedId = Convert.ToInt32(elem.Element("PrintedId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        EmployeeId = Convert.ToInt32(elem.Element("EmployeeId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Convert.ToInt32(elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate")?.Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? DateTime.MinValue : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }
        private List<Printed> LoadPrinteds()
        {
            var list = new List<Printed>();
            if (File.Exists(PrintedFileName))
            {
                XDocument xDocument = XDocument.Load(PrintedFileName);
                var xElements = xDocument.Root.Elements("Printed").ToList();
                foreach (var elem in xElements)
                {
                    var prodComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("PrintedComponents").Elements("PrintedComponent").ToList())
                    {
                        prodComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Printed
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedName = elem.Element("PrintedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PrintedComponents = prodComp
                    });
                }
            }
            return list;
        }
		
		private List<Store> LoadStores()
		{
			var list = new List<Store>();
			if (File.Exists(StoreFileName))
			{
				XDocument xDocument = XDocument.Load(StoreFileName);
				var xElements = xDocument.Root.Elements("Store").ToList();
				foreach (var elem in xElements)
				{
					var storeComponents = new Dictionary<int, (string, int)>();
					foreach (var component in elem.Element("StoreComponents").Elements("StoreComponent").ToList())
					{
						var componentData = (component.Element("Component").Element("Name").Value, Convert.ToInt32(component.Element("Component").Element("Count").Value));
						storeComponents.Add(Convert.ToInt32(component.Element("Key").Value), componentData);
					}
					list.Add(new Store
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						StoreName = elem.Element("StoreName").Value,
						ResponsibleName = elem.Element("ResponsibleName").Value,
						DateCreation = Convert.ToDateTime(elem.Element("DateCreation").Value),
						StoreComponents = storeComponents
					});
				}
			}
			return list;
		}
		
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value,
                    });
                }
            }
            return list;
        }
        private List<Employee> LoadEmployees()
        {
            var list = new List<Employee>();
            if (File.Exists(EmployeeFileName))
            {
                XDocument xDocument = XDocument.Load(EmployeeFileName);
                var xElements = xDocument.Root.Elements("Employee").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Employee
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EmployeeFIO = elem.Element("EmployeeFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Attribute("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Attribute("PauseTime").Value),
                    });
                }
            }
            return list;
        }

        private List<MessageInfo> LoadMessages()
        {
            var list = new List<MessageInfo>();
            if (File.Exists(MessageFileName))
            {
                XDocument xDocument = XDocument.Load(MessageFileName);
                var xElements = xDocument.Root.Elements("Message").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        SenderName = elem.Element("SenderName").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery")?.Value),
                        Subject = elem.Element("Subject").Value,
                        Body = elem.Element("Body").Value,
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PrintedId", order.PrintedId),
                    new XElement("ClientId", order.ClientId),
                    new XElement("EmployeeId", order.EmployeeId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", (int)order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SavePrinteds()
        {
            if (Printeds != null)
            {
                var xElement = new XElement("Printeds");
                foreach (var Printed in Printeds)
                {
                    var compElement = new XElement("PrintedComponents");
                    foreach (var component in Printed.PrintedComponents)
                    {
                        compElement.Add(new XElement("PrintedComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Printed",
                    new XAttribute("Id", Printed.Id),
                    new XElement("PrintedName", Printed.PrintedName),
                    new XElement("Price", Printed.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PrintedFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveEmployees()
        {
            if (Employees != null)
            {
                var xElement = new XElement("Employees");
                foreach (var employee in Employees)
                {
                    xElement.Add(new XElement("Employee",
                    new XAttribute("Id", employee.Id),
                    new XElement("EmployeeFIO", employee.EmployeeFIO),
                    new XElement("WorkingTime", employee.WorkingTime),
                    new XElement("PauseTime", employee.PauseTime)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(EmployeeFileName);
            }
        }
        private void SaveMessages()
        {
            if (Messages != null)
            {
                var xElement = new XElement("Messages");
                foreach (var message in Messages)
                {
                    xElement.Add(new XElement("Message",
                    new XAttribute("MessageId", message.MessageId),
                    new XElement("ClientId", message.ClientId),
                    new XElement("SenderName", message.SenderName),
                    new XElement("DateDelivery", message.DateDelivery),
                    new XElement("Subject", message.Subject),
                    new XElement("Body", message.Body)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageFileName);
            }
        }

		private void SaveStores()
		{
			if (Stores != null)
			{
				var xElement = new XElement("Stores");
				foreach (var store in Stores)
				{
					var compElement = new XElement("StoreComponents");
					foreach (var component in store.StoreComponents)
					{
						var element = new XElement("Component");
						element.Add(
							new XElement("Name", component.Value.Item1), new XElement("Count", component.Value.Item2)
							);
						compElement.Add(new XElement("StoreComponent",
						new XElement("Key", component.Key),
						element));
					}
					xElement.Add(new XElement("Store",
					new XAttribute("Id", store.Id),
					new XElement("StoreName", store.StoreName),
					new XElement("ResponsibleName", store.ResponsibleName),
					new XElement("DateCreation", store.DateCreation),
					compElement));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(StoreFileName);
			}
		}
    }
}