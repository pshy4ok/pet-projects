using System.Xml.Serialization;

namespace BooksLibrary;

[XmlRoot("books")]public class Books
{
    [XmlAttribute("SeriesID")]
    public int SeriesId { get; set; }
    [XmlAttribute("Title")]
    public string Title { get; set; }
    [XmlAttribute("Genre")]
    public string Genre { get; set; }
    [XmlAttribute("Author")]
    public string Author { get; set; }

    public Books()
    {
    }
    
    public Books(int id, string title, string genre, string author)
    {
        SeriesId = id;
        Title = title;
        Genre = genre;
        Author = author;
    }
}