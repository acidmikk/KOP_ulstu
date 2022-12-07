using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.StorageContracts
{
    public interface IAuthorStorage
    {
        List<AuthorViewModel> GetFullList();
        AuthorViewModel GetElement(AuthorBindingModel model);

        void Insert(AuthorBindingModel model);
        void Update(AuthorBindingModel model);
        void Delete(AuthorBindingModel model);
    }
}
