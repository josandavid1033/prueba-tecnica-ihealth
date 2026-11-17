using System.ComponentModel.DataAnnotations;

namespace Inventario.Api.Modelos.DTOs
{
	public record ProductoDTO(int Id, string Nombre, decimal Precio, int Stock, string Categoria);

	public class CrearProductoDto
	{
		[Required, StringLength(100)]
		public string Nombre { get; set; } = string.Empty;

		[Range(0.01, 100_000_000)]
		public decimal Precio { get; set; }

		[Range(0, int.MaxValue)]
		public int Stock { get; set; }

		[Required]
		public int CategoriaId { get; set; }
	}
	
}
