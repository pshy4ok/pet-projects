using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace BooksLibrary;

[XmlRoot("books")]
public class BooksCollection
{
    public const string xmlFilePath = "books.xml";
    private static readonly ConcurrentBag<Book> bookCollection = new ConcurrentBag<Book>();
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

    [XmlElement("book")]
    public Book[] Items => bookCollection.ToArray();


    public static async Task AddBookAsync(Book book)
    {
        await semaphore.WaitAsync();
        try
        {
            bookCollection.Add(book);
        }
        finally
        {
            semaphore.Release();
        }
    }

    public static async Task AddRandomBooksToLibraryAsync()
    {
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var book = new Book
            {
                SeriesId = random.Next(6, 100),
                Title = $"Book {i}",
                Genre = $"Genre {i}",
                Author = $"Author {i}"
            };

            await AddBookAsync(book);
        }
    }
}