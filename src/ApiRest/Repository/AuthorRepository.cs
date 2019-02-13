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
    public class AuthorRepository : IAuthorRepository
    {
        private static readonly IList<Author> _authors;

        static AuthorRepository()
        {
            _authors = new List<Author>()
            {
                new Author() {
                    AuthorId =1,
                    Name = "JK Rowling",
                    Email ="jkrowling@gmail.com",
                    Gender ="ficcion",
                    Books = new List<Book>(){
                        new Book() { BookId = 2, Title = "Juego de Tronos", NumPages= 560, Language=2, Isbn=0512, Format=2, IsDeleted= false},
                        new Book() { BookId = 3, Title = "Don Quijote", NumPages= 836, Language=1, Isbn=0018, Format=2, IsDeleted= true},
                    } },
                new Author() { AuthorId=2, Name= "George R R Martin", Email="georgerrmartin@gmail.com", Gender="ficcion", IsDeleted=false  },
                new Author() { AuthorId=3, Name= "Cervantes", Email="cervantes@gmail.com", Gender="novela", IsDeleted=true },
                new Author() { AuthorId=4, Name= "Gabriel Garcia Marquez", Email="gabrigarcimarquez@gmail.com", Gender="novela", IsDeleted=false }
            };
        }

        public IEnumerable<Author> Get()
        {
            return _authors;
        }

        public Author Get(int id)
        {
            var query = _authors.Where(a => a.AuthorId == id);
            var author = query.FirstOrDefault();

            return author ?? new Author();
        }

        public Author Create(Author author)
        {
            author.AuthorId = GetAuthorId();
            _authors.Add(author);

            return author;
        }

        public Author Save(Author author)
        {
            bool exists = _authors.Any(a => a.AuthorId == author.AuthorId);
            if (exists)
            {
                var authorFound = _authors.FirstOrDefault(a => a.AuthorId == author.AuthorId);
                _authors.Remove(authorFound);
                _authors.Add(author);
                return authorFound;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var authorFound = _authors.FirstOrDefault(a => a.AuthorId == id);
            if (authorFound != null)
            {
                _authors.Remove(authorFound);
                return true;
            }
            else
                return false;
        }

        private int GetAuthorId()
        {//TODO: change if 
            if (_authors.Max(b => b.AuthorId) > 0)
                return _authors.Max(b => b.AuthorId) + 1;
            else
                return 1;
        }
    }
}