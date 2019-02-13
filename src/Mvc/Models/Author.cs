// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Everis.Polar.Mvc.Models
{
    [JsonObject]
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool IsDeleted = false;
    
        public IEnumerable<Book> Books = new List<Book>();
    }
}