using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProjectMobiele.Contracts;

namespace TestProjectMobiele.Data
{
    class LoadPreFab
    {
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
                KleuterID = 0,
                VoorNaam = "Naam1",
                Naam = "Vandebosch",
                SchoolID = 0,
                FotoPad = "FotoString",
                GezinsID = 0,
                KlasID = 0
            };
            await dataConnection.SaveKleuterAsync(k);

            Kleuter k2 = new Kleuter
            {
                KleuterID = 1,
                VoorNaam = "Naam3",
                Naam = "Nlsdg",
                SchoolID = 2,
                FotoPad = "FotoString",
                GezinsID = 2,
                KlasID = 0
            };
            await dataConnection.SaveKleuterAsync(k2);

            Kleuter k3 = new Kleuter
            {
                KleuterID = 2,
                VoorNaam = "Naam2",
                Naam = "Akpinar",
                SchoolID = 1,
                FotoPad = "FotoString",
                GezinsID = 1,
                KlasID = 0
            };
            await dataConnection.SaveKleuterAsync(k3);

            //Gezinnen
            Gezin g1 = new Gezin
            {
                GezinsID = 0,
                GezinsCode = "DAAN",
            };
            await dataConnection.SaveGezinAsync(g1);

            Gezin g2 = new Gezin
            {
                GezinsID = 1,
                GezinsCode = "KAAN",
            };
            await dataConnection.SaveGezinAsync(g2);

            Gezin g3 = new Gezin
            {
                GezinsID = 2,
                GezinsCode = "OUDER",
            };
            await dataConnection.SaveGezinAsync(g3);

            //Hoeken
            Hoek h1 = new Hoek
            {
                HoekID = 0,
                Naam = "Kaan kelder",
                FotoPad = "KaanKelder",
                SchoolID = 0,
                KlasID = 0,
            };
            await dataConnection.SaveHoekAsync(h1);

            Hoek h2 = new Hoek
            {
                HoekID = 1,
                Naam = "Kaan zolder",
                FotoPad = "KaanZolder",
                SchoolID = 0,
                KlasID = 0,
            };
            await dataConnection.SaveHoekAsync(h2);
        }
    }
}
