using AppMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile.Views.Service
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceDetailsPage : ContentPage
    {
        public ServiceDetailsPage(ServiceModel serviceModel)
        {
            InitializeComponent();
            LabelName.Text = serviceModel.Name;
        }
    }
}