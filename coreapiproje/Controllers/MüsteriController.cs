using coreapiproje.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace coreapiproje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MüsteriController : ControllerBase
    {
        public readonly ApplicationDbContext application;
        public MüsteriController(ApplicationDbContext application)
        {
            this.application = application;
        }
        [HttpGet]
        public IActionResult Indexmstr()
        {
            return Ok(application.müsterilers.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult IndexmstrID(int id)
        {
            return Ok(application.müsterilers.FirstOrDefault(m => m.müsteriID == id));

        }
        [HttpPost]
        public IActionResult Addmstr(Müsteriler müsteriler)
        {
            application.Add(müsteriler);
            application.SaveChanges();
            return Created("", müsteriler);
        }
        [HttpPut("{id}")]
        public IActionResult Updatemstr(int id, Müsteriler müsteriler)
        {
            var update = application.müsterilers.FirstOrDefault(i => i.müsteriID == id);
            update.müsteriAdi = müsteriler.müsteriAdi;
            update.müsteriSoyadi = müsteriler.müsteriSoyadi;
            update.müsteriDogumTarihi = müsteriler.müsteriDogumTarihi;
            update.müsteriCinsiyet = müsteriler.müsteriCinsiyet;
            update.elemanID = müsteriler.elemanID;
            application.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletemstr(int id)
        {
            var delete = application.kiyafetlers.FirstOrDefault(i => i.kiyafetID == id);
            application.Remove(delete);
            application.SaveChanges();
            return NoContent();
        }
    }
}
