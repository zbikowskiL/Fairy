using Fairy.Models;
using Fairy.ViewModels;
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
            //var books = _context.Books.Include(g => g.Genre).ToList();

            //return View(books);
            return View();
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

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var ViewModel = new BookFormViewModel
            {
                Genres = genre
            };

            return View("BookForm", ViewModel);
        }

        [HttpPost]
        public ActionResult Save(Book book)
        {
            if (book.Id == null)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDB = _context.Books.Single(b => b.Id == book.Id);
                bookInDB.Name = book.Name;
                bookInDB.GenreId = book.GenreId;
                bookInDB.DateAdded = book.DateAdded;
                bookInDB.ReleaseDate = book.ReleaseDate;
                bookInDB.NumberInStock = book.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
        

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return HttpNotFound("Book object can't be null.");
            }

            var ViewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };

            return View("Edit", ViewModel);

         
        }
    }
}