using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string BookName { get; set; }
        [DisplayName("Изображение")]
        public string Image { get; set; }
        [DisplayName("Автор")]
        public string Author { get; set; }
        [DisplayName("Дата публикации")]
        public DateTime DateOut { get; set; }
    }
}
