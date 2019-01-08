using System.Windows;
using DreamTrip.Desktop.Enums;
using DreamTrip.Desktop.Views;

namespace DreamTrip.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewBaseModel
    {
        public static string PathAPI = "http://localhost:8081/api/";
        public MainWindowViewModel()
        {
            OpenUsersView = new ChooseModuleCommand(Signal, AvailableViews.UsersView);
            OpenAgencyView = new ChooseModuleCommand(Signal, AvailableViews.AgencyView);
            OpenTripView = new ChooseModuleCommand(Signal, AvailableViews.TripView);
            OpenCityView = new ChooseModuleCommand(Signal, AvailableViews.CityView);
            OpenCountryView = new ChooseModuleCommand(Signal, AvailableViews.CountryView);
            OpenImageView = new ChooseModuleCommand(Signal, AvailableViews.ImageView);
        }

        #region Fields
        #region CurrentContent
        private object _currentContent;
        public object CurrentContent
        {
            get => _currentContent;
            set
            {
                _currentContent = value;
                OnPropertyChanged("CurrentContent");
            }
        }
        #endregion

        public ChooseModuleCommand OpenUsersView { get; set; }
        public ChooseModuleCommand OpenAgencyView { get; set; }
        public ChooseModuleCommand OpenTripView { get; set; }
        public ChooseModuleCommand OpenCityView { get; set; }
        public ChooseModuleCommand OpenCountryView { get; set; }
        public ChooseModuleCommand OpenImageView { get; set; }

        public void Signal(AvailableViews view)
        {
            switch (view)
            {
                case AvailableViews.UsersView:
                    CurrentContent = new UsersView();
                    break;
                case AvailableViews.AgencyView:
                    CurrentContent = new AgenciesView();
                    break;
                case AvailableViews.TripView:
                    CurrentContent = new TripsView();
                    break;
                case AvailableViews.CityView:
                    CurrentContent = new CitiesView();
                    break;
                case AvailableViews.CountryView:
                    CurrentContent = new CountriesView();
                    break;
                case AvailableViews.ImageView:
                    CurrentContent = new ImageView();
                    break;
            }
        }
        #endregion
    }
}
