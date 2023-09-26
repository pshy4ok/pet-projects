namespace BooksLibrary;

public abstract class BackgroundJobSimulator
{
    private static Library _library;
    public static async Task RunThread()
    {
        await Task.Run(_library.AddRandomBooksToLibraryAsync);
    }
}