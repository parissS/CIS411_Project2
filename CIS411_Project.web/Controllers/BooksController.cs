using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS411_Project.Core.Models;
using CIS411_Project.Core.Services;

namespace CIS411_Project.web.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/

        public ActionResult Index()
        {
            var db = new BookService();
            return View(db.listBooks());
        }

        public ActionResult Details(int bookId)
        {
            BookService service = new BookService();
            return View(service.getBookById(bookId));
                   
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Books book)
        {
            BookService service = new BookService();
            service.insertBooks(book);
            return RedirectToAction("Index", "Books");
        }
    }   
         
}
