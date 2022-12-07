using Database.Implements;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.StorageContracts;
using LibraryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLogic.BusinessLogics
{
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorStorage _authorStorage;

        public AuthorLogic(IAuthorStorage authorStorage)
        {
            _authorStorage = authorStorage;
        }
        public AuthorLogic()
        {
            _authorStorage = new AuthorStorage();
        }
        public List<AuthorViewModel> Read(AuthorBindingModel model)
        {
            if (model == null)
            {
                return _authorStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<AuthorViewModel> { _authorStorage.GetElement(model) };
            }
            return new List<AuthorViewModel> { _authorStorage.GetElement(model) };//_authorStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(AuthorBindingModel model)
        {
            var element = _authorStorage.GetElement(
                new AuthorBindingModel
                {
                    AuthorName = model.AuthorName
                });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Книга с таким названием уже существует");
            }
            if (model.Id.HasValue)
            {
                _authorStorage.Update(model);
            }
            else
            {
                _authorStorage.Insert(model);
            }
        }

        public void Delete(AuthorBindingModel model)
        {
            var element = _authorStorage.GetElement(new AuthorBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Книга не найдена");
            }
            _authorStorage.Delete(model);
        }
    }
}
