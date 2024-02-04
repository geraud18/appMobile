using AppMobile.Views;
using AppMobile.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMenuPage : TabbedPage
    {
        public TabbedMenuPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            

            var homePage = new NavigationPage(new HomePage()) { Title = "Home" };
            Children.Add(homePage);

            Children.Add(new NavigationPage(new ServicesPage()) { Title = "Services" });
            Children.Add(new NavigationPage(new ReservationPage()) { Title = "Reservation" });
            Children.Add(new NavigationPage(new AccountPage()) { Title = "Account" });

            CurrentPage = homePage;
        }
    }
}