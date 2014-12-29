using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace PatronageWP
{
    class PlaceService
    {
        private static List<Place> places = new List<Place>();

        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://patronatwp.azure-mobile.net/",
            "uUmwvehkLigKjTZAaXPgMeDQpMknrf85"
        );

        public async Task AddPlace(Place Place)
        {
            places.Add(Place);
            await MobileService.GetTable<Place>().InsertAsync(Place);
        }

        public List<Place> GetPlaces()
        {
            return places;
            //return await MobileService.GetTable<Place>().ToCollectionAsync().ContinueWith(t => t.Result.ToList());
        }
    }
}
