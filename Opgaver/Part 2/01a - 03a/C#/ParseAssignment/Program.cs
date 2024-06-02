// See https://aka.ms/new-console-template for more information
using CsvHelper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ParseAssignment;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Data.SqlTypes;
using System.Xml.Linq;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //CSV
        ReadCSV();
        //JSON
        ReadJSON();
        //XML
        ReadXML();
        //YAML
        ReadYAML();
        //TEXT
        ReadText();
    }
    private static void ReadCSV()
    {
        var csvfile = new StreamReader("Files\\me.csv");
        var csv = new CsvReader(csvfile, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<MeMapper>();

        var records = csv.GetRecords<Me>();
        var me = records.First();
        Console.WriteLine(me);

    }
    private static void ReadJSON()
    {
        var file = File.ReadAllText("Files\\me.json");
        var me = JsonConvert.DeserializeObject<Me>(file);
        Console.WriteLine(me);
    }

    private static void ReadXML()
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
        Console.WriteLine(me);
    }
    private static void ReadYAML()
    {
        var file = File.ReadAllText("Files\\me.yaml");
        var deserializer = new DeserializerBuilder().Build();

        //yml contains a string containing your YAML
        var me = deserializer.Deserialize<Me>(file);
        Console.WriteLine(me);

    }
    private static void ReadText()
    {
        var file = File.ReadAllLines("Files\\me.txt");
        var me = new Me()
        {
            FirstName = file[0],
            LastName = file[1],
            Email = file[2],
            Hobbies = file[3].Split(',')
        };
        Console.WriteLine(me);
    }
}