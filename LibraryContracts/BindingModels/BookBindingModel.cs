using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.BindingModels
{
    public class BookBindingModel
    {
        public int? Id { get; set; }
        public string BookName { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public DateTime DateOut { get; set; }
    }
}
