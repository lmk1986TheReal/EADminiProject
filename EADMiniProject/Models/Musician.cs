using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EADMiniProject.Models
{
   

    public class Musician
    {

        // MusicianID Field
        
        public int ID { get; set; }

        // Musician First Name Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("First Name")]
        public String MusicianFirstName { get; set; }

        // Musician last Name Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Last Name")]
        public String MusicianLastName { get; set; }

        // Musician Nationality Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Nationality/s")]
        public String Nationality { get; set; }

        // Years Active Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Years Active")]
        public String YearsActive { get; set; }

        // Primary Instrument Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Musician's Primary Instrument")]
        public String PrimaryInstrument { get; set; }

        // Drop down to select the genres of the Musician
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Musican's Associated Genres")]
        public String Genre { get; set; }
    }
}