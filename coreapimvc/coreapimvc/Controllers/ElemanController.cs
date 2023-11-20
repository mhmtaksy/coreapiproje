using coreapimvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace coreapimvc.Controllers
{
    public class ElemanController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44363/api/Eleman").Result;

            List<Elemanlar> Elemanlars;

            Elemanlars = JsonConvert.DeserializeObject<List<Elemanlar>>(response.Content.ReadAsStringAsync().Result);

            return View(Elemanlars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Elemanlar());


        }



        [HttpPost]
        public IActionResult Create(Elemanlar Elemanlars)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(Elemanlars), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44363/api/Eleman", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44363/api/Eleman/{id}").Result;



            var Elemanlars = JsonConvert.DeserializeObject<Kiyafetler>(response.Content.ReadAsStringAsync().Result);

            return View(Elemanlars);
        }

        [HttpPost]
        public IActionResult Edit(Elemanlar Elemanlars)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(Elemanlars), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44363/api/Magaza/{Elemanlars.elemanID}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44363/api/Eleman/{id}").Result;
            return RedirectToAction("Index");

        }
    }
}
