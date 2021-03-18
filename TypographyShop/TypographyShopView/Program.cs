﻿using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopFileImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace TypographyShopView
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var container = BuildUnityContainer();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(container.Resolve<FormMain>());
		}
		private static IUnityContainer BuildUnityContainer()
		{
			var currentContainer = new UnityContainer();
			currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IPrintedStorage, PrintedStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<IStoreStorage, StoreStorage>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<PrintedLogic>(new HierarchicalLifetimeManager());
			currentContainer.RegisterType<StoreLogic>(new HierarchicalLifetimeManager());
			return currentContainer;
		}
	}
}
