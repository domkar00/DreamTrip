using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DreamTrip.Desktop.ViewModels;
using DreamTrip.Desktop.Views;
using DreamTrip.WebApi.Models;
using Newtonsoft.Json;

namespace DreamTrip.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for CountryWindow.xaml
    /// </summary>
    public partial class CountryWindow : Window
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "Country";
        public Country City { get; set; }
        private CountriesView Parent { get; set; }
        public bool IsEdit { get; set; }

        public CountryWindow(Country city, CountriesView parent)
        {
            InitializeComponent();
            if (city == null)
            {
                IsEdit = false;
                city = new Country();
            }
            else
            {
                IsEdit = true;
            }

            Parent = parent;
            City = city;

            AgencyId.Text = "" + City.Id;
            AgencyName.Text = City.Name;
        }


        static async Task<Country> PostAgency(Country agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PostAsync(Path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<Country>();
            }
            return agency;
        }

        static async Task<Country> PutAgency(Country agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PutAsync(Path + "/" + agency.Id, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<Country>();
            }
            return agency;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Parent.Update();
            this.Hide();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            City.Name = AgencyName.Text;
            if (IsEdit)
            {
                var agency = await PutAgency(City);
            }
            else
            {
                var agency = await PostAgency(City);
            }
            Parent.Update();
            this.Hide();
        }
    }
}
