using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectMobiele
{
    public class Hoek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HoekID { get; set; }
        public string Naam { get; set; }
        public string FotoPad { get; set; }

        //Relations
        public int SchoolID { get; set; }
        public int KlasID { get; set; }
    }
}
