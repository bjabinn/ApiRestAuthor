// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.ApiRest.Models;
using System.Collections.Generic;
using System.Linq;

namespace Everis.Polar.ApiRest.Repository
{
    public class BookRepository : IBookRepository
    {
        private static readonly IList<Book> _books;

        static BookRepository()
        {
            _books = new List<Book>()
            {
                new Book() {
                    BookId = 1,
                    Title = "Harry Potter",
                    NumPages = 350, Language=1,
                    Isbn =1012, Format=1,
                    Authors = new List<Models.Author>()
                    {
                        new Author() { AuthorId=2, Name= "George R R Martin", Email="georgerrmartin@gmail.com", Gender="ficcion", IsDeleted=false  },
                        new Author() { AuthorId=3, Name= "Cervantes", Email="cervantes@gmail.com", Gender="novela", IsDeleted=true },
                    }
                },
                new Book() { BookId = 2, Title = "Juego de Tronos", NumPages= 560, Language=2, Isbn=0512, Format=2, IsDeleted= false},
                new Book() { BookId = 3, Title = "Don Quijote", NumPages= 836, Language=1, Isbn=0018, Format=2, IsDeleted= true},
                new Book() { BookId = 4, Title = "El diario de Ana Frank", NumPages= 463, Language=3, Isbn=4520, Format=2, IsDeleted= true}
            };
        }

        public IEnumerable<Book> Get()
        {
            return _books;
        }

        public Book Get(int id)
        {
            var query = _books.Where(b => b.BookId == id);
            var book = query.FirstOrDefault();

            return book ?? new Book();
        }

        public Book Create(Book book)
        {
            book.BookId = GetBookId();
            _books.Add(book);

            return book;
        }

        public Book Save(Book book)
        {
            bool exists = _books.Any(b => b.BookId == book.BookId);
            if (exists)
            {
                var bookFound = _books.FirstOrDefault(b => b.BookId == book.BookId);
                _books.Remove(bookFound);

                if (book.Authors != null)
                    bookFound.Authors = book.Authors;
                if (book.NumPages > 0)
                    bookFound.NumPages = book.NumPages;
                if (book.Format > 0)
                    bookFound.Format = book.Format;
                if (book.Isbn > 0)
                    bookFound.Isbn = book.Isbn;
                if (book.Language > 0)
                    bookFound.Language = book.Language;
                if (!string.IsNullOrWhiteSpace(book.Title))
                    bookFound.Title = book.Title;

                _books.Add(bookFound);

                return bookFound;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var bookFound = _books.FirstOrDefault(b => b.BookId == id);
            if (bookFound != null)
            {
                _books.Remove(bookFound);
                return true;
            }
            else
                return false;
        }

        private int GetBookId()
        {//TODO: change if 
            if (_books.Max(b => b.BookId) > 0)
                return _books.Max(b => b.BookId) + 1;
            else
                return 1;
        }
    }
}

