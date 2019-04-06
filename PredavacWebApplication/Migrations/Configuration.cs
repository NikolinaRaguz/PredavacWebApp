namespace PredavacWebApplication.Migrations
{
    using PredavacWebApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PredavacWebApplication.Models.KolegijDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PredavacWebApplication.Models.KolegijDBContext context)
        {
            context.Kolegij.AddOrUpdate(i => i.Naziv,
                   new Kolegij
                   {
                       Id = 1,
                       Naziv = "Razvoj Poslovnih Aplikacija",
                       Nositelj = "Marijana Zekić-Sušac",
                       StudijskaGod = 3,
                   },
                    new Kolegij
                    {
                        Id = 2,
                        Naziv = "ICT u bankarstvu",
                        Nositelj = "Marijana Zekić-Sušac",
                        StudijskaGod = 3,
                    },
                    new Kolegij
                    {
                        Id = 3,
                        Naziv = "Oblikovanje i implementacija IS",
                        Nositelj = "Josip Mesarić",
                        StudijskaGod = 3,
                    },
                  new Kolegij
                  {
                      Id = 4,
                      Naziv = "Baze podataka i poslovni procesi",
                      Nositelj = "Branimir Dukić",
                      StudijskaGod = 3,
                  },
                  new Kolegij
                  {
                      Id = 5,
                      Naziv = "Upravljanje informacijskim resursima ",
                      Nositelj = "Josip Mesarić",
                      StudijskaGod = 2,
                  },
                  new Kolegij
                  {
                      Id = 6,
                      Naziv = "Matematika",
                      Nositelj = "Antoaneta Klobučar",
                      StudijskaGod = 1,
                  },
                  new Kolegij
                  {
                      Id = 7,
                      Naziv = "Makroekonomija",
                      Nositelj = "Đula Borozan",
                      StudijskaGod = 2,
                  },
                  new Kolegij
                  {
                      Id = 8,
                      Naziv = "Mikroekonomika",
                      Nositelj = "Ivan Kristek",
                      StudijskaGod = 1,
                  },
                  new Kolegij
                  {
                      Id = 9,
                      Naziv = "Međunarodna ekonomija",
                      Nositelj = "Dražen Koški",
                      StudijskaGod = 2,
                  },
                  new Kolegij
                  {
                      Id = 10,
                      Naziv = "Informatika",
                      Nositelj = "Marijana Zekić-Sušac, Branimir Dukić, Josip Mesarić",
                      StudijskaGod = 1,
                  },
                  new Kolegij
                  {
                      Id = 11,
                      Naziv = "Sociologija",
                      Nositelj = "Antun Šundalić",
                      StudijskaGod = 1,
                  }
              );

            context.Predavac.AddOrUpdate(i => i.Prezime,
                  new Predavac
                  {
                      Ime = "Ivan",
                      Prezime = "Ivić",
                      Tema = "Visual Studio",
                      Datum = DateTime.Parse("2017-1-11"),
                      BrStudent = 23,
                      KolegijId = 1
                  },
                  new Predavac
                  {
                      Ime = "Ana",
                      Prezime = "Matić",
                      Tema = "Razvoj m-banking aplikacija",
                      Datum = DateTime.Parse("2017-2-23"),
                      BrStudent = 32,
                      KolegijId = 2
                  },
                   new Predavac
                   {
                       Ime = "Ante",
                       Prezime = "Tomić",
                       Tema = "UML dijagrami",
                       Datum = DateTime.Parse("2017-3-06"),
                       BrStudent = 15,
                       KolegijId = 3
                   },
                    new Predavac
                    {
                        Ime = "Maja",
                        Prezime = "Galović",
                        Tema = "Oblikovanje SQL baze podataka",
                        Datum = DateTime.Parse("2017-4-04"),
                        BrStudent = 44,
                        KolegijId = 4
                    },
                    new Predavac
                    {
                        Ime = "Marin",
                        Prezime = "Kvesić",
                        Tema = "Razvoj m-banking aplikacija",
                        Datum = DateTime.Parse("2016-10-03"),
                        BrStudent = 57,
                        KolegijId = 5
                    },
                    new Predavac
                    {
                        Ime = "Jelena",
                        Prezime = "Bilić",
                        Tema = "Matrice",
                        Datum = DateTime.Parse("2016-9-12"),
                        BrStudent = 68,
                        KolegijId = 6
                    },
                    new Predavac
                    {
                        Ime = "Vedrana",
                        Prezime = "Kladić",
                        Tema = "Naftni šokovi-utjecaj na makro okolinu",
                        Datum = DateTime.Parse("2016-4-27"),
                        BrStudent = 80,
                        KolegijId = 7
                    },
                    new Predavac
                    {
                        Ime = "Nikola",
                        Prezime = "Lučić",
                        Tema = "Krivulja indiferencije",
                        Datum = DateTime.Parse("2015-5-18"),
                        BrStudent = 47,
                        KolegijId = 8
                    },
                    new Predavac
                    {
                        Ime = "Tena",
                        Prezime = "Magdić",
                        Tema = "Međunarodna razmjena SAD i Hrvatska",
                        Datum = DateTime.Parse("2014-12-11"),
                        BrStudent = 74,
                        KolegijId = 9
                    },
                    new Predavac
                    {
                        Ime = "Dalibor",
                        Prezime = "Uzelac",
                        Tema = "Kako izraditi web stranicu u Wordpress-u",
                        Datum = DateTime.Parse("2016-11-11"),
                        BrStudent = 95,
                        KolegijId = 10
                    },
                    new Predavac
                    {
                        Ime = "Valentin",
                        Prezime = "Čavar",
                        Tema = "Objektno orjentirano programiranje",
                        Datum = DateTime.Parse("2016-10-05"),
                        BrStudent = 50,
                        KolegijId = 1
                    },
                    new Predavac
                    {
                        Ime = "Patricija",
                        Prezime = "Šimić",
                        Tema = "Izrada dijagrama u alatu Astah",
                        Datum = DateTime.Parse("2015-06-10"),
                        BrStudent = 70,
                        KolegijId = 3
                    }
             );

        }
    }
}
