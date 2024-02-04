using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Views.Auths
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarterPage : ContentPage
    {
        public StarterPage()
        {
            InitializeComponent();
        }

        private async void GetStarted_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterUser());
        }

        private async void SignIn_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

       
    }
}