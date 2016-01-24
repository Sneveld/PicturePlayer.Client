using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PicturePlayer.Client.View.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WebPageView : UserControl
    {
        public WebPageView()
        {
            this.InitializeComponent();
            WVWebBrowser.Navigate(new Uri("http://www.google.com"));  

        }
    }
}
