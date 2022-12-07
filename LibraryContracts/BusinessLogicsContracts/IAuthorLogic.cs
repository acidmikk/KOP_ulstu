using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.BusinessLogicsContracts
{
    public interface IAuthorLogic
    {
        List<AuthorViewModel> Read(AuthorBindingModel model);
        void CreateOrUpdate(AuthorBindingModel model);
        void Delete(AuthorBindingModel model);
    }
}
