using Save_Our_Ocean.Models;
using Microsoft.EntityFrameworkCore;


namespace Save_Our_Ocean.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Voluntario> Voluntario { get; set; }

        public DbSet<Area> Area { get; set; }

        public DbSet<Administrador> Administrador { get; set; }

    }
}
