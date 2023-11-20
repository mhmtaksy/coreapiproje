using System.ComponentModel.DataAnnotations;

namespace coreapiproje.Model
{
    public class Magazalar
    {
        [Key]
        public int magazaID { get; set; }
        public string magazaAdi { get; set; }
        public string magazaAdres { get; set; }

        public int magazaCalisanSayisi { get; set; }

    }
}
