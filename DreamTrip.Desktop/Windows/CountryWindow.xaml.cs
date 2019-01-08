using System.Windows;
using DreamTrip.Desktop.ViewModels;
using DreamTrip.Desktop.Views;
using DreamTrip.WebApi.Models;

namespace DreamTrip.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for CountryWindow.xaml
    /// </summary>
    public partial class CountryWindow : Window
    {
        private static readonly string Path = MainWindowViewModel.PathAPI + "City";
        public Country City { get; set; }
        private CountriesView Parent { get; set; }
        public bool IsEdit { get; set; }

        public CountryWindow()
        {
            InitializeComponent();
        }
    }
}
