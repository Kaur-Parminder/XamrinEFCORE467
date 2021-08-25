using System.ComponentModel;
using Xamarin.Forms;
using XamrinEFCORE467.ViewModels;

namespace XamrinEFCORE467.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}