using Fairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Fairy.DTOmodels;

namespace Fairy.Controllers.ApiControllers
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }


        // GET api/books
        public IHttpActionResult GetAllBooks()
        {
            var bookInDTO = _context.Books
                .Include(g => g.Genre)
                .ToList()
                .Select(Mapper.Map<Book, BookDTO>);

            return Ok(bookInDTO);
        }

        // GET api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            return Ok(Mapper.Map<Book, BookDTO>(book));
        }

        // POST api/books/create/
        [HttpPost]
        public IHttpActionResult CreateBook(BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = Mapper.Map<BookDTO, Book>(bookDTO);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDTO.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDTO);
        }

        // PUT api/books/update/
        [HttpPut]
        public void UpdateBook(int id, BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bookInDB = _context.Books.SingleOrDefault(x => x.Id == id);

            if (bookInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(bookDTO, bookInDB);

            _context.SaveChanges();

        }

        // DELETE api/books/delete/
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(x => x.Id == id);

            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
        }
    }
}
