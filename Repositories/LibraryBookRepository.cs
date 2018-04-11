using System;
using System.Data;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
    public class LibraryBookRepository
    {
        private readonly IDbConnection _db;

        public LibraryBookRepository(IDbConnection db)
        {
            _db = db;
        }

        public LibraryBook Create(LibraryBook libraryBookData)
        {
            LibraryBook libraryBook = new LibraryBook()
            {
                BookId = libraryBookData.BookId,
                LibraryId = libraryBookData.LibraryId,
                UserId = libraryBookData.UserId
            };

            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO librarybooks(
                    bookId,
                    libraryId,
                    userId
                    ) VALUES (
                        @BookId,
                        @LibraryId,
                        @UserId
                    )", libraryBook);
            libraryBook.Id = id;
            return libraryBook;
        }

        public IEnumerable<Book> Get(int libraryId)
        {            
            return _db.Query<Book>(@"
            SELECT * FROM librarybooks lb
            INNER JOIN books b ON b.id = lb.bookId 
            WHERE (libraryId = @LibraryId)", new {LibraryId = libraryId});
        }
    }
}