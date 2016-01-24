using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PicturePlayer.Client.Model;

namespace PicturePlayer.Client.ViewModel.ViewModel
{
 /// <summary>
 /// ������� VM ����������. �������� � �������� ���������
 /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //������������ �� ������� ��������� ������
            Messenger.Default.Register<IEnumerable<PictureQueryItem>>(this, StartViewPictures);

            CurrenViewModel = ViewModelLocator.Instance.Wait;
            ViewModelLocator.Instance.Wait.StartGetDataProcess();
        }

        private ViewModelBase mCurrenViewModel;

        /// <summary>
        /// VM, ��� ������� ����� ������������ View �� �����
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
        /// ��������� ������� ��������� ������
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