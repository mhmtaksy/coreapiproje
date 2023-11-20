using coreapiproje.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace coreapiproje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiyafetController : ControllerBase
    {
        public readonly ApplicationDbContext application;
        public KiyafetController(ApplicationDbContext application)
        {
            this.application = application;
        }
        [HttpGet]
        public IActionResult Indexkyft()
        {
            return Ok(application.kiyafetlers.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult IndexkyftID(int id)
        {
            return Ok(application.kiyafetlers.FirstOrDefault(m => m.kiyafetID == id));

        }
        [HttpPost]
        public IActionResult Addkyft(Kiyafetler kiyafetler)
        {
            application.Add(kiyafetler);
            application.SaveChanges();
            return Created("", kiyafetler);
        }
        [HttpPut("{id}")]
        public IActionResult Updatekyft(int id,Kiyafetler kiyafetler)
        {
            var update = application.kiyafetlers.FirstOrDefault(i => i.kiyafetID == id);
            update.kiyafetAdi=kiyafetler.kiyafetAdi;
            update.uretimYeri = kiyafetler.uretimYeri;
            update.uretimTarihi = kiyafetler.uretimTarihi;
            update.magazaID = kiyafetler.magazaID;
            application.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete= application.kiyafetlers.FirstOrDefault(i => i.kiyafetID == id);
            application.Remove(delete);
            application.SaveChanges();
            return NoContent();
        }
    }
}
