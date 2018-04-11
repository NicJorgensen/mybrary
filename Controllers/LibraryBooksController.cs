using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr
{
    [Route("api/[controller]")]
    
    public class LibraryBooksController : Controller
    {
        private readonly LibraryBookRepository _repo;
        public LibraryBooksController(LibraryBookRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public LibraryBook Create([FromBody]LibraryBook libraryBook)
        {
            if (ModelState.IsValid)
            {
                return _repo.Create(libraryBook);
            }
            return null;
        }

        [HttpGet("{libraryId}")]
        public IEnumerable<Book> Get(int libraryId){
            return _repo.Get(libraryId);
        }
    }
}