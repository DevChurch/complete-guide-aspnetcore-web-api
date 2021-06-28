
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {

            _context = context;
        }

        public void AddAuthor(AuthorVM Author)
        {
            var _Author = new Author()
            {
                FullName = Author.FullName
            };

            _context.Authors.Add(_Author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors() => _context.Authors.ToList();

        public AuthorWithBooksVM GetAuthorWithBooks(int AuthorId)
        {
            var _author = _context.Authors.Where(n => n.Id == AuthorId).Select(author => new AuthorWithBooksVM()
            {
                FullName = author.FullName,
                BookTitles = author.Book_Authors.Select(n => n.Book.Title).ToList()

            }).FirstOrDefault();

            return _author;
        }
           

        public Author UpdateAuthor(int AuthorId, AuthorVM Author)
        {
            var _Author = _context.Authors.FirstOrDefault(n => n.Id == AuthorId);
            if (_Author != null)
            {
                _Author.FullName = Author.FullName;
               
            }
            _context.SaveChanges();
            return _Author;
        }

        public void DeleteAuthor(int AuthorId)
        {
            var _Author = _context.Authors.FirstOrDefault(n => n.Id == AuthorId);
            if (_Author != null)
            {
                _context.Remove(_Author);
                _context.SaveChanges();
            }
        }

    }
}
