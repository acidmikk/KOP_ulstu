using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime DateOut { get; set; }
    }
}
