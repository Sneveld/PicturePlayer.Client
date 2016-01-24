using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PicturePlayer.Client.ViewModel.ViewModel;

namespace PicturePlayer.Client.View.Selectors
{
    public class PicturePageSelector : DataTemplateSelector
    {
        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate WebTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is WebViewModel)
                return this.WebTemplate;

            return this.ImageTemplate;


        }
    }
}
