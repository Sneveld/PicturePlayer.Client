using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


namespace PicturePlayer.Client.Model
{
    public interface IPictureTransfer
    {
        Task<List<PictureQueryItem>> GetPictures(IEnumerable<PictureQueryItem> pictureQueryItems);
    }

    //TODO
    /// <summary>
    /// Сервис, отвечающий за прием и сохранения изобращений на локальном хранилище
    /// </summary>
    public class PictureTransfer : IPictureTransfer
    {
        public async Task<List<PictureQueryItem>> GetPictures(IEnumerable<PictureQueryItem> pictureQueryItems)
        {
            foreach (var pictureQueryItem in pictureQueryItems)
            {
                StorageFolder myfolder = ApplicationData.Current.LocalFolder;
                var fileName = pictureQueryItem.Name + pictureQueryItem.ImageMimeType;
                var sampleFile = await myfolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

                await FileIO.WriteBytesAsync(sampleFile, pictureQueryItem.ImageData);

                pictureQueryItem.LocalLink = "ms-appdata:///local/" + fileName;
            }

            return pictureQueryItems.ToList();

        }
    }
}
