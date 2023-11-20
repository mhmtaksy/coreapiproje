using coreapiproje.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace coreapiproje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElemanController : ControllerBase
    {
        public readonly ApplicationDbContext application;
        public ElemanController(ApplicationDbContext application)
        {
            this.application = application;
        }
        [HttpGet]
        public IActionResult Indexelmn()
        {
            return Ok(application.elemanlars.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult IndexelmnID(int id)
        {
            return Ok(application.elemanlars.FirstOrDefault(m => m.elemanID == id));

        }
        [HttpPost]
        public IActionResult Addelmn(Elemanlar elemanlar)
        {
            application.Add(elemanlar);
            application.SaveChanges();
            return Created("", elemanlar);
        }
        [HttpPut("{id}")]
        public IActionResult Updateelmn(int id, Elemanlar elemanlar)
        {
            var update = application.elemanlars.FirstOrDefault(i => i.elemanID == id);
            update.elemanAdi = elemanlar.elemanAdi;
            update.elemanSoyadi = elemanlar.elemanSoyadi;
            update.elemanCinsiyet = elemanlar.elemanCinsiyet;
            update.kiyafetID = elemanlar.kiyafetID;
            application.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deleteelmn(int id)
        {
            var delete = application.elemanlars.FirstOrDefault(i => i.elemanID == id);
            application.Remove(delete);
            application.SaveChanges();
            return NoContent();
        }


    }
}
