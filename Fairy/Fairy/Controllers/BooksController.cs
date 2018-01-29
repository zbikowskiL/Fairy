using Fairy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fairy.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Books
        public ActionResult Index()
        {
            var books = _context.Books.Include(g => g.Genre).ToList();

            return View(books);
        }

        public ActionResult Details(int id)
        {
            var books = _context.Books.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);

            if (books == null)
            {
                return HttpNotFound("Book object can't be null.");
            }
            return View(books);
        }

    }
}