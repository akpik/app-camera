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
                KleuterID = 50,
                VoorNaam = "Naam1",
                Naam = "Vandebosch",
                SchoolID = 0,
                FotoPad = "FotoString",
                GezinsID = 50,
                KlasID = 50
            };
            await dataConnection.SaveKleuterAsync(k);

            Kleuter k2 = new Kleuter
            {
                KleuterID = 51,
                VoorNaam = "Naam3",
                Naam = "Nlsdg",
                SchoolID = 2,
                FotoPad = "FotoString",
                GezinsID = 51,
                KlasID = 50
            };
            await dataConnection.SaveKleuterAsync(k2);

            Kleuter k3 = new Kleuter
            {
                KleuterID = 52,
                VoorNaam = "Naam2",
                Naam = "Akpinar",
                SchoolID = 1,
                FotoPad = "FotoString",
                GezinsID = 52,
                KlasID = 50
            };
            await dataConnection.SaveKleuterAsync(k3);

            //Gezinnen
            Gezin g1 = new Gezin
            {
                GezinsID = 50,
                GezinsCode = "DAAN",
            };
            await dataConnection.SaveGezinAsync(g1);

            Gezin g2 = new Gezin
            {
                GezinsID = 51,
                GezinsCode = "KAAN",
            };
            await dataConnection.SaveGezinAsync(g2);

            Gezin g3 = new Gezin
            {
                GezinsID = 52,
                GezinsCode = "OUDER",
            };
            await dataConnection.SaveGezinAsync(g3);

            //Hoeken
            Hoek h1 = new Hoek
            {
                HoekID = 50,
                Naam = "Kaan kelder",
                FotoPad = "KaanKelder",
                SchoolID = 0,
                KlasID = 50,
            };
            await dataConnection.SaveHoekAsync(h1);

            Hoek h2 = new Hoek
            {
                HoekID = 51,
                Naam = "Kaan zolder",
                FotoPad = "KaanZolder",
                SchoolID = 0,
                KlasID = 50,
            };
            await dataConnection.SaveHoekAsync(h2);
        }
    }
}
