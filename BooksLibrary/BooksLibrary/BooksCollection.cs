using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace BooksLibrary;

[XmlRoot("books")]
public class BooksCollection
{
    public const string XmlFilePath = "books.xml";

    [XmlElement("book")] 
    public Book[] Items { get; set; } = Array.Empty<Book>();
}