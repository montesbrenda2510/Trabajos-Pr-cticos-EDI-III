using MasterStock.Aplication;
using MasterStock.Entitis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterStock.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class TiposdeMovimientoController:ControllerBase
    {

            private readonly ILogger<TiposdeMovimientoController> _logger;
            private readonly IApplication<TipodeMovimiento> _tipoMovimiento;
            public TiposdeMovimientoController(ILogger<TiposdeMovimientoController> logger, IApplication<TipodeMovimiento> tipodeMovimiento)
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
                TipodeMovimiento tipodeMovimiento = _tipoMovimiento.GetById(Id.Value);
                if (tipodeMovimiento is null)
                {
                    return NotFound();
                }
                return Ok(tipodeMovimiento);
            }

            [HttpPost]
            public async Task<IActionResult> Crear(TipodeMovimiento tipodeMovimientos)
            {
                if (!ModelState.IsValid)
                { return BadRequest(); }
                _tipoMovimiento.Save(tipodeMovimientos);
                return Ok(tipodeMovimientos.Id);
            }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, TipodeMovimiento tipodeMovimientos)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            TipodeMovimiento tipodeMovimientoBack = _tipoMovimiento.GetById(Id.Value);
            if (tipodeMovimientoBack is null)
            { return NotFound(); }
            tipodeMovimientoBack.TipoMovimiento =tipodeMovimientos.TipoMovimiento;

                return Ok(tipodeMovimientoBack);
            }

            [HttpDelete]
            public async Task<IActionResult> Borrar(int? Id)
            {
                if (!Id.HasValue)
                { return BadRequest(); }
                if (!ModelState.IsValid)
                { return BadRequest(); }
                TipodeMovimiento tipodeMovimientoBack = _tipoMovimiento.GetById(Id.Value);
                if (tipodeMovimientoBack is null)
                { return NotFound(); }

                _tipoMovimiento.Delete(tipodeMovimientoBack.Id);
                return Ok();
            }
        
    }
}
