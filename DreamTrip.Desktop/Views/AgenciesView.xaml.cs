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
    /// Interaction logic for AgenciesView.xaml
    /// </summary>
    public partial class AgenciesView : UserControl
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "Agency";

        public AgenciesView()
        {
            InitializeComponent();
            Update();
        }

        #region Http
        static async Task<Agency> GetAgency(int id)
        {
            Agency project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<Agency>();
            }
            return project;
        }

        static async Task<Agency> DeleteAgency(int id)
        {
            Agency project = null;

            var response = await MainWindowViewModel.Client.DeleteAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<Agency>();
            }
            return project;
        }

        static async Task<IEnumerable<Agency>> GetAgencyAll()
        {
            IEnumerable<Agency> project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<IEnumerable<Agency>>();
            }
            return project;
        }
        
        #endregion

        private async void ButtonAgencies_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void UpdateBlogs(IEnumerable<Agency> list)
        {
            Agencies.Items.Clear();
            foreach (var item in list)
            {
                Agencies.Items.Add(item);
            }
        }

        private void SelectAgency_Click(object sender, RoutedEventArgs e)
        {
            (new AgencyWindow(null, this)).Show();
        }

        private void EditAgency_Click(object sender, RoutedEventArgs e)
        {
            var agency = Agencies.SelectedItem as Agency;
            new AgencyWindow(agency, this).Show();
        }

        private async void DeleteThis_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var deleteAgency = await DeleteAgency((Agencies.SelectedItem as Agency).Id);
                var list = await GetAgencyAll();
                UpdateBlogs(list);
            }
        }


        public async void Update()
        {
            var list = await GetAgencyAll();
            UpdateBlogs(list);
        }
    }
}
