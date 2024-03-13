using FiletypeAPI.Models;
using System.Xml.Linq;

namespace FiletypeAPI.Parsers
{
    public class XMLParser
    {
        public XMLParser()
        {

        }
        public Me ParseXML(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            var me = new Me
            {
                FirstName = doc.Root.Element("FirstName").Value,
                LastName = doc.Root.Element("LastName").Value,
                Email = doc.Root.Element("Email").Value,
                Hobbies = doc.Root.Element("Hobbies")
                                  .Elements("Item")
                                  .Select(e => e.Value)
                                  .ToArray()
            };
            return me;
        }
    }
}
