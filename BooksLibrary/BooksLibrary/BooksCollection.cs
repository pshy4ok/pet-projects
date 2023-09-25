using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace BooksLibrary;

[XmlRoot("books")]
public class BooksCollection
{
    private const string XmlFilePath = "books.xml";
    [XmlIgnore]private ConcurrentBag<Book> bookCollection = new ConcurrentBag<Book>();
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

    [XmlElement("book")] 
    public Book[] Items { get; set; } = Array.Empty<Book>();


    public async Task AddBookAsync(Book book)
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

    public async Task AddRandomBooksToLibraryAsync()
    {
        var random = new Random();
        var tasks = new List<Task>();
        for (int i = 0; i < 100; ++i)
        {
            var book = new Book
            {
                SeriesId = random.Next(6, 100),
                Title = $"Book {i}",
                Genre = $"Genre {i}",
                Author = $"Author {i}"
            };
            tasks.Add(AddBookAsync(book));
        }

        await Task.WhenAll(tasks);
    }
}