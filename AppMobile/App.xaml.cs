using AppMobile.Services;
using AppMobile.Views;
using AppMobile.Views.Auths;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new StarterPage());
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
