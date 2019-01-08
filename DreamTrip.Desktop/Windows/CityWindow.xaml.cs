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
    /// Interaction logic for CityWindow.xaml
    /// </summary>
    public partial class CityWindow : Window
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "City";
        public City City { get; set; }
        private CitiesView Parent { get; set; }
        public bool IsEdit { get; set; }

        public CityWindow(City city, CitiesView parent)
        {
            InitializeComponent();
            Parent = parent;
            if (city == null)
            {
                IsEdit = false;
                city = new City();
            }
            else
            {
                IsEdit = true;
            }

            City = city;

            AgencyId.Text = "" + City.Id;
            AgencyName.Text = City.Name;
        }

        static async Task<City> PostAgency(City agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PostAsync(Path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<City>();
            }
            return agency;
        }

        static async Task<City> PutAgency(City agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PutAsync(Path + "/" + agency.Id, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<City>();
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
