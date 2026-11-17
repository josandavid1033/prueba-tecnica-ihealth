using Inventario.Api.Modelos.DTOs;
using static Inventario.Api.Modelos.DTOs.ProductoDTO;

namespace Inventario.Api.Services
{
	public interface IProductoService
	{
		Task<List<ProductoDTO>> ListarAsync ();
		Task<List<ProductoDTO>> ListarbyNameAsync(string buscar);
		Task<ProductoDTO?> ObtenerAsync(int id);
		Task<ProductoDTO> CrearAsync(CrearProductoDto dto);
		Task<bool> ActualizarAsync(int id, CrearProductoDto dto);
		Task<bool> EliminarAsync(int id);
	}
}
