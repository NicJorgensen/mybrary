using System;
using System.Data;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
    public class LibraryRepository
    {
        private readonly IDbConnection _db;

        public LibraryRepository(IDbConnection db)
        {
            _db = db;
        }

        //CREATE A LIBRARY
        public Library Create(Library libraryData)
        {
            Library library = new Library()
            {
                Name = libraryData.Name,
                Description = libraryData.Description,
                Public = libraryData.Public,
                UserId = libraryData.UserId
            };

            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO libraries(
                    name,
                    description,
                    public,
                    userId
                    ) VALUES(
                        @Name,
                        @Description,
                        @Public,
                        @UserId
                    )", library);
            library.Id = id;
            return library;
        }

        //GET ALL THE USER'S LIBRARIES
        public IEnumerable<Library> GetUserLibraries(string userId)
        {
            return _db.Query<Library>(@"
            SELECT * FROM libraries WHERE userId = @UserId
            ", new { UserId = userId });
        }

        //GET ALL PUBLIC LIBRARIES
        public IEnumerable<Library> GetPublicLibraries()
        {
            return _db.Query<Library>(@"
            SELECT * FROM libraries WHERE public = 'true'
            ");
        }

        public Library Delete(int libraryId)
        {
            return _db.QueryFirstOrDefault(@"
            DELETE FROM libraries WHERE id = @LibraryId", new { LibraryId = libraryId });
        }

    }
}