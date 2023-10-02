using System.Xml.Serialization;

namespace BooksLibrary;

public abstract class XmlReader
{
    public static T ReadXml<T>(string filePath)
    {
            var serializer = new XmlSerializer(typeof(T));

            using var fs = new FileStream(filePath, FileMode.Open);
            return (T)serializer.Deserialize(fs);
    }
}