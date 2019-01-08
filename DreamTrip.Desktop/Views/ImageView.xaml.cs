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
    /// Interaction logic for ImageView.xaml
    /// </summary>
    public partial class ImageView : UserControl
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "ImageSource";
        public ImageView()
        {
            InitializeComponent();
            Update();
        }

        #region Http
        static async Task<ImageSource> GetAgency(int id)
        {
            ImageSource project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<ImageSource>();
            }
            return project;
        }

        static async Task<ImageSource> DeleteAgency(int id)
        {
            ImageSource project = null;

            var response = await MainWindowViewModel.Client.DeleteAsync(Path + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<ImageSource>();
            }
            return project;
        }

        static async Task<IEnumerable<ImageSource>> GetAgencyAll()
        {
            IEnumerable<ImageSource> project = null;

            var response = await MainWindowViewModel.Client.GetAsync(Path);

            if (response.IsSuccessStatusCode)
            {
                project = await response.Content.ReadAsAsync<IEnumerable<ImageSource>>();
            }
            return project;
        }

        #endregion

        private async void ButtonAgencies_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void UpdateBlogs(IEnumerable<ImageSource> list)
        {
            Images.Items.Clear();
            foreach (var item in list)
            {
                Images.Items.Add(item);
            }
        }

        //private void SelectAgency_Click(object sender, RoutedEventArgs e)
        //{
        //    (new AgencyWindow(null, this)).Show();
        //}

        //private void EditAgency_Click(object sender, RoutedEventArgs e)
        //{
        //    var agency = Images.SelectedItem as ImageSource;
        //    new AgencyWindow(agency, this).Show();
        //}

        private async void DeleteThis_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var deleteAgency = await DeleteAgency((Images.SelectedItem as ImageSource).Id);
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
