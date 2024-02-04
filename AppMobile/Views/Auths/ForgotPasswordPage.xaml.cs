using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMobile.Repository;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        UserRepository _userRepository = new UserRepository();
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            if (String.IsNullOrEmpty(email))
            {
                await DisplayAlert("Warning", "Enter you email", "Ok");
                return;
            }

            bool isSend = await _userRepository.ResetPassword(email);
            if (isSend) 
            {
                await DisplayAlert("Reset Password", "Send link in your email.", "Ok");
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Reset Password", "Send link failed.", "Ok");
            }
        }
    }
}