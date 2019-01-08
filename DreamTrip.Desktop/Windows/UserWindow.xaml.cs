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
using System.Windows.Shapes;
using DreamTrip.Desktop.ViewModels;
using DreamTrip.Desktop.Views;
using DreamTrip.WebApi.Models;
using Newtonsoft.Json;

namespace DreamTrip.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "User";
        public User User { get; set; }
        private UsersView Parent { get; set; }
        public bool IsEdit { get; set; }

        public UserWindow(User user, UsersView parent)
        {
            InitializeComponent();
            Parent = parent;
            if (user == null)
            {
                IsEdit = false;
                user = new User();
            }
            else
            {
                IsEdit = true;
            }

            User = user;

            AgencyId.Text = "" + User.Id;
            AgencyName.Text = User.UserName;


            UpdateBlogs(new List<AccessValue>
            {
                new AccessValue{Id = 1, Name = "User"},
                new AccessValue{Id = 2, Name = "Admin"}
            });
            CountryBox.SelectedValue = user.UserTypeId;
        }


        static async Task<User> PostAgency(User agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PostAsync(Path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<User>();
            }
            return agency;
        }

        static async Task<User> PutAgency(User agency)
        {
            var json = JsonConvert.SerializeObject(agency);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PutAsync(Path + "/" + agency.Id, stringContent);
            if (response.IsSuccessStatusCode)
            {
                agency = await response.Content.ReadAsAsync<User>();
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
            User.UserTypeId = Convert.ToInt32(CountryBox.SelectedValue.ToString());
            if (IsEdit)
            {
                var agency = await PutAgency(User);
            }
            else
            {
                var agency = await PostAgency(User);
            }
            Parent.Update();
            this.Hide();
        }
        
        private void UpdateBlogs(IEnumerable<AccessValue> list)
        {
            CountryBox.Items.Clear();
            foreach (var item in list)
            {
                CountryBox.Items.Add(item);
            }
        }
    }

    public class AccessValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
