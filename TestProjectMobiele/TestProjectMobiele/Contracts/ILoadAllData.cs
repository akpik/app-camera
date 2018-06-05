using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMobiele.Contracts
{
    public interface ILoadAllData
    {
        Task<List<Foto>> LoadFotos();
        Task<List<Gezin>> LoadGezinnen();
        Task<List<Hoek>> LoadHoeken();
        Task<List<Klas>> LoadKlassen();
        Task<List<Kleuter>> LoadKleuters();
        Task<List<Leerkracht>> LoadLeerkrachten();
        Task<List<School>> LoadScholen();

        Task<int> SaveKleuterAsync(Kleuter item);
        Task<int> SaveGezinAsync(Gezin item);
        Task<int> SaveHoekAsync(Hoek item);
        Task<int> SaveFotoAsync(Foto item);

        void DeleteAllData();

        Task<int> DeleteAllKleutersAsync();
        Task<int> DeleteAllGezinnenAsync();
        Task<int> DeleteAllHoekenAsync();
    }
}
