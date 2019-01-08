using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using DreamTrip.Desktop.ViewModels;
using DreamTrip.Desktop.Views;
using DreamTrip.WebApi.Models;
using Newtonsoft.Json;

namespace DreamTrip.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for AgencyWindow.xaml
    /// </summary>
    public partial class AgencyWindow : Window
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "Agency";
        public Agency Agency { get; set; }
        private AgenciesView Parent { get; set; }
        public bool IsEdit { get; set; }

        public AgencyWindow(Agency agency, AgenciesView parent)
        {
            InitializeComponent();
            Parent = parent;
            if (agency == null)
            {
                IsEdit = false;
                agency = new Agency();
            }
            else
            {
                IsEdit = true;
            }
                
            Agency = agency;

            AgencyId.Text = "" + Agency.Id;
            AgencyName.Text = Agency.Name;
        }

        static async Task<Agency> PostAgency(Agency agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PostAsync(Path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<Agency>();
            }
            return agency;
        }

        static async Task<Agency> PutAgency(Agency agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PutAsync(Path + "/" + agency.Id, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<Agency>();
            }
            return agency;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Parent.Update();
            this.Hide();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Agency.Name = AgencyName.Text;
            if (IsEdit)
            {
                var agency = await PutAgency(Agency);
            }
            else
            {
                var agency = await PostAgency(Agency);
            }
            Parent.Update();
            this.Hide();
        }
    }
}
