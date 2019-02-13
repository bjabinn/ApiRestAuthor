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
    public class AuthorRepositoryMock : IAuthorRepository
    {
        private readonly IList<Author> _authors;

        public AuthorRepositoryMock()
        {
            _authors = new List<Author>()
            {
                new Author() { AuthorId =1, Name = "JK Rowling", Email ="jkrowling@gmail.com", Gender ="ficcion", Books = new List<Book>(){ } },
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
            var query = _authors.Where(b => b.AuthorId == id);
            var author = query.FirstOrDefault();

            return author ?? new Author();
        }

        public Author Save(Author author)
        {
            throw new System.NotImplementedException();
        }

        public Author Create(Author author)
        {
            throw new System.NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Author> IAuthorRepository.Get()
        {
            throw new System.NotImplementedException();
        }

        Author IAuthorRepository.Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

