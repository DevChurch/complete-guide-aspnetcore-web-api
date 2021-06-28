using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_Authors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _AuthorsService;

        public AuthorsController(AuthorsService AuthorsService)
        {
            _AuthorsService = AuthorsService;
        }

        [HttpPost("add-Author")]
        public IActionResult AddAuthor([FromBody] AuthorVM Author)
        {
            _AuthorsService.AddAuthor(Author);
            return Ok();
        }

        [HttpGet("get-all-Authors")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _AuthorsService.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpGet("get-Author-with-books/{AuthorId}")]
        public IActionResult GetAuthorWithBooks(int AuthorId)
        {
            var Author = _AuthorsService.GetAuthorWithBooks(AuthorId);
            return Ok(Author);
        }

        [HttpGet("update-Author-by-id/{id}")]
        public IActionResult UpdateAuthor(int AuthorId, [FromBody] AuthorVM Author)
        {
            var updatedAuthor = _AuthorsService.UpdateAuthor(AuthorId, Author);
            return Ok(updatedAuthor);
        }

        [HttpGet("delete-Author-by-id/{id}")]
        public IActionResult DeleteAuthor(int AuthorId)
        {
            _AuthorsService.DeleteAuthor(AuthorId);
            return Ok();
        }
    }
}
