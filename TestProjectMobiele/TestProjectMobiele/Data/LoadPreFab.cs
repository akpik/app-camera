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
            GetKleuters();
        }

        public async void SaveKleuters()
        {
            Kleuter k = new Kleuter
            {
                KleuterID = 4432,
                VoorNaam = "Naam1",
                Naam = "Vandebosch",
                SchoolID = 0,
                FotoPad = "FotoString",
                GezinsID = 0,
                KlasID = 0
            };
            await dataConnection.SaveItemAsync(k);
            Kleuter k2 = new Kleuter
            {
                KleuterID = 59,
                VoorNaam = "Naam3",
                Naam = "Nlsdg",
                SchoolID = 2,
                FotoPad = "FotoString",
                GezinsID = 2,
                KlasID = 0
            };
            await dataConnection.SaveItemAsync(k2);
            Kleuter k3 = new Kleuter
            {
                KleuterID = 37,
                VoorNaam = "Naam2",
                Naam = "Akpinar",
                SchoolID = 1,
                FotoPad = "FotoString",
                GezinsID = 1,
                KlasID = 0
            };
            await dataConnection.SaveItemAsync(k3);
        }

        private void GetKleuters()
        {
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
            kleuters.Add(k);
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
            kleuters.Add(k);
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
            kleuters.Add(k);
        }
    }
}
