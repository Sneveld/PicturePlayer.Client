using System.Collections.Generic;
using Newtonsoft.Json;

namespace PicturePlayer.Client.Model
{
    public class JsonParser
    {
        public IEnumerable<PictureQueryItemJson> Parse(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<PictureQueryItemJson>>(json);
        }
    }
}
