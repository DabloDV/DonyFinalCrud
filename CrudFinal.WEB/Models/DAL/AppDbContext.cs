using Microsoft.EntityFrameworkCore;
using CrudFinal.WEB.Models.Entities;

namespace CrudFinal.WEB.Models.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }

    }
}

