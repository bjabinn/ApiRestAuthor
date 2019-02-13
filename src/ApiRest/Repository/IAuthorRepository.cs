// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.ApiRest.Models;
using System.Collections.Generic;

namespace Everis.Polar.ApiRest.Repository
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> Get();
        Author Get(int id);
        Author Save(Author author);
        Author Create(Author author);
        bool Delete(int id);
    }
}