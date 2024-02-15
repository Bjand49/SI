using CsvHelper;
using FiletypeAPI.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Xml.Linq;
using YamlDotNet.Serialization;

namespace FiletypeAPI
{
    public static class Parser
    {
        public static Me ReadCSV()
        {
            var csvfile = new StreamReader("Files\\me.csv");
            var csv = new CsvReader(csvfile, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<MeMapper>();

            var records = csv.GetRecords<Me>();
            var me = records.First();
            return me;

        }
        public static Me ReadJSON()
        {
            var file = File.ReadAllText("Files\\me.json");
            var me = JsonConvert.DeserializeObject<Me>(file);
            return me;
        }

        public static Me ReadXML()
        {
            var file = File.ReadAllText("Files\\me.xml");
            XDocument doc = XDocument.Parse(file);

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
        public static Me ReadYAML()
        {
            var file = File.ReadAllText("Files\\me.yaml");
            var deserializer = new DeserializerBuilder().Build();

            //yml contains a string containing your YAML
            var me = deserializer.Deserialize<Me>(file);
            return me;

        }
        public static Me ReadText()
        {
            var file = File.ReadAllLines("Files\\me.txt");
            var me = new Me()
            {
                FirstName = file[0],
                LastName = file[1],
                Email = file[2],
                Hobbies = file[3].Split(',')
            };
            return me;
        }
    }
}
