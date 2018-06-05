using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectMobiele
{
    public class Klas
    {
        //Gemaakt door Daan Vandebosch
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlasID { get; set; }
        public string KlasCode { get; set; }
        public string KlasNaam { get; set; }
    }
}
