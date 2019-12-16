using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace etkinlikSitesi.Models
{
    public class Etkinlik
    {
        public int EtkinlikID { get; set; }
        public int EtkinlikTuruID { get; set; }
        public string EtkinlikAdi { get; set; }
        public string EtkinlikAciklama { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EtkinlikZamani { get; set; }
        public string EtkinlikYeri { get; set; }


        public virtual ICollection<Kayit> Kayit { get; set; }
        public virtual EtkinlikTuru EtkinlikTuru { get; set; }
    }
}