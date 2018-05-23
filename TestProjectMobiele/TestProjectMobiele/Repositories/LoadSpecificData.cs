using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMobiele.Repositories
{
    class LoadSpecificData
    {
        private IDataConnection dbContext;
        public LoadSpecificData(IDataConnection dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Foto> LoadFotos(int FotoID)
        {
            return await dbContext.tblfoto.SingleAsync(item => item.FotoID == FotoID);
        }

        public async Task<Gezin> LoadGezinnen(int GezinsID)
        {
            return await dbContext.tblgezin.SingleAsync(item => item.GezinsID == GezinsID);
        }

        public async Task<Hoek> LoadHoeken(int HoekID)
        {
            return await dbContext.tblhoek.SingleAsync(item => item.HoekID == HoekID);
        }

        public async Task<Klas> LoadKlassen(int KlasID)
        {
            return await dbContext.tblklas.SingleAsync(item => item.KlasID == KlasID);
        }

        public async Task<Kleuter> LoadKleuters(int KleuterID)
        {
            return await dbContext.tblkleuter.SingleAsync(item => item.KleuterID == KleuterID);
        }

        public async Task<Leerkracht> LoadLeerkrachten(string LeerkrachtCode)
        {
            return await dbContext.tblleerkracht.SingleAsync(item => item.LeerkrachtCode == LeerkrachtCode);
        }

        public async Task<School> LoadScholen(int SchoolID)
        {
            return await dbContext.tblschool.SingleAsync(item => item.SchoolID == SchoolID);
        }
    }
}
