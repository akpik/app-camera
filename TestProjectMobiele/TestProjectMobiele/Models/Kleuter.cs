using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectMobiele
{
    public class Kleuter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KleuterID { get; set; }
        public string VoorNaam { get; set; }
        public string Naam { get; set; }
        public int SchoolID { get; set; }
        public string FotoPad { get; set; }
        public int GezinsID { get; set; }
        public int KlasID { get; set; }
    }
}
