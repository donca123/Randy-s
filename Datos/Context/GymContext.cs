using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DominioGym;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Datos
{
    public class GymContext:DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options) { }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<DetalleComprobante> DetalleComprobante { get; set; }

    }
    public class XXXXDbContextFactory : IDesignTimeDbContextFactory<GymContext>
    {

        GymContext IDesignTimeDbContextFactory<GymContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../Api_Web/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<GymContext>();
            var connectionString = configuration.GetConnectionString("Conexion");
            builder.UseSqlServer(connectionString);
            return new GymContext(builder.Options);
        }
    }
}
