using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using tp5.Repositorios;
using tp5.Models;

namespace tp5.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class PresupuestoController
    {
        private readonly IPresupuestoRepository _presupuestosRepository;

        public PresupuestoController(IPresupuestoRepository presupuestosRepository)
        {
            _presupuestosRepository = presupuestosRepository;
        }

        [HttpPost]
        public ActionResult CreatePresupuesto(Presupuestos presupuesto)
        {
            _presupuestosRepository.CreatePresupuesto(presupuesto);
            return Created();
        }

        private ActionResult Created()
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id}/ProductoDetalle")]
        public ActionResult AgregarProductoCantidad(int id, PresupuestoDetalle detalle)
        {
            _presupuestosRepository.AgregarProductoCantidad(id, detalle);
            return Ok();
        }

        private ActionResult Ok()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Presupuestos>> GetAllPresupuestos()
        {
            var presupuestos = _presupuestosRepository.GetAllPresupuestos();
            return Ok(presupuestos);
        }

        private ActionResult<IEnumerable<Presupuestos>> Ok(List<Presupuestos> presupuestos)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<Presupuestos> GetPresupuestoById(int id)
        {
            var presupuesto = _presupuestosRepository.GetPresupuestosById(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePresupuesto(int id)
        {
            _presupuestosRepository.DeletePresupuesto(id);
            return NoContent();
        }

        private ActionResult NoContent()
        {
            throw new NotImplementedException();
        }
    }
}
