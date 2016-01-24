using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PicturePlayer.Client.Model;

namespace PicturePlayer.Client.ViewModel.ViewModel
{
 /// <summary>
 /// √лавна€ VM приложени€. –аботает с основной страницей
 /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //подписываем€ на событие получени€ данных
            Messenger.Default.Register<IEnumerable<PictureQueryItem>>(this, StartViewPictures);

            CurrenViewModel = ViewModelLocator.Instance.Wait;
            ViewModelLocator.Instance.Wait.StartGetDataProcess();
        }

        private ViewModelBase mCurrenViewModel;

        /// <summary>
        /// VM, дл€ которой будет отображатьс€ View на форме
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

        /// <summary>
        /// ќбработка событи€ получени€ данных
        /// </summary>
        /// <param name="items"></param>
        private void StartViewPictures(IEnumerable<PictureQueryItem> items)
        {
            CurrenViewModel = ViewModelLocator.Instance.Picture;
            ViewModelLocator.Instance.Picture.SetPictureQuery(items);
            ViewModelLocator.Instance.Picture.Start();
        }


    }
}