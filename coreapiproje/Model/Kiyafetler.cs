using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreapiproje.Model
{
    public class Kiyafetler
    {
        [Key]
        public int kiyafetID { get; set; }
        public string kiyafetAdi { get; set; }
        public string uretimYeri { get; set; }
        public DateTime uretimTarihi { get; set; }
        
        public int magazaID { get; set; }
        [ForeignKey("magazaID")]
        public Magazalar magazalar { get; set; }
    }
}
