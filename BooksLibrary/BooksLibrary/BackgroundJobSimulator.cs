namespace BooksLibrary;

public abstract class BackgroundJobSimulator
{
    private static BooksCollection _booksCollection;
    public static async Task RunThread()
    {
        await Task.Run(_booksCollection.AddRandomBooksToLibraryAsync);
    }
}