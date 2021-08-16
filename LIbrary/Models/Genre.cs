using System;
using System.Collections.Generic;

#nullable disable

namespace LIbrary.Models
{
    public partial class Genre
    {
        public Genre()
        {
            BooksGenres = new HashSet<BooksGenres>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BooksGenres> BooksGenres { get; set; }
    }
}
