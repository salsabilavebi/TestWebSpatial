using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebConsumAPI.Models;

namespace WebConsumAPI.Controllers
{
    public class PlaceController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7040/api");

        private readonly HttpClient client;

        public PlaceController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Places/Get").Result;

            if(response.IsSuccessStatusCode)
            {
                PlaceViewModel placeResult = response.Content.ReadAsAsync<PlaceViewModel>().Result;
               
            }
            return View();
        }

        [HttpGet]

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]

        public IActionResult Create(PlaceViewModel model)
        {

            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Places/Store", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Data Ditambahkan";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View(model);
        }

        
    }
}
