namespace BooksLibrary;

public class Library
{
    private List<Book> allBooks;
    private Dictionary<string, Book[]> authorIndex;
    private Dictionary<int, LinkedList> linkedLists = new Dictionary<int, LinkedList>();
    private Logger _logger = new();

    public Library(BooksCollection booksCollection)
    {
        allBooks = booksCollection.Items.ToList();
        authorIndex = allBooks.GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.ToArray());

        foreach (var book in allBooks)
        {
            if (!linkedLists.ContainsKey(book.SeriesId))
            {
                linkedLists[book.SeriesId] = new LinkedList();
            }
            linkedLists[book.SeriesId].AddBook(book);
        }
    }

    public BooksCollection GetAllBooks(string filePath)
    {
        return new BooksCollection { Items = allBooks.ToArray() };
    }
    
    public IEnumerable<Book> SearchByTitle(string title)
    {
        var results = allBooks.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        foreach (var book in results)
        {
            if (linkedLists.TryGetValue(book.SeriesId, out var seriesLinkedList))
            {
                foreach (var linkedBook in seriesLinkedList.Books)
                {
                    yield return linkedBook;
                }
            }
        }
    }

    public Book[] SearchByAuthor(string author)
    {
        if (authorIndex.TryGetValue(author, out var results))
        {
            return results;
        }
        else
        {
            _logger.Log("Author wasn't found");
        }

        return new Book[] { };
    }

    public IEnumerable<Book> SearchByGenre(string genre)
    {
        var results = allBooks.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
        return results;
    }
}