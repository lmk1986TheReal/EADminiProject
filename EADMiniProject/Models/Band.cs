using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace EADMiniProject.Models
{

   
    public class Band
    {

        
        public int ID { get; set; }

        // Band Name Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Band Name")]
        public String BandName { get; set; }

        // Number of band members Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Number of Band Members")]
        public String NumberofBandMembers { get; set; }

        // Band Nationality Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Nationality/s")]
        public String Nationality { get; set; }

        // Years Active Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Years Active")]
        public String YearsActive { get; set; }

        // Band Genres Field
        [Required(ErrorMessage = "Please do not leave blank")]
        [DisplayName("Band's Associated Genres")]
        public String Genre { get; set; }
    }
}