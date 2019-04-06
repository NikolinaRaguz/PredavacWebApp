using System.Data.Entity;

namespace PredavacWebApplication.Models
{
    public class KolegijDBContext : DbContext
    {
        public KolegijDBContext() : base("name=KolegijDBContext")
        {

        }



        public DbSet<Kolegij> Kolegij { get; set; }
        public DbSet<Predavac> Predavac { get; set; }
    }

}