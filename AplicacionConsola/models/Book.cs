// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------
using System.Collections.Generic;

namespace AplicacionConsola
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Language { get; set; }
        public int NumPages { get; set; }
        public int Format { get; set; }
        public int Isbn { get; set; }
        public bool IsDeleted = false;

        public List<Author> Authors = new List<Author>();
    }
}