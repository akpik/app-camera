using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectMobiele
{
    public class School
    {
        //Gemaakt door Daan Vandebosch
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolID { get; set; }
        public string SchoolNaam { get; set; }
    }
}
