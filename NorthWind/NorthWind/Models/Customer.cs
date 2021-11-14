using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace NorthWind.Models
{
    public class Customer : INotifyPropertyChanged

    {
        public static IList<Customer> Customers;
        static Customer()
        {
            Customers = new ObservableCollection<Customer>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string customerID;
        private string companyName;
        private string contactName;
        private string city;
        private string country;
        private string phone;

        public string CustomerID
        {
            get { return customerID; }
            set {
                customerID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustomerID"));
            }
        }
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CompanyName"));
            }
        }
        public string ContactName
        {
            get { return contactName; }
            set
            {
                contactName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ContactName"));
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("City"));
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Country"));
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Phone"));
            }
        }

        public string Location
        {
            get { return string.Format("{0},{1},City,Country"); }
            
        }
        public static void SampleData()
        {
            Customers.Clear();
            Customers.Add(new Customer
            {
                CustomerID = "ALFKI",
                CompanyName = "Alfrends Futterkiste",
                ContactName = "Maria Anders",
                City = "Munchen",
                Country = "Germany",
                Phone = "089-0877310"
            });
            Customers.Add(new Customer
            {
                CustomerID = "ALFKI2",
                CompanyName = "Alfrends Futterkiste2",
                ContactName = "Maria Anders2",
                City = "Munchen2",
                Country = "Germany2",
                Phone = "089-08773102"
            });
        }

    }
}
