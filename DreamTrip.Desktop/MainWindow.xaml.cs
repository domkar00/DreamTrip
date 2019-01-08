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
using DreamTrip.WebApi.Models;
using Newtonsoft.Json;

namespace DreamTrip.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "User/login";
        public MainWindow()
        {
            InitializeComponent();
            MainMenu.IsEnabled = false;
            UsernameBox.Text = "";
        }

        public async void SingIn(object sender, RoutedEventArgs e)
        {
            var value = await PostUser(new User()
            {
                UserName = UsernameBox.Text,
                Password = PasswordBox.Password
            });
        }

        async Task<User> PostUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await MainWindowViewModel.Client.PostAsync(Path, stringContent);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
                var IsAdmin = user.UserTypeId == 2;
                EnableAccess(IsAdmin);
                if (!IsAdmin)
                {
                    MessageBox.Show("User is not an admin!");
                    ResetForm();
                }
            }
            else
            {
                MessageBox.Show("Login or password incorrect!");
                ResetForm();
            }
            return user;
        }

        private void EnableAccess(bool enable)
        {
            MainMenu.IsEnabled = enable;
            SingI1.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
            SingI2.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
            SingI3.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
            SingI4.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
            SingI5.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
            UsernameBox.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
            PasswordBox.Visibility = enable ? Visibility.Hidden : Visibility.Visible;
        }

        private void ResetForm()
        {
            UsernameBox.Text = "";
            PasswordBox.Password = "";
        }
    }
}
