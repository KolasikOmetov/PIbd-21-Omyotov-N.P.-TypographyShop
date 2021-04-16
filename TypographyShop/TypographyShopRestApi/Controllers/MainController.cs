using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly PrintedLogic _printed;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, PrintedLogic printed, OrderLogic main)
        {
            _order = order;
            _printed = printed;
            _main = main;
        }
        [HttpGet]
        public List<PrintedViewModel> GetPrintedList() => _printed.Read(null)?.ToList();
        [HttpGet]
        public PrintedViewModel GetPrinted(int printedId) => _printed.Read(new PrintedBindingModel { Id = printedId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
