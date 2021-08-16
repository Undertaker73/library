using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Models
{
    public class BookWithGenres
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<string> Genres { get; set; }

    }
}
