using TypographyShopBusinessLogic.BindingModels;
using TypographyShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace TypographyShopBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
        List<MessageInfoViewModel> GetMessagesPage(MessageInfoBindingModel model);
        int Count();
    }
}
