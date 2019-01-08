using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DreamTrip.Desktop.ViewModels;
using DreamTrip.Desktop.Windows;
using DreamTrip.WebApi.Models;

namespace DreamTrip.Desktop.Views
{
    /// <summary>
    /// Interaction logic for CountriesView.xaml
    /// </summary>
    public partial class CountriesView : UserControl
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "Country";
        public CountriesView()
        {
            InitializeComponent();
            Update();
        }

        #region Http
        static async Task<Country> GetAgency(int id)
        {
            Country project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<Country>();
            }
            return project;
        }

        static async Task<Country> DeleteAgency(int id)
        {
            Country project = null;

            var response = await MainWindowViewModel.Client.DeleteAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<Country>();
            }
            return project;
        }

        static async Task<IEnumerable<Country>> GetAgencyAll()
        {
            IEnumerable<Country> project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<IEnumerable<Country>>();
            }
            return project;
        }

        #endregion

        private async void ButtonAgencies_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void UpdateBlogs(IEnumerable<Country> list)
        {
            Countries.Items.Clear();
            foreach (var item in list)
            {
                Countries.Items.Add(item);
            }
        }

        private void SelectAgency_Click(object sender, RoutedEventArgs e)
        {
            (new CountryWindow(null, this)).Show();
        }

        private void EditAgency_Click(object sender, RoutedEventArgs e)
        {
            var agency = Countries.SelectedItem as Country;
            new CountryWindow(agency, this).Show();
        }

        private async void DeleteThis_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var deleteAgency = await DeleteAgency((Countries.SelectedItem as Country).Id);
                Update();
            }
        }


        public async void Update()
        {
            var list = await GetAgencyAll();
            UpdateBlogs(list);
        }
    }
}
