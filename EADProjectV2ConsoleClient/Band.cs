using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;


namespace EADMiniProject.Models
{


    public class Band
    {


        //begin properties

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get;
            set;
        }

        public String BandName
        {
            get; set;
        }

        public String Nationality
        {
            get; set;
        }

   
         
    }//end class
    //public class BandyContext : DbContext
    //{
    //    public BandyContext() : base("DefaultConnection")
    //    {

    //    }
    //    public DbSet<Band> Band { get; set; }
    //}
}//end namespace