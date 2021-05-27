using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.ViewModels;
using TypographyShopStoreApp.Models;

namespace TypographyShopStoreApp.Controllers
{
	public class HomeController : Controller
	{
		public HomeController()
		{
		}
		public IActionResult Index()
		{
			if (!Program.IsLogged)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIStore.GetRequest<List<StoreViewModel>>("api/store/getstorelist"));
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult Enter()
		{
			return View();
		}

		[HttpPost]
		public void Enter(string password)
		{
			if (!string.IsNullOrEmpty(password))
			{
				if (password != Program.Password)
				{
					throw new Exception("Неверный пароль");
				}
				Program.IsLogged = true;
				Response.Redirect("Index");
				return;
			}
			throw new Exception("Введите пароль");
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public void Add(string name, string responsibleName)
		{
			if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsibleName))
			{
				APIStore.PostRequest("api/store/CreateOrUpdate", new StoreBindingModel
				{
					ResponsibleName = responsibleName,
					StoreName = name,
					DateCreation = DateTime.Now,
					StoreComponents = new Dictionary<int, (string, int)>()
				});
				Response.Redirect("Index");
				return;
			}
			throw new Exception("Поля должны быть заполнены");
		}

		[HttpGet]
		public IActionResult Update(int storeId)
		{
			var store = APIStore.GetRequest<StoreViewModel>($"api/store/getstore?storeId={storeId}");
			ViewBag.Components = store.StoreComponents.Values;
			ViewBag.Name = store.StoreName;
			ViewBag.ResponsibleName = store.ResponsibleName;
			return View();
		}

		[HttpPost]
		public void Update(int storeId, string name, string responsibleName)
		{
			if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsibleName))
			{
				var store = APIStore.GetRequest<StoreViewModel>($"api/store/getstore?storeid={storeId}");
				if (store == null)
				{
					return;
				}
				APIStore.PostRequest("api/store/CreateOrUpdate", new StoreBindingModel
				{
					ResponsibleName = responsibleName,
					StoreName = name,
					DateCreation = DateTime.Now,
					StoreComponents = store.StoreComponents,
					Id = store.Id
				});
				Response.Redirect("Index");
				return;
			}
			throw new Exception("Введите логин, пароль и ФИО");
		}

		[HttpGet]
		public IActionResult Delete()
		{
			if (!Program.IsLogged)
			{
				return Redirect("~/Home/Enter");
			}
			ViewBag.Store = APIStore.GetRequest<List<StoreViewModel>>("api/store/getstorelist");
			return View();
		}

		[HttpPost]
		public void Delete(int storeId)
		{
			APIStore.PostRequest("api/store/delete", new StoreBindingModel
			{
				Id = storeId
			});
			Response.Redirect("Index");
		}

		[HttpGet]
		public IActionResult Fill()
		{
			if (!Program.IsLogged)
			{
				return Redirect("~/Home/Enter");
			}
			ViewBag.Store = APIStore.GetRequest<List<StoreViewModel>>("api/store/getstorelist");
			ViewBag.Component = APIStore.GetRequest<List<ComponentViewModel>>("api/store/getcomponentlist");
			return View();
		}

		[HttpPost]
		public void Fill(int storeId, int componentId, int count)
		{
			APIStore.PostRequest("api/store/fill", new StoreFillBindingModel
			{
				Model = new StoreBindingModel { Id = storeId },
				ComponentId = componentId,
				Count = count
			});
			Response.Redirect("Fill");
		}
	}
}
