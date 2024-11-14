using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using tp5.Repositorios;
using tp5.Models;

namespace tp5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Productos>> GetProductos()
        {
            var productos = _productoRepository.ListProductos();
            return Ok(productos);
        }

        [HttpPost]
        public ActionResult CreateProducto(Productos producto)
        {
            _productoRepository.CreateProducto(producto);
            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult CambiarNombre(int id, string nuevoNombre)
        {
            var producto = _productoRepository.DetallesPorID(id);
            producto.Descripcion = nuevoNombre;
            _productoRepository.UpdateProducto(producto, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProducto(int id)
        {
            _productoRepository.DeletePorId(id);
            return NoContent();
        }
    }
}
