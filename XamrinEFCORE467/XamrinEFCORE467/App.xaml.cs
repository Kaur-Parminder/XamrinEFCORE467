using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamrinEFCORE467.Services;
using XamrinEFCORE467.Views;

namespace XamrinEFCORE467
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
