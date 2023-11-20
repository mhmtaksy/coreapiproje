using coreapimvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace coreapimvc.Controllers
{
    public class KiyafetController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44363/api/Kiyafet").Result;

            List<Kiyafetler> kiyafetlers;

            kiyafetlers = JsonConvert.DeserializeObject<List<Kiyafetler>>(response.Content.ReadAsStringAsync().Result);

            return View(kiyafetlers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Kiyafetler());


        }



        [HttpPost]
        public IActionResult Create(Kiyafetler kiyafetler)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(kiyafetler), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44363/api/Kiyafet", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44363/api/Magaza/{id}").Result;



            var kiyafetler = JsonConvert.DeserializeObject<Kiyafetler>(response.Content.ReadAsStringAsync().Result);

            return View(kiyafetler);
        }

        [HttpPost]
        public IActionResult Edit(Kiyafetler kiyafetler)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(kiyafetler), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44363/api/Magaza/{kiyafetler.kiyafetID}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44363/api/Kiyafet/{id}").Result;
            return RedirectToAction("Index");

        }
    }
}
