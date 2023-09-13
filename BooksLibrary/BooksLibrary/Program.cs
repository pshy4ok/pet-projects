namespace BooksLibrary;

public class Program
{
    public const string xmlFilePath = "books.xml";
    private static Logger _logger = new();

    public static void Main(string[] args)
    {
        while (true)
        {
            _logger.Log(
                "Select the option:\n0 - Show all the books\n1 - Searching by the title\n2 - Searching by the author\n3 - Searching by genre\n4 - Exit");
            string option = InputReader.ReadInput();

            var library = new Library(LoadBooksFromXml());

            switch (option)
            {
                case "0":
                    library.GetAllBooks(xmlFilePath);
                    break;
                case "1":
                    _logger.Log("Input title to search:\n");
                    string title = InputReader.ReadInput();
                    library.SearchByTitle(title);
                    break;
                case "2":
                    _logger.Log("Input author to search:\n");
                    string author = InputReader.ReadInput();
                    library.SearchByAuthor(author);
                    break;
                case "3":
                    _logger.Log("Input genre to search:\n");
                    string genre = InputReader.ReadInput();
                    library.SearchByGenre(genre);
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


    private static BooksCollection LoadBooksFromXml()
    {
        return XmlReader.ReadXml(xmlFilePath);
    }
}