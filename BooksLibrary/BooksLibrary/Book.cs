using System.Xml.Serialization;

namespace BooksLibrary;

public class Book
{
    [XmlElement("seriesid")]
    public int SeriesId { get; set; }
    [XmlElement("title")]
    public string Title { get; set; }
    [XmlElement("genre")]
    public string Genre { get; set; }
    [XmlElement("author")]
    public string Author { get; set; }

    public Book()
    {
    }
    
    public Book(int id, string title, string genre, string author)
    {
        SeriesId = id;
        Title = title;
        Genre = genre;
        Author = author;
    }
}