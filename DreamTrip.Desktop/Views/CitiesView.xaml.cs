using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DreamTrip.Desktop.ViewModels;
using DreamTrip.Desktop.Windows;
using DreamTrip.WebApi.Models;

namespace DreamTrip.Desktop.Views
{
    /// <summary>
    /// Interaction logic for CitiesView.xaml
    /// </summary>
    public partial class CitiesView : UserControl
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "User";
        public CitiesView()
        {
            InitializeComponent();
            Update();
        }

        #region Http
        static async Task<City> GetAgency(int id)
        {
            City project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<City>();
            }
            return project;
        }

        static async Task<City> DeleteAgency(int id)
        {
            City project = null;

            var response = await MainWindowViewModel.Client.DeleteAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<City>();
            }
            return project;
        }

        static async Task<IEnumerable<City>> GetAgencyAll()
        {
            IEnumerable<City> project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<IEnumerable<City>>();
            }
            return project;
        }

        #endregion

        private async void ButtonAgencies_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void UpdateBlogs(IEnumerable<City> list)
        {
            Cities.Items.Clear();
            foreach (var item in list)
            {
                Cities.Items.Add(item);
            }
        }

        private void SelectAgency_Click(object sender, RoutedEventArgs e)
        {
            (new CityWindow(null, this)).Show();
        }

        private void EditAgency_Click(object sender, RoutedEventArgs e)
        {
            var agency = Cities.SelectedItem as City;
            new CityWindow(agency, this).Show();
        }

        private async void DeleteThis_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var deleteAgency = await DeleteAgency((Cities.SelectedItem as City).Id);
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
