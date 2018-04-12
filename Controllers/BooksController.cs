using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookRepository _repo;
        public BooksController(BookRepository repo)
        {
            _repo = repo;
        }

        //GET ALL BOOKS
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _repo.GetBooks();
        }
        //GET BOOK BY ID
        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            return _repo.GetById(id);
        }
        //CREATE BOOK
        [HttpPost]
        public Book AddBook([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                return _repo.Create(book);
            }
            return null;
        }
        //ADD A VIEW
        [HttpPut("views/{bookId}")]
        public Book AddView([FromBody]Book book)
        {
           return _repo.AddView(book);
        }
        //ADD A LIBRARY
        [HttpPut("libraries/{bookId}")]
        public Book AddLibrary([FromBody]Book book)
        {
           return _repo.AddLibrary(book);
        }
        //DELETE A BOOK
        [HttpDelete("{bookId}")]
        public Book Delete(int bookId)
        {
            return _repo.Delete(bookId);
        }
    }
}