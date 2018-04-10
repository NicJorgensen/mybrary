using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr
{
    [Route("api/[controller]")]
    public class LibrariesController : Controller
    {
        private readonly LibraryRepository _repo;
        public LibrariesController(LibraryRepository repo)
        {
            _repo = repo;
        }

        //GET ALL LIBRARIES FOR A USER
        [HttpGet("{userId}")]
        public IEnumerable<Library> Get(string userId)
        {
            return _repo.GetUserLibraries(userId);
        }

        [HttpPost]
        public Library Create([FromBody]Library library)
        {
            if (ModelState.IsValid)
            {
                return _repo.Create(library);
            }
            return null;
        }
    }
}