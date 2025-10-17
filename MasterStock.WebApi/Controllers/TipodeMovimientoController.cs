using MasterStock.Aplication;
using MasterStock.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace MasterStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipodeMovimientoController:ControllerBase
    {

            private readonly ILogger<TipodeMovimientoController> _logger;
            private readonly IApplication<TipodeMovimientos> _tipoMovimiento;
            public TipodeMovimientoController(ILogger<TipodeMovimientoController> logger, IApplication<TipodeMovimientos> tipodeMovimiento)
            {
                _logger = logger;
                _tipoMovimiento = tipodeMovimiento;
            }

            [HttpGet]
            [Route("All")]
            public async Task<IActionResult> All()
            {
                return Ok(_tipoMovimiento.GetAll());
            }

            [HttpGet]
            [Route("ById")]
            public async Task<IActionResult> ById(int? Id)
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }
                TipodeMovimientos tipodeMovimiento = _tipoMovimiento.GetById(Id.Value);
                if (tipodeMovimiento is null)
                {
                    return NotFound();
                }
                return Ok(tipodeMovimiento);
            }

            [HttpPost]
            public async Task<IActionResult> Crear(TipodeMovimientos tipodeMovimientos)
            {
                if (!ModelState.IsValid)
                { return BadRequest(); }
                _tipoMovimiento.Save(tipodeMovimientos);
                return Ok(tipodeMovimientos.Id);
            }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, TipodeMovimientos tipodeMovimientos)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            TipodeMovimientos tipodeMovimientoBack = _tipoMovimiento.GetById(Id.Value);
            if (tipodeMovimientoBack is null)
            { return NotFound(); }
            tipodeMovimientoBack.TipodeMovimiento =tipodeMovimientos.TipodeMovimiento;

                return Ok(tipodeMovimientoBack);
            }

            [HttpDelete]
            public async Task<IActionResult> Borrar(int? Id)
            {
                if (!Id.HasValue)
                { return BadRequest(); }
                if (!ModelState.IsValid)
                { return BadRequest(); }
                TipodeMovimientos tipodeMovimientoBack = _tipoMovimiento.GetById(Id.Value);
                if (tipodeMovimientoBack is null)
                { return NotFound(); }

                _tipoMovimiento.Delete(tipodeMovimientoBack.Id);
                return Ok();
            }
        
    }
}
