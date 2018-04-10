using System;
using System.Data;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
    public class BookRepository
    {
        private readonly IDbConnection _db;
        public BookRepository(IDbConnection db)
        {
            _db = db;
        }

        //CREATE A BOOK
        public Book Create(Book bookData)
        {
            Book book = new Book()
            {
                Title = bookData.Title,
                Author = bookData.Author,
                Genre = bookData.Genre,
                Synopsis = bookData.Synopsis,
                Cover = bookData.Cover,
                UserId = bookData.UserId
            };

            // run a sql command
            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO books(
                title, 
                author,
                genre,
                synopsis,
                cover,
                userId
                ) VALUES(
                @Title,
                @Author,
                @Genre,
                @Synopsis,
                @Cover,
                @UserId
                )", book);
            book.Id = id;
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _db.Query<Book>("SELECT * FROM books");
        }

        public Book GetById(int id)
        {
            return _db.QueryFirstOrDefault<Book>(@"
            SELECT * FROM books WHERE id = @id
            ", id);
        }
    }
}