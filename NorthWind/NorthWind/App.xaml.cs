using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NorthWind.Views;

namespace NorthWind
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CustomerList());
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
