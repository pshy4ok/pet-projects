using System.Xml.Serialization;

namespace BooksLibrary;

public class Book
{
    [XmlAttribute("seriesid")]
    public int SeriesId { get; set; }
    [XmlAttribute("title")]
    public string Title { get; set; }
    [XmlAttribute("genre")]
    public string Genre { get; set; }
    [XmlAttribute("author")]
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