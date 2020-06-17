using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorWebPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazorWebPages.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext dBContext;

        public CreateModel(ApplicationDBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
             
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await dBContext.Book.AddAsync(Book);
                await dBContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}