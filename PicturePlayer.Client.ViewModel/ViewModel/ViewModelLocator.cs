/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PicturePlayer.Client.ViewModel"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PicturePlayer.Client.Model;
using PicturePlayer.Client.Model.PicturesView;

namespace PicturePlayer.Client.ViewModel.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static ViewModelLocator mInstance;

        public static ViewModelLocator Instance
        {
            get
            {
                if(mInstance==null)
                    mInstance = new ViewModelLocator();
                return mInstance ;
            }
        }

        public static void InitInstance()
        {
            mInstance = new ViewModelLocator();
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<IJsonConverter, JsonConverter>();
            SimpleIoc.Default.Register<IPictureQueryItemJsonService, PictureQueryItemJsonService>();
            SimpleIoc.Default.Register<IPictureTransfer, PictureTransfer>();
            SimpleIoc.Default.Register<IBitmapImageService, BitmapImageService>();

            SimpleIoc.Default.Register<WaitViewModel>();
            SimpleIoc.Default.Register<PictureViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WebViewModel>();
            SimpleIoc.Default.Register<ImageViewModel>();
  
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public WaitViewModel Wait
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WaitViewModel>();
            }
        }
        public PictureViewModel Picture
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PictureViewModel>();
            }
        }

        public WebViewModel Web
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WebViewModel>();
            }
        }

        public ImageViewModel Image
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ImageViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}