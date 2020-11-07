using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Application.MVC.Models;
using Application.MVC.Webservice;
using Microsoft.AspNetCore.Mvc;

namespace Application.MVC.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public IActionResult Index(string searchString)
        {
            IEnumerable<VehicleViewModel> list;
            HttpResponseMessage response = Globalvariables.client.GetAsync("api/Vehicles").Result;
            list = response.Content.ReadAsAsync<IEnumerable<VehicleViewModel>>().Result;
            return View(list);
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new VehicleViewModel());
            }
            else
            {
                HttpResponseMessage response = Globalvariables.client.GetAsync("api/Vehicles/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<VehicleViewModel>().Result);
            }
        }
        [HttpPost]
        public IActionResult AddOrEdit(VehicleViewModel emp)
        {
            if (emp.Vehicle_Registration_Number == 0)
            {
                HttpResponseMessage response = Globalvariables.client.PostAsJsonAsync("api/Vehicles", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = Globalvariables.client.PutAsJsonAsync("api/Vehicles/" + emp.Vehicle_Registration_Number, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
    }
}