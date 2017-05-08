using System.Collections.Generic;
using EADMiniProject.Models;

namespace EADMiniProject.DAL
{
    public class ArtistInitializer : System.Data.Entity.DropCreateDatabaseAlways<ArtistContext>
    {
        protected override void Seed(ArtistContext context)
        {
            var Bands = new List<Band>
            {
            new Band{BandName = "Royal Blood", NumberofBandMembers = "2", Nationality = "English", YearsActive = "2013 - Present", Genre = "Rock, Metal, Indie"},
            new Band{BandName = "The Committments", NumberofBandMembers = "9", Nationality = "Irish", YearsActive = "1990 - Present", Genre = "Rock, Soul, Funk"},
            new Band{BandName = "Led Zeppelin", NumberofBandMembers = "4", Nationality = "English", YearsActive = "1962 - Present", Genre = "Rock, Blues, Heavy Metal, Skiffle"},
            new Band{BandName = "The Beatles", NumberofBandMembers = "4", Nationality = "English", YearsActive = "1960 - 1970", Genre = "Rock, Pop"},
            new Band{BandName = "The Last Shadow Puppets", NumberofBandMembers = "10", Nationality = "English / American", YearsActive = "2008 - Present", Genre = "Rock, Baroque pop"},
            };

            Bands.ForEach(s => context.Bands.Add(s));
            context.SaveChanges();

            var Musicians = new List<Musician>
            {
            new Musician {MusicianFirstName = "Mike", MusicianLastName = "Kerr", Nationality = "English", YearsActive ="2013 - Present", PrimaryInstrument = "Bass", Genre = "Rock, Pop, Ska"},
            new Musician {MusicianFirstName = "Alan", MusicianLastName = "Davids", Nationality = "Greek", YearsActive ="2016 - 2016", PrimaryInstrument = "Guitar", Genre = "Rock, Funk, Heavy Metal"},
            new Musician {MusicianFirstName = "Fred", MusicianLastName = "Perry", Nationality = "Northern Irish", YearsActive ="2000 - Present", PrimaryInstrument = "Drums", Genre = "Rock, Blues, Latin"},
            new Musician {MusicianFirstName = "Martin", MusicianLastName = "Stephens", Nationality = "Irish", YearsActive ="1801 - 1802", PrimaryInstrument = "Vocals", Genre = "Trad, Pop, Jazz, Funk"},
            new Musician {MusicianFirstName = "Ricky", MusicianLastName = "Bobby", Nationality = "Isle of Man", YearsActive ="2006 - 2007", PrimaryInstrument = "Vocals", Genre = "Baroque Pop, Pop, Skiffle"},
            new Musician {MusicianFirstName = "Alex", MusicianLastName = "Turner", Nationality = "Scottish", YearsActive ="2002 - Present", PrimaryInstrument = "Guitar", Genre = "Brit-Pop, Metal, Skiffle"},
            new Musician {MusicianFirstName = "Nick", MusicianLastName = "O Malley", Nationality = "Welsh", YearsActive ="2002 - Present", PrimaryInstrument = "Piano", Genre = "Rock, Fusion, Jazz"},
            new Musician {MusicianFirstName = "Jamie", MusicianLastName = "Cook", Nationality = "Irish", YearsActive ="2002 - Present", PrimaryInstrument = "Guitar", Genre = "Rock, Pop, Ska"},
            new Musician {MusicianFirstName = "Ben", MusicianLastName = "Tatcher", Nationality = "English", YearsActive ="2001 - 2002", PrimaryInstrument = "Drums", Genre = "World, Africian, Latin Jazz"},
            new Musician {MusicianFirstName = "Ron", MusicianLastName = "Burgandy", Nationality = "Jamican", YearsActive ="1970 - 1980", PrimaryInstrument = "Vocals", Genre = "Jazz, Soul, Blues"},

            };
            Musicians.ForEach(s => context.Musicians.Add(s));
            context.SaveChanges();

        }
    }
}