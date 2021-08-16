using System;
using System.Collections.Generic;

#nullable disable

namespace LIbrary.Models
{
    public partial class BooksGenres
    {
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
