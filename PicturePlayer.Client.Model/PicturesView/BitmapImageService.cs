using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


namespace PicturePlayer.Client.Model.PicturesView
{
    public interface IBitmapImageService
    {
        Task SetCurrentBitmapImage(string url);
        BitmapImage CurrentPicture { get; set; }
    }

    public class BitmapImageService : IBitmapImageService
    {
        public BitmapImage CurrentPicture { get; set; }
        public async Task SetCurrentBitmapImage(string url)
        {
            await CreateBitmapImage(url);
        }

        private async Task CreateBitmapImage(string url)
        {
            try
            {
                //TODO

                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(url));
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(fileStream);


                CurrentPicture  = image;
            }
            catch (Exception)
            {
                CurrentPicture = null;
            }
        }
    }
}
