using System.Xml;
using System.Xml.Serialization;

namespace BooksLibrary;

public class Program
{
    public const string xmlFilePath = "books.xml";
    private static Logger _logger = new();

    public static void Main(string[] args)
    {
        _logger.Log(
            "Select the option:\n0 - Show all the books\n1 - Searching by the title\n2 - Searching by the author\n3 - Searching by genre\n4 - Exit");
        string option = InputReader.ReadInput();
        

        switch (option)
        {
            case "0":
                Library.ShowAllBooks(xmlFilePath);
                break;
            case "1":
                _logger.Log("Input title to search:");
                string title = InputReader.ReadInput();
                Library.SearchByTitle(title);
                break;
            case "2":
                _logger.Log("Input author to search:");
                string author = InputReader.ReadInput();
                Library.SearchByAuthor(author);
                break;
            case "3":
                _logger.Log("Input genre to search:");
                string genre = InputReader.ReadInput();
                Library.SearchByGenre(genre);
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                _logger.Log("Invalid option. Please select a valid option!");
                break;
        }
    }
}