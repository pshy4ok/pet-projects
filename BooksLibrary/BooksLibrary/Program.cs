namespace BooksLibrary;

public class Program
{
    public const string xmlFilePath = "books.xml";
    private static Logger _logger = new();

    public static void Main(string[] args)
    {
        ThreadSimulator.RunThread();
        while (true)
        {
            _logger.Log(
                "Select the option:\n0 - Show all the books\n1 - Searching by the title\n2 - Searching by the author\n3 - Searching by genre\n4 - Exit");
            string option = InputReader.ReadInput();

            var library = new Library(LoadBooksFromXml<BooksCollection>());


            switch (option)
            {
                case "0":
                    var allBooks = library.GetAllBooks(xmlFilePath);
                    foreach (var book in allBooks)
                    {
                        _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
                    }
                    break;
                case "1":
                    _logger.Log("Input title to search:\n");
                    string title = InputReader.ReadInput();
                    var titleResults = library.SearchByTitle(title);
                    foreach (var book in titleResults)
                    {
                        _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
                    }
                    break;
                case "2":
                    _logger.Log("Input author to search:\n");
                    string author = InputReader.ReadInput();
                    var authorResults = library.SearchByAuthor(author);
                    foreach (var book in authorResults)
                    {
                        _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
                    }
                    break;
                case "3":
                    _logger.Log("Input genre to search:\n");
                    string genre = InputReader.ReadInput();
                    var genreResults = library.SearchByGenre(genre);
                    foreach (var book in genreResults)
                    {
                        _logger.Log($"Title: {book.Title}\nAuthor: {book.Author}\nGenre: {book.Genre}\n");
                    }
                    break;
                case "4":
                    _logger.Log("\nSee you soon!");
                    Environment.Exit(0);
                    break;
                default:
                    _logger.Log("Invalid option. Please select a valid option!");
                    break;
            }
        }
    }


    private static T LoadBooksFromXml<T>()
    {
        return XmlReader.ReadXml<T>(xmlFilePath);
    }
}