using System.Xml.Serialization;

namespace BooksLibrary;

public abstract class XmlReader
{
    private static Logger _logger = new();
    

    public static BooksCollection ReadXml(string filePath)
    {
        var result = new BooksCollection();

        try
        {
            var serializer = new XmlSerializer(typeof(BooksCollection));

            using var fs = new FileStream(filePath, FileMode.Open);
            result = (BooksCollection)serializer.Deserialize(fs);
        }
        catch (Exception ex)
        {
            _logger.Log($"Error reading XML file: {ex.Message}");
        }

        return result;
    }
}