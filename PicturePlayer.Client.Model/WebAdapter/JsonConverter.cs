using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PicturePlayer.Client.Model
{
    public interface IJsonConverter
    {
        IEnumerable<PictureQueryItemJson> Parse(string json);
        IEnumerable<PictureQueryItem> Convert(IEnumerable<PictureQueryItemJson> jsonItems);
    }

    public class JsonConverter : IJsonConverter
    {
        public IEnumerable<PictureQueryItemJson> Parse(string json)
        {
          
            try
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<PictureQueryItemJson>>(json);
                if (result==null)
                    throw new Exception("Нет данных");
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Неверный формат json ");
            }

        }

        public IEnumerable<PictureQueryItem> Convert(IEnumerable<PictureQueryItemJson> jsonItems)
        {
            var qitems = new List<PictureQueryItem>();

            foreach (var pictureQueryItemJson in jsonItems)
            {
                var newqitem = new PictureQueryItem()
                {
                    StartTime = ConvertStringToTimeSpan(pictureQueryItemJson.StartTime),
                    Link = pictureQueryItemJson.Link,
                    Name = pictureQueryItemJson.Name,
                    ImageData=pictureQueryItemJson.ImageData,
                    ImageMimeType="."+pictureQueryItemJson.ImageMimeType.Substring(6)
                };
                qitems.Add(newqitem);
            }
            return qitems;
        }

        //TODO
        private TimeSpan ConvertStringToTimeSpan(string stringTimespan)
        {
            var h = Int32.Parse(stringTimespan.Substring(0, 2));
            var m = Int32.Parse(stringTimespan.Substring(3, 2));
            var s = Int32.Parse(stringTimespan.Substring(6, 2));
            return new TimeSpan(h,m,s);
        }
    }
}
