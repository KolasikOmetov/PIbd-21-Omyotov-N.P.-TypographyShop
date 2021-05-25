﻿using System.Collections.Generic;
using TypographyShopListImplement.Models;
namespace TypographyShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Printed> Printeds { get; set; }
        public List<Client> Clients { get; set; }
        public List<Employee> Employees { get; set; }
        public List<MessageInfo> Messages { get; set; }
        public List<Store> Stores { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Printeds = new List<Printed>();
            Clients = new List<Client>();
            Employees = new List<Employee>();
            Messages = new List<MessageInfo>();
            Stores = new List<Store>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}