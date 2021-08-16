using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIbrary.Models;

namespace LIbrary.Repositories
{
    public interface IBookRepository
    {
        public BookWithGenres Get(Guid id);
        public IEnumerable<Book> Get(Genre genre);
        public Book Add(Book book);
        public Book Update(Book book);
        public Book Delete(Book book);

    }
}
