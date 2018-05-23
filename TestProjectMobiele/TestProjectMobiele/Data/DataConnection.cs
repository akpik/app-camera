using Microsoft.EntityFrameworkCore;
using System;
using TestProjectMobiele;

namespace TestProjectMobieles.Data
{
    public class DataConnection : DbContext, IDataConnection
    {
        public DbSet<Foto> tblfoto { get; set; }
        public DbSet<Gezin> tblgezin { get; set; }
        public DbSet<Hoek> tblhoek { get; set; }
        public DbSet<Klas> tblklas { get; set; }
        public DbSet<Kleuter> tblkleuter { get; set; }
        public DbSet<Leerkracht> tblleerkracht { get; set; }
        public DbSet<School> tblschool { get; set; }

        private string connectionString;

        public DataConnection(IFileHelper fileHelper)
        {
            string databasePath = fileHelper.GetLocalFilePath("TodoSQLite.db3");
            connectionString = string.Format("Filename={0}", databasePath);

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlite(connectionString);
                }
            }
            catch(Exception ex)
            {
                string x = ex.Message;
            }
            
        }
    }
}
