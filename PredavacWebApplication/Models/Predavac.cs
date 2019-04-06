using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PredavacWebApplication.Models
{
    public class Predavac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Display(Name = "Tema Predavanja")]
        public string Tema { get; set; }
        [Display(Name = "Datum Predavanja")]
        public DateTime Datum { get; set; }
        [Display(Name = "Broj Prisutnih Studenata")]
        public int BrStudent { get; set; }
        public int KolegijId { get; set; }

        public virtual Kolegij Kolegij { get; set; }
    }
}