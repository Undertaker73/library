using System;
using System.Collections.Generic;
using LIbrary.Models;
using System.Linq;
using LIbrary.Contexts;

namespace LIbrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly HomeLibraryContext _library;

        public BookRepository(HomeLibraryContext context)
        {
            _library = context;
        }
        public BookWithGenres Get(Guid id)
        {
            Book book = _library.Books.FirstOrDefault(b => b.Id == id);
            if (book == null) 
            {
                return null;
            }
            return new BookWithGenres
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Genres = _library.BooksGenres.Where(b => b.BookId == id).Join(_library.Genres, bg => bg.GenreId, g => g.Id, (bg, g) => new{ g.Name }).Select(g=>g.Name).AsEnumerable()
            };
        }
        public IEnumerable<Book> Get(Genre genre) 
        {
            if (_library.Genres.FirstOrDefault(g => g.Id == genre.Id) == null)
            {
                return null;
            }
            return _library.BooksGenres.Where(b => b.GenreId == genre.Id).Join(_library.Books, bg => bg.BookId, b => b.Id, (bg, b) => new Book { Author = b.Author, Id = b.Id, Name = b.Name }).AsEnumerable();
        }
        public Book Add(Book book)
        {
            var b = _library.Books.Add(book);
            _library.SaveChanges();
            return b.Entity;
        }

        public Book Update(Book book) 
        {
            Book updateBook = _library.Books.FirstOrDefault(b=>b.Id == book.Id);
            if (updateBook == null)
            {
                return null;
            }
            updateBook.Name = book.Name;
            updateBook.Author = book.Author;
            _library.SaveChanges();
            return updateBook;
        }

        public Book Delete(Book book) 
        {
            Book deleteBook = _library.Books.FirstOrDefault(b => b.Id == book.Id);
            if (deleteBook == null)
            {
                return null;
            }
            foreach (BooksGenres bookGenre in _library.BooksGenres.Where(bg=>bg.BookId == deleteBook.Id))
            {
                _library.BooksGenres.Remove(bookGenre);
            }
            _library.Books.Remove(deleteBook);
            _library.SaveChanges();
            return book;
        }
    }
}
