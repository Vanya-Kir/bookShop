using Microsoft.AspNetCore.Mvc;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookShop.web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService bookService;
        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }
        public IActionResult Index(string query)
        {
            var books = bookService.GetAllByQuery(query);
            return View(books);
        }
    }
}
