using System.Xml;

namespace BooksLibrary;

public class Library
{
    private static List<Books> allBooks;
    private static Dictionary<string, List<Books>> authorIndex;
    private static LinkedList<Books> booksLinkedList;
    private static Logger _logger = new();
    public const string xmlFilePath = "books.xml";

    public Library(List<Books> books)
    {
        allBooks = books;
        authorIndex = books.GroupBy(b => b.Author).ToDictionary(g => g.Key, g => g.ToList());
        booksLinkedList = new LinkedList<Books>(books);
    }

    public static List<Books> ShowAllBooks(string filePath)
    {
        return XmlReader.ReadXml(xmlFilePath);
    }
    
    public static void SearchByTitle(string title)
    {
        var results = allBooks.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        DisplayResults(results);
    }

    public static void SearchByAuthor(string author)
    {
        if (authorIndex.TryGetValue(author, out var results))
        {
            DisplayResults(results);
        }
        else
        {
            _logger.Log("Author wasn't found");
        }
    }

    public static void SearchByGenre(string genre)
    {
        var results = allBooks.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
        DisplayResults(results);
    }

    private static void DisplayResults(IEnumerable<Books> results)
    {
            foreach (var book in results)
            {
                _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}");
            }
    }
}