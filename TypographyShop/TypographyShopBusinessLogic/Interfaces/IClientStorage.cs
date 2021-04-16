using System.Collections.Generic;
using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopBusinessLogic.Interfaces
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();

        List<ClientViewModel> GetFilteredList(ClientBindingModel model);

        ClientViewModel GetElement(ClientBindingModel model);

        void Insert(ClientBindingModel model);

        void Update(ClientBindingModel model);

        void Delete(ClientBindingModel model);
    }
}
