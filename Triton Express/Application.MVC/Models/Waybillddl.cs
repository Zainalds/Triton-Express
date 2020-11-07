using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Application.MVC.Models
{
    public class Waybillddl
    {
        private string AUTHER_URL = "https://localhost:44349/";

        //DropDown

        public IEnumerable<WaybillViewModel> GetVehicleId()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AUTHER_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Vehicles").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<WaybillViewModel>>().Result;
                return null;
            }
            catch
            {
                return null;
            }

        }
    }
}
