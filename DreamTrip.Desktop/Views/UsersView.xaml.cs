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
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "User";
        public UsersView()
        {
            InitializeComponent();
            Update();
        }


        #region Http
        static async Task<User> GetAgency(int id)
        {
            User project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<User>();
            }
            return project;
        }

        static async Task<User> DeleteAgency(int id)
        {
            User project = null;

            var response = await MainWindowViewModel.Client.DeleteAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<User>();
            }
            return project;
        }

        static async Task<IEnumerable<User>> GetAgencyAll()
        {
            IEnumerable<User> project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<IEnumerable<User>>();
            }
            return project;
        }

        #endregion

        private async void ButtonAgencies_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void UpdateBlogs(IEnumerable<User> list)
        {
            Users.Items.Clear();
            foreach (var item in list)
            {
                Users.Items.Add(item);
            }
        }

        private void SelectAgency_Click(object sender, RoutedEventArgs e)
        {
            (new UserWindow(null, this)).Show();
        }

        private void EditAgency_Click(object sender, RoutedEventArgs e)
        {
            var agency = Users.SelectedItem as User;
            new UserWindow(agency, this).Show();
        }

        private async void DeleteThis_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var deleteAgency = await DeleteAgency((Users.SelectedItem as Agency).Id);
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
