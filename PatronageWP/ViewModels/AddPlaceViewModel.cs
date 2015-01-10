using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using PatronageWP.Common;
using PatronageWP.Entity;
using PatronageWP.Services;

namespace PatronageWP.ViewModels
{
    class AddPlaceViewModel : ObservableObject
    {
        private PlaceService PlaceService = new PlaceService();
        private NavigationService NavigationService = new NavigationService();
        private GeolocationService GeolocationService = new GeolocationService();

        private Place place = new Place();
        public Place Place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
                RaisePropertyChanged("Place");
            }
        }

        private RelayCommand addCommand = null;
        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(() => Add());
                }
                return addCommand;
            }
        }

        private RelayCommand cancelCommand = null;
        public RelayCommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(() => Confirm());
                }
                return cancelCommand;
            }
        }

        private RelayCommand getLocation = null;
        public RelayCommand GetLocation
        {
            get
            {
                if (getLocation == null)
                {
                    getLocation = new RelayCommand(() => GetLocation_Click());
                }
                return getLocation;
            }
        }

        private async void Add()
        {
            await PlaceService.AddPlace(Place);
            NavigationService.Navigate(typeof(ListPlacesPage));
        }

        private void Cancel()
        {
            Place = new Place();
            NavigationService.Navigate(typeof(ListPlacesPage));
        }

        private bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Place.Name);
        }

        private async void Confirm()
        {
            var messageDialog = new MessageDialog("Are you sure?", "Confirmation");
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(CancelCommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }

        private void CancelCommandInvokedHandler(IUICommand command)
        {
            Cancel();
        }

        public void GetLocation_Click()
        {
            GeolocationService.GetLocation();
            Place.Latitude = GeolocationService.GetLatitude();
            Place.Longitude = GeolocationService.GetLongitude();
        }
    }
}
