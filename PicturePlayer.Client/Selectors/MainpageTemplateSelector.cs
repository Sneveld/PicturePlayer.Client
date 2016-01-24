using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PicturePlayer.Client.ViewModel.ViewModel;

namespace PicturePlayer.Client.View.Selectors
{
    public class MainpageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WaitTemplate { get; set; }
        public DataTemplate PictureViewTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is PictureViewModel)
                return this.PictureViewTemplate;
     
                return this.WaitTemplate;


        }
    }
}
