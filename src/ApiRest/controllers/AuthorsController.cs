// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.ApiRest.Models;
using Everis.Polar.ApiRest.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorRepository _repository;

        public AuthorsController(IAuthorRepository repository)
        {

            _repository = repository;
        }

        // GET: api/Authors
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            var authors = _repository.Get();
            return authors;
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _repository.Get(id);
        }

        // POST: api/Authors/1
        [HttpPost("{id}")]
        public ActionResult<Author> Post(int id, [FromBody] Author author)
        {
            var savedAuthor = _repository.Create(author);
            return Ok(savedAuthor);
        }

        // PUT: api/Authors/{author}
        [HttpPut("{id}")]
        public ActionResult<Author> Put(int id, [FromBody] Author author)
        {
            var savedAuthor = _repository.Save(author);
            if (savedAuthor == null)
                return NotFound(savedAuthor);

            return Ok(savedAuthor);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            var deletedAuthor = _repository.Delete(id);
            if (deletedAuthor)
                return Ok(deletedAuthor);

            return NotFound(deletedAuthor);
        }
    }
}