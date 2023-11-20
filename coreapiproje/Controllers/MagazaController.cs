using coreapiproje.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace coreapiproje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazaController : ControllerBase
    {
        public readonly ApplicationDbContext application;
        public MagazaController(ApplicationDbContext application)
        {
            this.application = application;
        }
        [HttpGet]
        public IActionResult Indexmgz()
        {
            return Ok(application.magazalars.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult IndexmgzID(int id)
        {
            return Ok(application.magazalars.FirstOrDefault(m => m.magazaID == id));
        }
        [HttpPost]
        public IActionResult Addmgz(Magazalar magazalar)
        {
            application.Add(magazalar);
            application.SaveChanges();
            return Created("", magazalar);
        }
        [HttpPut("{id}")]
        public IActionResult Updatemgz(int id, Magazalar magazalar) 
        {
            var update = application.magazalars.FirstOrDefault(i=>i.magazaID==id);
            update.magazaAdi = magazalar.magazaAdi;
            update.magazaAdres = magazalar.magazaAdres;
            update.magazaCalisanSayisi = magazalar.magazaCalisanSayisi;
            application.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult Deletemgz(int id)
        {
            var delete = application.magazalars.FirstOrDefault(i=>i.magazaID==id);
            application.magazalars.Remove(delete);
            application.SaveChanges();
            return NoContent();
        }
    }
}
