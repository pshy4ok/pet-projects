namespace BooksLibrary;

public class BackgroundJobSimulator
{
    public static async Task RunThread(Library library)
    {
        await Task.Run(library.AddRandomBooksToLibraryAsync);
    }
}