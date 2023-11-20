using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreapiproje.Model
{
    public class Müsteriler
    {
        [Key]
        public int müsteriID { get; set; }
        public string müsteriAdi { get; set; }
        public string müsteriSoyadi { get; set; }

        public DateTime müsteriDogumTarihi { get; set; }
        public bool müsteriCinsiyet {get; set; }
        public int elemanID { get; set; }
        [ForeignKey("elemanID")]
        public Elemanlar elemanlar { get; set; }
    }
}
