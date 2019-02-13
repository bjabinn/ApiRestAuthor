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
    public class Book
    {
        [JsonProperty]
        public int BookId { get; set; }
        public string Title { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        // [Display(Name = "Publication Date")]
        //public DateTime PublicationDate { get; set; }
        public int Language { get; set; }
        public int NumPages { get; set; }
        public int Format { get; set; }
        public int Isbn { get; set; }
        public bool IsDeleted = false;

        public IEnumerable<Author> Authors = new List<Author>();
    }
}