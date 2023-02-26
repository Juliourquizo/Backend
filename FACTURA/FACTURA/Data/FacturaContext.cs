namespace FACTURA.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection.Emit;
	using System.Reflection.Metadata;
	using System.Text;
	using System.Threading.Tasks;
	using FACTURA.Models;
	using Microsoft.EntityFrameworkCore;
	using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

	public class FacturaContext : DbContext
	{

		public DbSet<Cliente> Cliente { get; set; } = null!;

		public DbSet<HojaFactura> HojaFactura { get; set; } = null!;

		public DbSet<Linea> Linea { get; set; } = null!;

		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EjercicioFactura;Integrated Security=True;");
		}
		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Cliente>()
			.HasMany(a => a.HojaFacturas)
			.WithOne(b => b.Cliente);

			modelBuilder.Entity<HojaFactura>()
			.HasMany(c => c.Lineas)
			.WithOne(d => d.HojaFactura);
		}
	}
}
