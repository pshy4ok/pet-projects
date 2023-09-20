using System.Xml.Serialization;

namespace BooksLibrary;

public abstract class XmlReader
{
    private static Logger _logger = new();
    
    
    public static T ReadXml<T>(string filePath)
    {
            var serializer = new XmlSerializer(typeof(T));

            using var fs = new FileStream(filePath, FileMode.Open);
            return (T)serializer.Deserialize(fs);
    }
}