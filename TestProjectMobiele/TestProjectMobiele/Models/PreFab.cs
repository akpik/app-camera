using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectMobiele
{
    class PreFab
    {
        public List<Kleuter> ReturnKleuters()
        {
            List<Kleuter> KleuterList = new List<Kleuter>();
            Kleuter k = new Kleuter
            {
                KleuterID = 0,
                VoorNaam = "Naam1",
                Naam = "Vandebosch",
                SchoolID = 0,
                FotoPad = "FotoString",
                GezinsID = 0,
                KlasID = 0
            };
            KleuterList.Add(k);
            k = new Kleuter
            {
                KleuterID = 1,
                VoorNaam = "Naam2",
                Naam = "Akpinar",
                SchoolID = 1,
                FotoPad = "FotoString",
                GezinsID = 1,
                KlasID = 0
            };
            KleuterList.Add(k);
            k = new Kleuter
            {
                KleuterID = 2,
                VoorNaam = "Naam3",
                Naam = "Nlsdg",
                SchoolID = 2,
                FotoPad = "FotoString",
                GezinsID = 2,
                KlasID = 0
            };
            KleuterList.Add(k);
            return KleuterList;
        }
        //public List<Kleuter> ReturnGezin()
        //{
            
        //}
    }
}
