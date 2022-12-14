using Demo_Web_API.Models;

namespace Demo_Web_API.Services
{
    public class SampleDataGenetrate : ISampleDataGenetrate
    {
        public SampleDataGenetrate()
        {

        }
        public void SampleDataAdd()
        {
            try
            {
                using (var context = new LibraryContext())
                {
                    // Creates the database if not exists
                    context.Database.EnsureCreated();

                    // Adds a publisher
                    var publisher = new Publisher
                    {
                        Name = "Mariner Books"
                    };
                    context.Publisher.Add(publisher);

                    // Adds some books
                    context.Book.Add(new Book
                    {
                        ISBN = "978-0544003415",
                        Title = "The Lord of the Rings",
                        Author = "J.R.R. Tolkien",
                        Language = "English",
                        Pages = 1216,
                        Publisher = publisher
                    });
                    context.Book.Add(new Book
                    {
                        ISBN = "978-0547247762",
                        Title = "The Sealed Letter",
                        Author = "Emma Donoghue",
                        Language = "English",
                        Pages = 416,
                        Publisher = publisher
                    });

                    // Saves changes
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}