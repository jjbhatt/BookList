using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorWebPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazorWebPages.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext dBContext;

        public IndexModel(ApplicationDBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await dBContext.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var book = await dBContext.Book.FindAsync(Id);

            if (book == null)
            {
                return NotFound();
            }

            dBContext.Book.Remove(book);
            await dBContext.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}