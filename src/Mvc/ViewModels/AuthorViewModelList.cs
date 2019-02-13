﻿// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------
using Everis.Polar.Mvc.Models;
using System.Collections.Generic;

namespace Everis.Polar.Mvc.ViewModels
{
    public class AuthorViewModelList
    {
        public IEnumerable<Author> Authors { get; set; }
        public bool ShowActions = false;
    }
}
