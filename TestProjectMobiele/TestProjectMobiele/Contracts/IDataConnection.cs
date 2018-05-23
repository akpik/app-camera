using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjectMobiele
{
    public interface IDataConnection
    {
        DbSet<Foto> tblfoto { get; set; }
        DbSet<Gezin> tblgezin { get; set; }
        DbSet<Hoek> tblhoek { get; set; }
        DbSet<Klas> tblklas { get; set; }
        DbSet<Kleuter> tblkleuter { get; set; }
        DbSet<Leerkracht> tblleerkracht { get; set; }
        DbSet<School> tblschool { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
