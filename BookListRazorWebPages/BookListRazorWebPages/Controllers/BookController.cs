using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorWebPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazorWebPages.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public BookController(ApplicationDBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = dBContext.Book.ToList() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await dBContext.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            dBContext.Book.Remove(bookFromDb);
            await dBContext.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
