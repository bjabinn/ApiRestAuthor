// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.ApiRest.Repository;
using Everis.Polar.ApiRest.Models;
using System.Linq;
using Xunit;

namespace Everis.Polar.ApiRest.Tests.Repository
{
    public class BooksRepositoryTests
    {
        private IBookRepository _repository;

        public BooksRepositoryTests()
        {
            _repository = new BookRepository();
        }

        [Fact]
        public void GetTest()
        {
            var books = _repository.Get();
            Assert.NotNull(books);
            Assert.False(books.Count() < 4);
        }

        [Fact]
        public void GetById_1_Test()
        {
            var book = _repository.Get(1);
            Assert.NotNull(book);
            Assert.True(book.Title == "Harry Potter");
        }

        [Fact]
        public void GetById_2_Test()
        {
            var book = _repository.Get(2);
            Assert.NotNull(book);
            Assert.True(book.Title == "Juego de Tronos");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetByIdTest(int id)
        {
            var book = _repository.Get(id);
            Assert.NotNull(book);
        }

        [Fact]
        public void GetByIdNullTest()
        {
            var book = _repository.Get(3333);
            Assert.NotNull(book);
            Assert.True(book.BookId == 0);
        }

        [Fact]        
        public void SaveTest()
        {
            var saveBook = _repository.Save(new Book() {BookId = 10});
            Assert.Null(saveBook);


            var saveBook1 = _repository.Save(new Book() {BookId = 4});
            Assert.NotNull(saveBook1);
        }

        [Fact]
       
        public void CreateTest()
        {
            _repository.Create(new Book() { Title = "El arbol de la ciencia" });
           
            var book = _repository.Get(5);
            Assert.True(book.Title == "El arbol de la ciencia");
        }


        [Fact]
        public void DeleteTest()
        {
            _repository.Delete(3);
            var book = _repository.Get(3);
            Assert.True(book.BookId == 0);

            Assert.False(_repository.Delete(6));
        }
    }
}
