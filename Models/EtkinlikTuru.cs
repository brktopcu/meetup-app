using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etkinlikSitesi.Models
{
    public class EtkinlikTuru
    {
        public int EtkinlikTuruID { get; set; }

        public string EtkinlikTuruAdi { get; set; }
        public string EtkinlikTuruAciklama { get; set; }
        public byte[] EtkinlikTuruResmi { get; set; }



        public virtual ICollection<Etkinlik> Etkinlik { get; set; }
    }
}