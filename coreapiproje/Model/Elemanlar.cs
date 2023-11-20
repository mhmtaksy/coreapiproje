using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreapiproje.Model
{
    public class Elemanlar
    {
        [Key]
        public int elemanID { get; set; }
        public string elemanAdi { get; set; }
        public string elemanSoyadi { get; set; }

        public bool elemanCinsiyet { get; set; }

        public int kiyafetID { get; set; }
        [ForeignKey("kiyafetID")]
        public Kiyafetler kiyafetler { get; set; }
    }
}
