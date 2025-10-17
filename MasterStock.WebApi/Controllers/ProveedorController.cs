using MasterStock.Aplication;
using MasterStock.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace MasterStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ILogger<ProveedorController> _logger;
        private readonly IApplication<Proveedores> _proveedor;
        public ProveedorController(ILogger<ProveedorController> logger, IApplication<Proveedores> proveedor)
        {
            _logger = logger;
            _proveedor = proveedor;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_proveedor.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Proveedores proveedor = _proveedor.GetById(Id.Value);
            if (proveedor is null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Proveedores proveedor)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            _proveedor.Save(proveedor);
            return Ok(proveedor.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Proveedores proveedor)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Proveedores proveedorBack = _proveedor.GetById(Id.Value);
                if (proveedorBack is null)
                { return NotFound(); }
                proveedorBack.RazonSocial = proveedor.RazonSocial;
                proveedorBack.Telefono = proveedor.Telefono;
                proveedorBack.Email = proveedor.Email;
                proveedorBack.Direccion = proveedor.Direccion;
                _proveedor.Save(proveedorBack);
                return Ok(proveedorBack);
            }

            [HttpDelete]
            public async Task<IActionResult> Borrar(int? Id)
            {
                if (!Id.HasValue)
                { return BadRequest(); }
                if (!ModelState.IsValid)
                { return BadRequest(); }
            Proveedores proveedorBack = _proveedor.GetById(Id.Value);
            if (proveedorBack is null)
                { return NotFound(); }
                _proveedor.Delete(proveedorBack.Id);
                return Ok();
            }
    }
}

