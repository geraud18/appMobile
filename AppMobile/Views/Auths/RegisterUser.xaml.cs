﻿using System;
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
    public partial class RegisterUser : ContentPage
    {
        UserRepository _userRepository = new UserRepository();
        public RegisterUser()
        {
            InitializeComponent();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                string email = TxtEmail.Text;
                string password = TxtPassword.Text;
                string confirmPassword = TxtConfirmPassword.Text;

                if (String.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Warning", "Type name", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Type email", "Ok");
                    return;
                }
               
                if (String.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Type password", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(confirmPassword))
                {
                    await DisplayAlert("Warning", "Type Confirm Password", "Ok");
                    return;
                }
                if (password != confirmPassword)
                {
                    await DisplayAlert("Warning", "Password not macht", "Ok");
                    return;
                }

                bool isSave = await _userRepository.Register(email, name, password);
                if (isSave)
                {
                    await DisplayAlert("Register user", "Registration completed", "Ok");
                    await Navigation.PushModalAsync(new RegisterUser());
                }
                else
                {
                    await DisplayAlert("Register user", "Registration failed", "Ok");
                }
            }
            catch(Exception exception) 
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Warning", "Email exist", "OK");
                }
                else
                {
                    await DisplayAlert("Error",exception.Message, "OK");
                }
            }
           

        }

        private async void LoginTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}