using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorWebPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazorWebPages.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext dBContext;

        public EditModel(ApplicationDBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int Id)
        {
            Book = await dBContext.Book.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookFromDB = await dBContext.Book.FindAsync(Book.Id);

                bookFromDB.Name = Book.Name;
                bookFromDB.Author = Book.Author;
                bookFromDB.ISBN = Book.ISBN;

                await dBContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}