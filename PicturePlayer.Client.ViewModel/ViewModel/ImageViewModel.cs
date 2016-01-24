using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using PicturePlayer.Client.Model;
using PicturePlayer.Client.Model.PicturesView;

namespace PicturePlayer.Client.ViewModel.ViewModel
{
    /// <summary>
    /// Занимается отображением картинок
    /// </summary>
    public class ImageViewModel: ViewModelBase
    {
        private readonly IBitmapImageService _bitmapImageService;
        //DispatcherTimer используется вследствие того, что отображение происходит в основном потоке UI
        private DispatcherTimer mTimer;
        private List<PictureQueryItem> mPictureQueryItems;


        public void PutPictureQuery(IEnumerable<PictureQueryItem> pictureQueryItems)
        {
           
            mPictureQueryItems = pictureQueryItems.ToList().OrderBy(c=>c.StartTime).ToList();

            if (mPictureQueryItems.Count == 0)
                Close();

            mTimer.Interval = mPictureQueryItems.First().StartTime;
            mTimer.Tick += mTimer_Tick;
        }

        void mTimer_Tick(object sender, object e)
        {
            ConfigTimer();
        }

        public void Start()
        {
            if (mTimer!=null)
                mTimer.Start();
        }

        public void Stop()
        {
            if (mTimer != null)
                mTimer.Stop();
        }

        private async void ConfigTimer()
        {
            mTimer.Stop();

            var firstItem = mPictureQueryItems.FirstOrDefault();
            mPictureQueryItems.Remove(firstItem);

            await _bitmapImageService.SetCurrentBitmapImage(firstItem.LocalLink);
            if (_bitmapImageService.CurrentPicture != null)
                Image = _bitmapImageService.CurrentPicture;

            
            var nextItem = mPictureQueryItems.FirstOrDefault();
            if (nextItem == null)
            {
                Close();
                return;
            }

            mTimer.Interval = nextItem.StartTime - mTimer.Interval;
            


            mTimer.Start();

        }

        private void Close()
        {
            //тут логика завершения приложения
            mTimer = null;
        }

        private BitmapImage mImage;
        /// <summary>
        /// Изображение, которое отображается на экране в текущий момент
        /// </summary>
        public BitmapImage Image
        {
            get { return mImage; }
            set
            {
                mImage = value;
                RaisePropertyChanged("Image");
            }
        }

        public ImageViewModel(IBitmapImageService bitmapImageService)
        {
            _bitmapImageService = bitmapImageService;
            mTimer = new DispatcherTimer();
        }

        public  void SetPictureQuery(IEnumerable<PictureQueryItem> pictureQueryItems)
        {
            PutPictureQuery(pictureQueryItems);
        }

    }
}
