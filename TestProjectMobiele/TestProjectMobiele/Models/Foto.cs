
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestProjectMobiele
{
    //Gemaakt door Daan Vandebosch
    public class Foto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FotoID { get; set; }
        public string FotoPad { get; set; }
        public string Datum { get; set; }

        //Relations
        public int KleuterID { get; set; }
        public int HoekID { get; set; }
        
    }
}
