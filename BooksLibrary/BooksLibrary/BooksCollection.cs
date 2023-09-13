using System.Xml.Serialization;

namespace BooksLibrary;

[XmlRoot("books")]
public class BooksCollection
{
    [XmlElement("book")] public Book[] Items { get; set; } = Array.Empty<Book>();
}