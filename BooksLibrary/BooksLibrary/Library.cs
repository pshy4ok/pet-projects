using System.Collections.Concurrent;

namespace BooksLibrary;

public class Library
{
    private readonly ConcurrentBag<Book> _booksBag;
    public Library(BooksCollection booksCollection)
    {
        _booksBag = new ConcurrentBag<Book>(booksCollection.Items);
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _booksBag.ToArray();
    }

    public IEnumerable<Book> SearchByTitle(string title)
    {
        var results = _booksBag.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        return results.ToArray();
    }

    public IEnumerable<Book> SearchByAuthor(string author)
    {
        var booksByAuthor = _booksBag.GroupBy(x => x.Author)
            .ToDictionary(x => x.Key, x => x);
        return booksByAuthor.TryGetValue(author, out var results) ? results.ToArray() : Array.Empty<Book>();
    }

    public IEnumerable<Book> SearchByGenre(string genre)
    {
        var results = _booksBag.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
        return results.ToArray();
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

    private async Task AddBookAsync(Book book)
    {
        _booksBag.Add(book);
        await Task.Delay(100);
    }
}