using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using PatronageWP.Entity;

namespace PatronageWP.Services
{
    class PlaceService
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://patronatwp.azure-mobile.net/",
            "uUmwvehkLigKjTZAaXPgMeDQpMknrf85"
        );

        public async Task AddPlace(Place Place)
        {
            await MobileService.GetTable<Place>().InsertAsync(Place);
        }

        public async Task<List<Place>> GetPlaces()
        {
            return await MobileService.GetTable<Place>().ToCollectionAsync().ContinueWith(t => t.Result.ToList());
        }
    }
}
