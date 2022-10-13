using Demo_Web_API.DTO;
using Demo_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private ISampleDataGenetrate SampleDataGenetrater = new SampleDataGenetrate();

        

        [HttpGet(Name = "GetBook")]
        public ActionResult GetBookData()
        {
            var books = new List<Book>();
            try
            {
                SampleDataGenetrater.SampleDataAdd();
            }
            catch (Exception e)
            {    //  Ignore
            }

            using (var context = new LibraryContext())
            {
                books = context.Book
                   .Include(p => p.Publisher).ToList();

            }

            return Ok(books.ToArray());
        }

        [HttpPost(Name = "AddBook")]
        public ActionResult AddBook(BookRequestBody book)
        {
            var bookresponse = new Book();

            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var publisher = new Publisher
                {
                    Name = book.Publisher
                };
                context.Publisher.Add(publisher);

                // Adds some books
                context.Book.Add(new Book
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author,
                    Language = book.Language,
                    Pages = book.Pages,
                    Publisher = publisher
                });

                // Saves changes
                context.SaveChanges();

                bookresponse.ISBN = book.ISBN;
                bookresponse.Title = book.Title;
                bookresponse.Author = book.Author;
                bookresponse.Language = book.Language;
                bookresponse.Pages = book.Pages;
                bookresponse.Publisher = publisher;
            }

            return Ok(book);
        }
    }
}
