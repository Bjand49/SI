using FiletypeAPI.Models;
using Newtonsoft.Json;


namespace FiletypeAPI.Parsers
{
    public class JSONParser
    {
        public JSONParser()
        {

        }
        public Me ParseJSON(string json)
        {
            var me = JsonConvert.DeserializeObject<Me>(json);
            return me;
        }

    }
}
