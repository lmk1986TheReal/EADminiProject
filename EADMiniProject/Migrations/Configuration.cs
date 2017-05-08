namespace EADMiniProject.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EADMiniProject.DAL.ArtistContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EADMiniProject.DAL.ArtistContext context)
        {
            {
                var Bands = new List<Band>
            {
            new Band{BandName = "UNRoyal Blood", NumberofBandMembers = "2", Nationality = "English", YearsActive = "2013 - Present", Genre = "Rock"},


            };

                Bands.ForEach(s => context.Bands.Add(s));
                context.SaveChanges();

                var Musicians = new List<Musician>
            {
            new Musician {MusicianFirstName = "NOT Mike", MusicianLastName = "Kerr", Nationality = "English", YearsActive ="2006 - Present", PrimaryInstrument = "Bass", Genre = "Rock"},
            };
                Musicians.ForEach(s => context.Musicians.Add(s));
                context.SaveChanges();

            }
        }
    }
}
