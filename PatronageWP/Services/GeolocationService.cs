using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using Windows.Devices.Geolocation;

namespace PatronageWP.Services
{
    class GeolocationService
    {
        private Geoposition position;

        public double GetLatitude()
        {
            if (position == null) return 0;
            return position.Coordinate.Point.Position.Latitude;
        }
        public double GetLongitude()
        {
            if (position == null) return 0;
            return position.Coordinate.Point.Position.Longitude;
        }

        public async void GetLocation() {
            position = await new Geolocator().GetGeopositionAsync();
        }
        public double GetDistanceTo(double lat, double lon)
        {         
            return new GeoCoordinate(GetLatitude(), GetLongitude()).GetDistanceTo(new GeoCoordinate(lat, lon));
        }
    }
}
