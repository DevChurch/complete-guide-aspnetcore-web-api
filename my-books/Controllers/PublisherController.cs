using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_Publishers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _PublishersService;

        public PublishersController(PublishersService PublishersService)
        {
            _PublishersService = PublishersService;
        }

        [HttpPost("add-Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM Publisher)
        {
            _PublishersService.AddPublisher(Publisher);
            return Ok();
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherBooksWithAuthors(int id)
        {
            var allPublishers = _PublishersService.GetPublisherData(id);
            return Ok(allPublishers);
        }

        [HttpGet("get-all-Publishers")]
        public IActionResult GetAllPublishers()
        {
            var allPublishers = _PublishersService.GetAllPublishers();
            return Ok(allPublishers);
        }

        [HttpGet("get-Publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int PublisherId)
        {
            var Publisher = _PublishersService.GetPublishersById(PublisherId);
            return Ok(Publisher);
        }

        [HttpGet("update-Publisher-by-id/{id}")]
        public IActionResult UpdatePublisher(int PublisherId, [FromBody] PublisherVM Publisher)
        {
            var updatedPublisher = _PublishersService.UpdatePublisher(PublisherId, Publisher);
            return Ok(updatedPublisher);
        }

        [HttpGet("delete-Publisher-by-id/{id}")]
        public IActionResult DeletePublisher(int PublisherId)
        {
            _PublishersService.DeletePublisher(PublisherId);
            return Ok();
        }
    }
}
