using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PicturePlayer.Client.Model
{
    public interface IPictureQueryItemJsonService
    {
        IEnumerable<PictureQueryItem> GetPictureQuery();
        void ProcessPictureQuery();
    }

    public class PictureQueryItemJsonService : IPictureQueryItemJsonService
    {
        private readonly IJsonConverter _jsonConverter;
        private readonly IPictureTransfer _pictureTransfer;

        public PictureQueryItemJsonService(IJsonConverter jsonConverter, IPictureTransfer pictureTransfer)
        {
            _jsonConverter = jsonConverter;
            _pictureTransfer = pictureTransfer;
        }

        //TODO
        private async Task<string> GetPictureQueryItemJson()
        {
            //надо по идее в конфиг вынести, но времени не хватало

            var postRequest =(HttpWebRequest)WebRequest.Create("http://pictureplayer.azurewebsites.net/api/PictureElementsWebApi");
            postRequest.Method = "GET";
            postRequest.CookieContainer = new CookieContainer();
            HttpWebResponse postResponse = null;
            try
            {
                postResponse = (HttpWebResponse)await postRequest.GetResponseAsync();
            }
            catch (Exception)
            {
                throw new Exception("Неверный запрос");
            }

            if (postResponse != null)
            {
                var postResponseStream = postResponse.GetResponseStream();
                var postStreamReader = new StreamReader(postResponseStream);

                string response = await postStreamReader.ReadToEndAsync();
                return response; // This is the response
            }
            return null;

        }
        



        private IEnumerable<PictureQueryItem> mPictureQueryItems;

        public IEnumerable<PictureQueryItem> GetPictureQuery()
        {
            return mPictureQueryItems;
        }

        public  void ProcessPictureQuery()
        {
            var json = GetPictureQueryItemJson();
            var picturesQueryJson = _jsonConverter.Parse(json.Result);
            var picturesQueryItems = _jsonConverter.Convert(picturesQueryJson);
             mPictureQueryItems =_pictureTransfer.GetPictures(picturesQueryItems).Result;
            
        }
      

    }
}
