using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ActividadesDeportivas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActividadesDeportivas.Infrastructure.Context
{
    public class ActividadesDbContext : DbContext
    {
        public ActividadesDbContext(DbContextOptions<ActividadesDbContext> options) : base(options) { }

        public DbSet<UsuarioDeportivo> UsuariosDeportivos { get; set; }
        public DbSet<ActividadFisica> ActividadesFisicas { get; set; }
        public DbSet<EstadisticaProgreso> EstadisticasProgreso { get; set; }
        public DbSet<ResumenDiarioFitbit> ResumenesDiariosFitbit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioDeportivo>()
                .HasMany(u => u.Actividades)
                .WithOne(a => a.UsuarioDeportivo)
                .HasForeignKey(a => a.UsuarioDeportivoId);

            modelBuilder.Entity<UsuarioDeportivo>()
                .HasMany(u => u.EstadisticasProgreso)
                .WithOne(e => e.UsuarioDeportivo)
                .HasForeignKey(e => e.UsuarioDeportivoId);

            modelBuilder.Entity<UsuarioDeportivo>()
                .HasMany(u => u.ResumenesDiarios)
                .WithOne(r => r.UsuarioDeportivo)
                .HasForeignKey(r => r.UsuarioDeportivoId);
        }
    }
}
