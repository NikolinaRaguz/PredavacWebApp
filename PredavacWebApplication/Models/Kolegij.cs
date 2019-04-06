using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PredavacWebApplication.Models
{
    public class Kolegij
    {
        public int Id { get; set; }
        [Display(Name ="Naziv Kolegija")]
        public string Naziv { get; set; }
        [Display(Name = "Nositelj Kolegija")]
        public string Nositelj { get; set; }
        [Display(Name = "Studijska Godina")]
        public int StudijskaGod { get; set; }

        public virtual ICollection<Predavac> Predavac { get; set; }
    }

}