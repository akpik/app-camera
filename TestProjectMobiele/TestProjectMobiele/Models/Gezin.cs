using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectMobiele
{
    public class Gezin
    {
        //Gemaakt door Daan Vandebosch
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GezinsID { get; set; }
        public string GezinsCode { get; set; }
    }
}
