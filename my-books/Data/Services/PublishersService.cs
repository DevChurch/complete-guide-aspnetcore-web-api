using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {

            _context = context;
        }

        public void AddPublisher(PublisherVM Publisher)
        {
            var _Publisher = new Publisher()
            {
                Name = Publisher.Name
            };

            _context.Publishers.Add(_Publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetAllPublishers() => _context.Publishers.ToList();

        public Publisher GetPublishersById(int PublisherId) => _context.Publishers.FirstOrDefault(n => n.Id == PublisherId);

        public Publisher UpdatePublisher(int PublisherId, PublisherVM Publisher)
        {
            var _Publisher = _context.Publishers.FirstOrDefault(n => n.Id == PublisherId);
            if (_Publisher != null)
            {
                _Publisher.Name = Publisher.Name;

            }
            _context.SaveChanges();
            return _Publisher;
        }

        public void DeletePublisher(int PublisherId)
        {
            var _Publisher = _context.Publishers.FirstOrDefault(n => n.Id == PublisherId);
            if (_Publisher != null)
            {
                _context.Remove(_Publisher);
                _context.SaveChanges();
            }
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publisherData;
        }
    }
}
