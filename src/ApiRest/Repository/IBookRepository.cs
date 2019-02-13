// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.ApiRest.Models;
using System.Collections.Generic;

namespace Everis.Polar.ApiRest.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> Get();
        Book Get(int id);
        Book Save(Book book);
        Book Create(Book book);
        bool Delete(int id);
    }
}
