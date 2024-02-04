using AppMobile.Repository;
using AppMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserRepository _userRepository = new UserRepository();
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = TxtEmail.Text;
                string password = TxtPassword.Text;
                string token = await _userRepository.SingIn(email, password);

                if (String.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Enter you email", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Enter you password", "Ok");
                    return;
                }
                if (!string.IsNullOrEmpty(token))
                {
                    Preferences.Set("token", token);
                    Preferences.Set("emailUser", email);
                    await Navigation.PushAsync(new TabbedMenuPage());
                }
                else
                {
                    await DisplayAlert("Sign In", "Sign In failed", "OK");
                }
            }
            catch(Exception exception)
            {
                if (exception.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await DisplayAlert("Unauthorized", "Email not found", "OK");
                }
                else if(exception.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("Unauthorized", "Password incorrect", "OK");
                }
                else
                {
                    await DisplayAlert("Error", exception.Message, "OK");
                }
            }
        }

        private async void RegisterTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterUser());
        }

        private async void ForgotTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPasswordPage());
        }
    }
}