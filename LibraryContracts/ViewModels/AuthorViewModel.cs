using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [DisplayName("ФИО автора")]
        public string AuthorName { get; set; }
    }
}
