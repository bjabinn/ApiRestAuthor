// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------
using Everis.Polar.Mvc.Models;
using System.Collections.Generic;

namespace Everis.Polar.Mvc.ViewModels
{
    public class BooksViewModelList
    {
        public IEnumerable<Book> Books { get; set; }
        public bool ShowActions = false;
    }
}
