using AppMobile.Models;
using AppMobile.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Views.Services
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesForm : ContentPage
    {
        ServiceRepository _serviceRepository = new ServiceRepository();
        public ServicesForm()
        {
            InitializeComponent();
        }

        private async void BtnSaveService_Clicked(object sender, EventArgs e)
        {
            string name = TxtName.Text;
            string description = TxtDescription.Text;
            string location = TxtLocation.Text;
            string image = TxtImage.Text;

            if (String.IsNullOrEmpty(name))
            {
                await DisplayAlert("Warning", "Type name", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(description))
            {
                await DisplayAlert("Warning", "Type description", "Ok");
                return;
            }

            if (String.IsNullOrEmpty(location))
            {
                await DisplayAlert("Warning", "Type location", "Ok");
                return;
            }

            ServiceModel service = new ServiceModel();
            service.Name = name;
            service.Description = description;
            service.Location = location;
            service.Image = image;

            var isSaved = await _serviceRepository.Save(service);

            if (isSaved)
            {
                await DisplayAlert("Information", "Service has been saved", "Ok");
                Clear();
            }
            else
            {
                await DisplayAlert("Error", "Service saved failed", "Ok");
            }
        }

        private void Clear()
        {
            TxtName.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            TxtLocation.Text = string.Empty;
            TxtImage.Text = string.Empty;
        }
    }
}