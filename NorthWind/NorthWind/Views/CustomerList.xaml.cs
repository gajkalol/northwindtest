using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthWind.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerList : ContentPage
    {
        public CustomerList()
        {
            InitializeComponent();
            Customer.SampleData();
            BindingContext = Customer.Customers;
        }
        async void Customer_Tapped(object sender, ItemTappedEventArgs e)
        {
            Customer c = e.Item as Customer;
            if (c == null) return;
            await Navigation.PushAsync(new CustomerDetails(c));
        }
        async void Customer_Refreshing(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            listView.IsRefreshing = true;
            await Task.Delay(1500);
            listView.IsRefreshing = false;
        }

        void Customer_Deleted(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Customer c = menuItem.BindingContext as Customer;
            Customer.Customers.Remove(c);
        }
        async void Customer_Phoned(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Customer c = menuItem.BindingContext as Customer;
            if (await this.DisplayAlert("Dial a Number", "Would you like to call" + c.Phone + "?", "Yes", "No"))
            {
                var dialer = DependencyService.Get<iDialer>();
                if (dialer != null)
                    dialer.Dial(c.Phone);
            }
        }
        async void Add_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerDetails());
        }
    }
}