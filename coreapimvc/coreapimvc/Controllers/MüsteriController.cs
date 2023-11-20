using coreapimvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace coreapimvc.Controllers
{
    public class MüsteriController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44363/api/Müsteri").Result;

            List<Müsteriler> müsterilers;

            müsterilers = JsonConvert.DeserializeObject<List<Müsteriler>>(response.Content.ReadAsStringAsync().Result);

            return View(müsterilers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Müsteriler());


        }



        [HttpPost]
        public IActionResult Create(Müsteriler müsterilers)
        {



            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(müsterilers), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://localhost:44363/api/Müsteri", content).Result;


            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44363/api/Müsteri/{id}").Result;



            var müsterilers = JsonConvert.DeserializeObject<Magazalar>(response.Content.ReadAsStringAsync().Result);

            return View(müsterilers);
        }

        [HttpPost]
        public IActionResult Edit(Kiyafetler kiyafetler)
        {
            HttpClient httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(kiyafetler), System.Text.Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync($"https://localhost:44363/api/Müsteri/{kiyafetler.kiyafetID}", content).Result;


            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = httpClient.DeleteAsync($"https://localhost:44363/api/Müsteri/{id}").Result;
            return RedirectToAction("Index");

        }
    }
}
