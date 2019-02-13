// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.ApiRest.Models;
using Everis.Polar.ApiRest.Repository;
using System.Linq;
using Xunit;

namespace Everis.Polar.ApiRest.Tests.Repository
{
    public class AuthorsRepositoryTests
    {
        private IAuthorRepository _repository;

        public AuthorsRepositoryTests()
        {
            _repository = new AuthorRepository();
        }

        [Fact]
        public void GetTest()
        {
            var authors = _repository.Get();
            Assert.NotNull(authors);
            Assert.False(authors.Count() < 4);
        }

        [Fact]
        public void GetById_1_Test()
        {
            var author = _repository.Get(1);
            Assert.NotNull(author);
            Assert.True(author.Name == "JK Rowling");
        }

        [Fact]
        public void GetById_2_Test()
        {
            var author = _repository.Get(2);
            Assert.NotNull(author);
            Assert.True(author.Name == "George R R Martin");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetByIdTest(int id)
        {
            var author = _repository.Get(id);
            Assert.NotNull(author);
        }

        [Fact]
        public void GetByIdNullTest()
        {
            var author = _repository.Get(3333);
            Assert.NotNull(author);
            Assert.True(author.AuthorId == 0);
        }

        [Fact]        
        public void SaveTest()
        {
            var saveAuthor = _repository.Save(new Author() { AuthorId = 10});
            Assert.Null(saveAuthor);


            var saveAuthor1 = _repository.Save(new Author() { AuthorId = 4});
            Assert.NotNull(saveAuthor1);
        }

        [Fact]
       
        public void CreateTest()
        {
            _repository.Create(new Author() { Name = "Pepe" });
           
            var author = _repository.Get(5);
            Assert.True(author.Name == "Pepe");
        }


        [Fact]
        public void DeleteTest()
        {
            _repository.Delete(3);
            var author = _repository.Get(3);
            Assert.True(author.AuthorId == 0);

            Assert.False(_repository.Delete(6));
        }
    }
}
