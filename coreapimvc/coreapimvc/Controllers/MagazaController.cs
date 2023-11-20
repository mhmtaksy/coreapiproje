using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using coreapimvc.Models;


namespace coreapimvc.Controllers
{
    public class MagazaController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44363/api/Magaza").Result;

            List<Magazalar> magazalars;

            magazalars = JsonConvert.DeserializeObject<List<Magazalar>>(response.Content.ReadAsStringAsync().Result);

            return View(magazalars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Magazalar());


        }



        [HttpPost]
        public IActionResult Create(Magazalar magazalar)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(magazalar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44363/api/Magaza", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44363/api/Magaza/{id}").Result;



            var magazalar = JsonConvert.DeserializeObject<Magazalar>(response.Content.ReadAsStringAsync().Result);

            return View(magazalar);
        }

        [HttpPost]
        public IActionResult Edit(Magazalar magazalar)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(magazalar), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44363/api/Magaza/{magazalar.magazaID}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44363/api/Magaza/{id}").Result;
            return RedirectToAction("Index");

        }

    }
}
