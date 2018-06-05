using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProjectMobiele.Contracts;

namespace TestProjectMobiele
{
    public class LoadAllData : ILoadAllData
    {
        private IDataConnection dbContext;

        public LoadAllData(IDataConnection dbContext)
        {
            this.dbContext = dbContext; 
        }

        public async Task<List<Foto>> LoadFotos()
        {
            return await dbContext.tblfoto.ToListAsync();
        }

        public async Task<List<Gezin>> LoadGezinnen()
        {
            return await dbContext.tblgezin.ToListAsync();
        }

        public async Task<List<Hoek>> LoadHoeken()
        {
            return await dbContext.tblhoek.ToListAsync();
        }

        public async Task<List<Klas>> LoadKlassen()
        {
            return await dbContext.tblklas.ToListAsync();
        }

        public async Task<List<Kleuter>> LoadKleuters()
        {
            return await dbContext.tblkleuter.ToListAsync();
        }

        public async Task<List<Leerkracht>> LoadLeerkrachten()
        {
            return await dbContext.tblleerkracht.ToListAsync();
        }

        public async Task<List<School>> LoadScholen()
        {
            return await dbContext.tblschool.ToListAsync();
        }

        public async Task<int> SaveKleuterAsync(Kleuter item)
        {
            await dbContext.tblkleuter.AddAsync(item);

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveGezinAsync(Gezin item)
        {
            await dbContext.tblgezin.AddAsync(item);

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveHoekAsync(Hoek item)
        {
            await dbContext.tblhoek.AddAsync(item);

            return await dbContext.SaveChangesAsync();
        }
    }
}
