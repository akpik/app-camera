﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectMobiele
{
    public class Leerkracht
    {
        //Gemaakt door Daan Vandebosch
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LeerkrachtCode { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        //Relations
        public int SchoolID { get; set; }
        public int KlasID { get; set; }
    }
}
