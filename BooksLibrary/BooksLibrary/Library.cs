namespace BooksLibrary;

public class Library
{
    public static Book[] allBooks;
    private Dictionary<string, Book[]> author;
    private Dictionary<int, LinkedList> seriesLists = new();
    private Logger _logger = new();
    
    public Library(BooksCollection booksCollection)
    {
        allBooks = booksCollection.Items;
        author = allBooks.GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.ToArray());

        foreach (var book in allBooks)
        {
            if (!seriesLists.ContainsKey(book.SeriesId))
            {
                seriesLists[book.SeriesId] = new LinkedList();
            }

            seriesLists[book.SeriesId].AddBook(book);
        }
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