using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazorWebPages.Model
{
    public class Book
    {
        [Key, Required(ErrorMessage = "* BookId required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "* Book name required")]
        public string Name { get; set; }
        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}
