using Microsoft.AspNetCore.Mvc;
using LIbrary.Repositories;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using LIbrary.Models;

namespace LIbrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _book;

        public BookController(IBookRepository book)
        {
            _book = book;
        }
        /// <summary>
        /// Получение информации о книге
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public BookWithGenres Get(Guid id)
        {
           return _book.Get(id);
        }
        /// <summary>
        /// Получить книги по жанру
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Book> Get([FromQuery] Genre genre)
        {
            return _book.Get(genre);
        }
        /// <summary>
        /// Добавление книги в библиотеку
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Book Add([FromBody]Book book)
        {
            return _book.Add(book);
        }
        /// <summary>
        /// Обновление информации по книге
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody]Book book)
        {
            var updatebook = _book.Update(book);
            if (updatebook == null)
            {
                return NotFound();
            }
            return Ok();
        }
        /// <summary>
        /// Удаление книги из библиотеке
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromBody]Book book)
        {
            var deleteBook = _book.Delete(book);
            if (deleteBook == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
