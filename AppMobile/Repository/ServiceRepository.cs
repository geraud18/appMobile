using AppMobile.Models;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobile.Repository
{
    internal class ServiceRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://portalofservices-default-rtdb.firebaseio.com/");

        public async Task<bool> Save(ServiceModel services)
        {
            var data = await firebaseClient.Child(nameof(Services)).PostAsync(JsonConvert.SerializeObject(services));
            if(!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<ServiceModel>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Services)).OnceAsync<ServiceModel>()).Select(item => new ServiceModel
            {
                Name = item.Object.Name,
                Description = item.Object.Description,
                Location = item.Object.Location,
                Image = item.Object.Image,
                Id = item.Key
            }).ToList();
        }

    }
}
