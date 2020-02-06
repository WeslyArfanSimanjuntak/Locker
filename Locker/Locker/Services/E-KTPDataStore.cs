using Locker.Models.E_KTP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Locker.Services
{
   public class E_KTPDataStore
    {
        HttpClient client;
        Content items;
        private static string BackEndUrl = "http://ajk-aga.indosuryalife.co.id/hlt/EKTPApi/ceknik";
        public E_KTPDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{BackEndUrl}/");

            items = new Content();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<Content> GetItemsAsync(string nik, bool forceRefresh = true)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync(nik);
                var rootObject = await Task.Run(() => JsonConvert.DeserializeObject<RootObject>(json));
                items = rootObject.content.FirstOrDefault();
            }

            return items;
        }

    }
}
