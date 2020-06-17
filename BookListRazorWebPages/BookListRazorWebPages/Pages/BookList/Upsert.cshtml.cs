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
    /// <summary>
    /// This is used to combine Create and Update both operations in same models and view. - Update and Insert = Upsert
    /// </summary>
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDBContext dBContext;

        public UpsertModel(ApplicationDBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Book = await dBContext.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Book.Id == 0)
                {
                    dBContext.Book.Add(Book);
                }
                else
                {
                    dBContext.Book.Update(Book);
                }

                await dBContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}