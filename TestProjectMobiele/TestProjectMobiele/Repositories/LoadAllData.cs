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

        public async Task<int> SaveFotoAsync(Foto item)
        {
            await dbContext.tblfoto.AddAsync(item);

            return await dbContext.SaveChangesAsync();
        }

        public async void DeleteAllData()
        {
            int i = await DeleteAllKleutersAsync();
            i = await DeleteAllGezinnenAsync();
            i = await DeleteAllHoekenAsync();
        }

        public async Task<int> DeleteAllKleutersAsync()
        {
            foreach(Kleuter k in await LoadKleuters())
            {
                dbContext.tblkleuter.Remove(k);
            }
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAllGezinnenAsync()
        {
            foreach (Gezin g in await LoadGezinnen())
            {
                dbContext.tblgezin.Remove(g);
            }
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAllHoekenAsync()
        {
            foreach (Hoek h in await LoadHoeken())
            {
                dbContext.tblhoek.Remove(h);
            }
            return await dbContext.SaveChangesAsync();
        }
    }
}
