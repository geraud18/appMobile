using AppMobile.Models;
using AppMobile.Repository;
using AppMobile.Views.Service;
using AppMobile.Views.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesPage : ContentPage
    {
        ServiceRepository _serviceRepository = new ServiceRepository();
        public ServicesPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            var services = await _serviceRepository.GetAll();
            ServiceListView.ItemsSource = services;
        }

        private async void AddServicesItem_Cliked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ServicesForm());
        }

        private void ServiceListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item == null)
            {
                return;
            }
            var service = e.Item as ServiceModel;
            Navigation.PushModalAsync(new ServiceDetailsPage(service));
            ((ListView)sender).SelectedItem = null;

        }
    }
}