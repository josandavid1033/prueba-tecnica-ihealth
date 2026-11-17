using Inventario.Api.Modelos.DTOs;
using Inventario.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController(IProductoService productService) : ControllerBase
	{

		[Route("GetListbyName")]
		[HttpGet]
		public async Task<ActionResult<List<ProductoDTO>>> GetListbyName([FromQuery] string buscar)
		{
			return await productService.ListarbyNameAsync(buscar);
		}

		// GET: api/<ProductosController>
		[HttpGet]
		public async Task<ActionResult<List<ProductoDTO>>> Get()
		{
			return await productService.ListarAsync();
		}

		// GET api/<ProductosController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductoDTO?>> Get(int id)
		{
			return await productService.ObtenerAsync(id);
		}

		// POST api/<ProductosController>
		[HttpPost]
		public async Task<ActionResult<ProductoDTO>> Post([FromBody] CrearProductoDto product)
		{
			var created = await productService.CrearAsync(product);

			return CreatedAtAction(nameof(Get), new { Id = created.Id});

		}

		// PUT api/<ProductosController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] CrearProductoDto product)
		{
			var updated = await productService.ActualizarAsync(id, product);

			return updated ? NoContent() : NotFound();

		}

		// DELETE api/<ProductosController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var deleted = await productService.EliminarAsync(id);
			return deleted ? NoContent() : NotFound();
		}
	}
}
