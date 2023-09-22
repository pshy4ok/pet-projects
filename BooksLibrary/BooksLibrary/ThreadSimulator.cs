namespace BooksLibrary;

public class ThreadSimulator
{
    public static async Task RunThread()
    {
        await Task.Run(BooksCollection.AddRandomBooksToLibraryAsync);
    }
}