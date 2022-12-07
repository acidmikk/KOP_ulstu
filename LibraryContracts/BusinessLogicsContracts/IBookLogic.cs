using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.BusinessLogicsContracts
{
    public interface IBookLogic
    {
        List<BookViewModel> Read(BookBindingModel model);
        void CreateOrUpdate(BookBindingModel model);
        void Delete(BookBindingModel model);
    }
}
