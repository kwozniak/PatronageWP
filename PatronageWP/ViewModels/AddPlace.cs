using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace PatronageWP
{
    class AddPlace : ObservableObject
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
                    addCommand = new RelayCommand(() => Add());
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
                    clearCommand = new RelayCommand(() => Clear());
                }
                return clearCommand;
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

    }
}
