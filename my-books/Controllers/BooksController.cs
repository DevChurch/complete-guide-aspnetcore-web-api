using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
           var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            var book = _booksService.GetBooksById(bookId);
            return Ok(book);
        }

        [HttpGet("update-book-by-id/{id}")]
        public IActionResult UpdateBook(int bookId, [FromBody] BookVM book)
        {
            var updatedBook= _booksService.UpdateBook(bookId,book);
            return Ok(updatedBook);
        }

        [HttpGet("delete-book-by-id/{id}")]
        public IActionResult DeleteBook(int bookId)
        {
             _booksService.DeleteBook(bookId);
            return Ok();
        }
    }
}
