using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronageWP
{
    class Place : ObservableObject
    {
        public string Id { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                RaisePropertyChanged("Latitude");
            }
        }

        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                RaisePropertyChanged("Longitude");
            }
        }

        private bool hasWifi;
        public bool HasWifi
        {
            get
            {
                return hasWifi;
            }
            set
            {
                hasWifi = value;
                RaisePropertyChanged("HasWifi");
            }
        }

        public override string ToString()
        {
            return Name + ", " + Address;
        }

    }
}
