using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreLogic _logic;
        private readonly ComponentLogic _componentLogic;
        public StoreController(StoreLogic logic, ComponentLogic componentLogic)
        {
            _logic = logic;
            _componentLogic = componentLogic;
        }
        [HttpGet]
        public List<StoreViewModel> GetStoreList() => _logic.Read(null);

        [HttpGet]
        public StoreViewModel GetStore(int storeId) => _logic.Read(new StoreBindingModel { Id = storeId })?[0];

        [HttpGet]
        public List<ComponentViewModel> GetComponentList() => _componentLogic.Read(null);

        [HttpPost]
        public void CreateOrUpdate(StoreBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void Delete(StoreBindingModel model) => _logic.Delete(model);

        [HttpPost]
        public void Fill(StoreFillBindingModel model) => _logic.Fill(model.Model, model.ComponentId, model.Count);
    }
}
