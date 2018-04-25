using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using DemoGAB2018Ecuador.Modelos;
using DemoGAB2018Ecuador.Servicios;

namespace DemoGAB2018Ecuador.Datos
{
    public class BaseDatos : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        private readonly string rutaBD;

        public BaseDatos(string rutaBD)
        {
            this.rutaBD = rutaBD;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IBaseDatos>().GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
