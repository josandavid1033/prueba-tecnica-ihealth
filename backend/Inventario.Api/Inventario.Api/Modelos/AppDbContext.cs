using Inventario.Api.Modelos;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
	public DbSet<Producto> Productos => Set<Producto>();
	public DbSet<Categoria> Categorias => Set<Categoria>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Producto>(prod =>
		{
			prod.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
			prod.Property(P => P.Precio).IsRequired().HasPrecision(18, 2);
			prod.HasIndex(p => p.Nombre);
		});
	}
}