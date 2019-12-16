using EtkinlikSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etkinlikSitesi.Models
{
    public class Kayit
    {
        public int KayitID { get; set; }
        public int EtkinlikID { get; set; }
        public string ApplicationUserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Etkinlik Etkinlik { get; set; }

    }
}