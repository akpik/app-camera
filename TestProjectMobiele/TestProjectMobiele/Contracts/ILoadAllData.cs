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
        Task<int> SaveItemAsync(Kleuter item);
    }
}
