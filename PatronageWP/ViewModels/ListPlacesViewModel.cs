using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatronageWP.Common;
using PatronageWP.Entity;
using PatronageWP.Services;

namespace PatronageWP.ViewModels
{
    class ListPlacesViewModel : ObservableObject
    {
        private PlaceService PlaceService = new PlaceService();
        private NavigationService NavigationService = new NavigationService();

        private List<Place> places = new List<Place>();
        public List<Place> Places
        {
            get
            {
                return places;
            }
            set
            {
                places = value;
                RaisePropertyChanged("Places");
            }
        }

        public ListPlacesViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            Places = await PlaceService.GetPlaces();
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

        private void Add()
        {
            NavigationService.Navigate(typeof(AddPlacePage));
        }
    }
}
