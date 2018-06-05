using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProjectMobiele.Contracts;

namespace TestProjectMobiele.Data
{
    class LoadPreFab
    {
        //Gemaakt door Daan Vandebosch
        private List<Kleuter> kleuters = new List<Kleuter>();
        private ILoadAllData dataConnection;

        public LoadPreFab(ILoadAllData dataConnection)
        {
            this.dataConnection = dataConnection;
            dataConnection.DeleteAllData();
        }

        public async void SaveKleuters()
        {
            //Kleuters
            Kleuter k = new Kleuter
            {
                KleuterID = 5000,
                VoorNaam = "Naam1",
                Naam = "Vandebosch",
                SchoolID = 0,
                FotoPad = "FotoString",
                GezinsID = 5000,
                KlasID = 5000
            };
            await dataConnection.SaveKleuterAsync(k);

            Kleuter k2 = new Kleuter
            {
                KleuterID = 5001,
                VoorNaam = "Naam3",
                Naam = "Nlsdg",
                SchoolID = 2,
                FotoPad = "FotoString",
                GezinsID = 5001,
                KlasID = 5000
            };
            await dataConnection.SaveKleuterAsync(k2);

            Kleuter k3 = new Kleuter
            {
                KleuterID = 5002,
                VoorNaam = "Naam2",
                Naam = "Akpinar",
                SchoolID = 1,
                FotoPad = "FotoString",
                GezinsID = 5002,
                KlasID = 5000
            };
            await dataConnection.SaveKleuterAsync(k3);

            //Gezinnen
            Gezin g1 = new Gezin
            {
                GezinsID = 5000,
                GezinsCode = "DAAN",
            };
            await dataConnection.SaveGezinAsync(g1);

            Gezin g2 = new Gezin
            {
                GezinsID = 5001,
                GezinsCode = "KAAN",
            };
            await dataConnection.SaveGezinAsync(g2);

            Gezin g3 = new Gezin
            {
                GezinsID = 5002,
                GezinsCode = "OUDER",
            };
            await dataConnection.SaveGezinAsync(g3);

            //Hoeken
            Hoek h1 = new Hoek
            {
                HoekID = 5000,
                Naam = "Kaan kelder",
                FotoPad = "KaanKelder",
                SchoolID = 0,
                KlasID = 5000,
            };
            await dataConnection.SaveHoekAsync(h1);

            Hoek h2 = new Hoek
            {
                HoekID = 5001,
                Naam = "Kaan zolder",
                FotoPad = "KaanZolder",
                SchoolID = 0,
                KlasID = 5000,
            };
            await dataConnection.SaveHoekAsync(h2);
        }
    }
}
