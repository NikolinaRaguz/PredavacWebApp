using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PredavacWebApplication.Models
{
    public class KolegijPredavacViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Naziv Kolegija")]
        public string Naziv { get; set; }
        [Display(Name = "Nositelj Kolegija")]
        public string Nositelj { get; set; }
        [Display(Name = "Studijska Godina")]
        public int StudijskaGod { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [Display(Name = "Tema Predavanja")]
        public string Tema { get; set; }
        [Display(Name = "Datum Predavanja")]
        public DateTime Datum { get; set; }
    }
}