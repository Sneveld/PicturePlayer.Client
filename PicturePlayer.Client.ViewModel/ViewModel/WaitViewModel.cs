using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PicturePlayer.Client.Model;

namespace PicturePlayer.Client.ViewModel.ViewModel
{
    /// <summary>
    /// VM отображения процесса загрузки данных
    /// </summary>
    public class WaitViewModel: ViewModelBase
    {
        private readonly IPictureQueryItemJsonService _pictureQueryItemJsonService;

        public WaitViewModel(IPictureQueryItemJsonService pictureQueryItemJsonService)
        {
            _pictureQueryItemJsonService = pictureQueryItemJsonService;
        }

        /// <summary>
        /// Запуск процесса загрузки данных
        /// </summary>
        public void StartGetDataProcess()
        {
            IAsyncAction  asyncAction = ThreadPool.RunAsync((a) => _pictureQueryItemJsonService.ProcessPictureQuery());
            asyncAction.Completed = new AsyncActionCompletedHandler((IAsyncAction asyncInfo, AsyncStatus asyncStatus) => CompleteGetDataProcess());
        }


        
        private void CompleteGetDataProcess()
        {
            //Возвращаемся в основной поток сообщение озагрузке данных
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() =>
            {
                Messenger.Default.Send(_pictureQueryItemJsonService.GetPictureQuery());
            });
            
        }
    }
}
