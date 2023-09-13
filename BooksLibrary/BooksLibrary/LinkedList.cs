namespace BooksLibrary;

public class LinkedList
{
    public LinkedList<Book> Books { get; } = new LinkedList<Book>();

    public void AddBook(Book book)
    {
        Books.AddLast(book);
    }
}