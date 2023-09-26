using System.Collections.Concurrent;

namespace BooksLibrary;

public class Library
{
    private ConcurrentBag<Book> allBooks;
    private Dictionary<string, Book[]> author;
    private Dictionary<int, LinkedList<BooksCollection>> seriesLists = new();

    public Library(BooksCollection booksCollection)
    {
        allBooks = new ConcurrentBag<Book>(booksCollection.Items);
        author = allBooks.GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.ToArray());

        foreach (var book in allBooks)
        {
            if (!seriesLists.ContainsKey(book.SeriesId))
            {
                seriesLists[book.SeriesId] = new LinkedList<BooksCollection>();
            }

            seriesLists[book.SeriesId].AddLast(booksCollection);
        }
    }

    private async Task AddBookAsync(Book book)
    {
        allBooks.Add(book);
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

    public Book[] GetAllBooks(string filePath)
    {
        return allBooks.ToArray();
    }

    public Book[] SearchByTitle(string title)
    {
        var results = allBooks.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        return results.ToArray();
    }

    public Book[] SearchByAuthor(string author)
    {
        if (this.author.TryGetValue(author, out var results))
        {
            return results.ToArray();
        }
        else
        {
            return new Book[] { };
        }
    }

    public Book[] SearchByGenre(string genre)
    {
        var results = allBooks.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
        return results.ToArray();
    }
}