using System.Xml.Serialization;

namespace BooksLibrary;

public class XmlReader
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

/*public static List<Books> ReadXml(string filePath)
{
    List<Books> allList = new List<Books>();
    XmlDocument booksList = new XmlDocument();
    booksList.Load(filePath);

    XmlElement? xRoot = booksList.DocumentElement;

    if (xRoot != null)
    {
        foreach (XmlElement xNode in xRoot)
        {
            xNode.Attributes.GetNamedItem("title");

            foreach (XmlNode childNode in xNode.ChildNodes)
            {
                if (childNode.Name == "title")
                {
                    _logger.Log($"Title: {childNode.InnerText}");
                }

                if (childNode.Name == "genre")
                {
                    _logger.Log($"Genre: {childNode.InnerText}");
                }

                if (childNode.Name == "author")
                {
                    _logger.Log($"Author: {childNode.InnerText}");
                }
            }

            _logger.Log("");
        }
    }

    return allList;
    */
