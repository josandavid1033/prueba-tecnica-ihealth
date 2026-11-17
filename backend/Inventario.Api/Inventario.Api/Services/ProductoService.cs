using Azure;
using Inventario.Api.Modelos;
using Inventario.Api.Modelos.DTOs;
using Microsoft.EntityFrameworkCore;
using static Inventario.Api.Modelos.DTOs.ProductoDTO;

namespace Inventario.Api.Services
{
	public class ProductoService(AppDbContext db) : IProductoService
	{
		public async Task<bool> ActualizarAsync(int id, CrearProductoDto dto)
		{
			var producto = await db.Productos.FindAsync(id);

			if (producto == null) return false;	

			producto.Nombre = dto.Nombre;
			producto.Precio = dto.Precio;
			producto.Stock = dto.Stock;

			await db.SaveChangesAsync();

			return true;
		}

		public async Task<ProductoDTO> CrearAsync(CrearProductoDto dto)
		{
			Producto result = new Producto()
			{
				Nombre = dto.Nombre,
				Precio = dto.Precio,
				Stock = dto.Stock,
				CategoriaId = dto.CategoriaId
			};

			await db.Productos.AddAsync(result);

			await db.SaveChangesAsync();

			var resultDTO = await ObtenerAsync(result.Id);

			return resultDTO;


		}

		public async Task<bool> EliminarAsync(int id)
		{
			var result = await db.Productos.FindAsync(id);
			if (result == null)
				return false;
			db.Productos.Remove(result);

			await db.SaveChangesAsync();

			return true;
		}

		public async Task<List<ProductoDTO>> ListarAsync()
		{
			return await db.Productos.AsNoTracking().Select(s => new ProductoDTO(s.Id, s.Nombre, s.Precio, s.Stock, s.Categoria!.Nombre))
										.ToListAsync();
		}

		public async Task<List<ProductoDTO>> ListarbyNameAsync(string buscar)
		{
			return await db.Productos.AsNoTracking().Where(p => buscar != null && p.Nombre.Contains(buscar))
										.Select(s => new ProductoDTO(s.Id, s.Nombre, s.Precio, s.Stock, s.Categoria!.Nombre))
										.ToListAsync();
		}

		public async Task<ProductoDTO?> ObtenerAsync(int id)
		{
			var result = db.Productos.AsNoTracking().Where(w => w.Id == id)
													.Select(s => new ProductoDTO(s.Id, s.Nombre, s.Precio, s.Stock, s.Categoria!.Nombre))
													.FirstOrDefaultAsync();
			return await result;
		}
	}
}
