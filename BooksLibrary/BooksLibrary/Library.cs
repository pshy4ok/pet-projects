namespace BooksLibrary;

public class Library
{
    public static Book[] allBooks;
    private Dictionary<string, Book[]> authorIndex;
    private Dictionary<int, LinkedList> linkedLists = new();
    private Logger _logger = new();

    public Library(BooksCollection booksCollection)
    {
        allBooks = booksCollection.Items;
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

    public Book[] GetAllBooks(string filePath)
    {
        foreach (var book in allBooks)
        {
            _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
        }

        return allBooks.ToArray();
    }

    public Book[] SearchByTitle(string title)
    {
        var results = allBooks.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        foreach (var book in results)
        {
            _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
        }

        return new Book[] { };
    }

    public Book[] SearchByAuthor(string author)
    {
        if (authorIndex.TryGetValue(author, out var results))
        {
            foreach (var book in results)
            {
                _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
            }
        }
        else
        {
            _logger.Log("Author wasn't found");
        }

        return new Book[] { };
    }

    public Book[] SearchByGenre(string genre)
    {
        var results = allBooks.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));

        foreach (var book in results)
        {
            _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
        }

        return allBooks.ToArray();
    }
}