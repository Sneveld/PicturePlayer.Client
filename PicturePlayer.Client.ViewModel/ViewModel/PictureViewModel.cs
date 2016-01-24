using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Networking.Proximity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PicturePlayer.Client.Model;
using PicturePlayer.Client.Model.PicturesView;

namespace PicturePlayer.Client.ViewModel.ViewModel
{
    /// <summary>
    /// Инкаспулирует логику смены отображений браузера и просмотра картинок
    /// </summary>
    public class PictureViewModel: ViewModelBase
    {
        public PictureViewModel()
        {
            CurrenViewModel = ViewModelLocator.Instance.Image;
        }

        public void Start()
        {
            ViewModelLocator.Instance.Image.Start();
        }

        public void SetPictureQuery(IEnumerable<PictureQueryItem> items)
        {
            ViewModelLocator.Instance.Image.SetPictureQuery(items);
        }

        private ViewModelBase mCurrenViewModel;
        /// <summary>
        /// VM, для которой будет отображаться View на форме
        /// </summary>
        public ViewModelBase CurrenViewModel
        {
            get { return mCurrenViewModel; }
            set
            {
                mCurrenViewModel = value;
                RaisePropertyChanged("CurrenViewModel");
            }
        }


        private RelayCommand mChageView;

        public ICommand ChageViewCommand
        {
            get { return new RelayCommand(mChageViewExecute); }
        }

        private void mChageViewExecute()
        {
            if (CurrenViewModel == ViewModelLocator.Instance.Image)
            {
                ViewModelLocator.Instance.Image.Stop();
                CurrenViewModel = ViewModelLocator.Instance.Web;
            }
            else
            {
                CurrenViewModel = ViewModelLocator.Instance.Image;
                ViewModelLocator.Instance.Image.Start();
            }


        }

    }
}
