// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.ApiRest.Models;
using Everis.Polar.ApiRest.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiRest.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {

            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var books = _repository.Get();
            return books;
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet("{id}/pages/{pageId}")]
        public string Get(int id, int pageId)
        {
            return $"Book: {id} page:{pageId}";
        }

        // POST: api/Books/1
        [HttpPost("{id}")]
        public ActionResult<Book> Post(int id, [FromBody] Book book)
        {
            var savedBook = _repository.Create(book);
            return Ok(savedBook);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book book)
        {
            var savedBook = _repository.Save(book);
            if (savedBook == null)
                return NotFound(savedBook);

            return Ok(savedBook);
        }

        [HttpPatch("{id}")]
        public ActionResult<Book> Patch(int id, [FromBody] Book book)
        {
            var savedBook = _repository.Save(book);
            if (savedBook == null)
                return NotFound(savedBook);

            return Ok(savedBook);
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            var deletedBook = _repository.Delete(id);
            if (deletedBook)
                return Ok(deletedBook);

            return NotFound(deletedBook);            
        }
    }
}
