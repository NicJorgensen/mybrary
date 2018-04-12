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
                Views = 0,
                Libraries = 0,
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
                views,
                libraries,
                userId
                ) VALUES(
                @Title,
                @Author,
                @Genre,
                @Synopsis,
                @Cover,
                0,
                0,
                @UserId
                )", book);
            book.Id = id;
            return book;
        }

        public Book AddView(Book bookData)
        {
            int i = _db.Execute(@"
            UPDATE books
            SET views = views + 1
            WHERE id = @Id
            ", new { Id = bookData.Id });

            if (i > 0)
            {
                return bookData;
            }
            return null;
        }

        public Book AddLibrary(Book bookData)
        {
            int i = _db.Execute(@"
            UPDATE books
            SET libraries = libraries + 1
            WHERE id = @Id
            ", new { Id = bookData.Id });

            if (i > 0)
            {
                return bookData;
            }
            return null;
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

        public Book Delete(int bookId)
        {
            return _db.QueryFirstOrDefault(@"
            DELETE FROM books WHERE id = @BookId", new { BookId = bookId });
        }

    }
}