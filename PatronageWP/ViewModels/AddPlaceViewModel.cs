using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Devices.Geolocation;

namespace PatronageWP
{
    class AddPlaceViewModel : ObservableObject
    {
        private PlaceService PlaceService = new PlaceService();

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
                    addCommand = new RelayCommand(() => Add(), Validate);
                }
                return addCommand;
            }
        }

        private RelayCommand clearCommand = null;
        public RelayCommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(() => Confirm());
                }
                return clearCommand;
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
            Clear();
            await new MessageDialog("Place added.\nList size: " + PlaceService.GetPlaces().Count, "Success").ShowAsync();
        }

        private void Clear()
        {
            Place = new Place();
        }

        private bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Place.Name);
        }

        private async void Confirm()
        {
            var messageDialog = new MessageDialog("Are you sure?", "Confirmation");
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            Clear();
        }

        public async void GetLocation_Click()
        {
            Geolocator geo = new Geolocator();
            geo.DesiredAccuracyInMeters = 50;
            Geoposition pos = await geo.GetGeopositionAsync();
            Place.Latitude = pos.Coordinate.Point.Position.Latitude;
            Place.Longitude = pos.Coordinate.Point.Position.Longitude;
        }
    }
}
