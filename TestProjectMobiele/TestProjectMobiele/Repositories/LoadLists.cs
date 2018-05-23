using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectMobiele
{
    class LoadLists
    {
        public async List<Kleuter> LoadAllKleuters(LoadAllData dataConnection)
        {
            List<Kleuter> ListKleuter = new List<Kleuter>();
            ListKleuter = await dataConnection.LoadKleuters();
            return ListKleuter;
        }
    }
}
