using AutoMapper;
using MasterStock.Aplication.Dto.Producto;
using MasterStock.Aplication;
using MasterStock.Entitis.MicrosoftIdentity;
using MasterStock.Entitis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MasterStock.Aplication.Dto.MovimientoStock;

namespace MasterStock.WebApi.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class MovimientosStockController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<MovimientosStockController> _logger;
        private readonly IApplication<MovimientodeStock> _movimiento;
        private readonly IMapper _mapper;
        public MovimientosStockController(
            ILogger<MovimientosStockController> logger
            , UserManager<User> userManager
            , IApplication<MovimientodeStock> producto
            , IMapper mapper)
        {
            _logger = logger;
            _movimiento = producto;
            _mapper = mapper;
            _userManager = userManager;
        }
        //[Authorize]
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            //return Ok(_mapper.Map<IList<CategoriaResponse>>(_categoria.GetAll()));
            var id = User.FindFirst("Id").Value.ToString();
            var user = _userManager.FindByIdAsync(id).Result;
            if (_userManager.IsInRoleAsync(user, "Administrador").Result)
            {
                var name = User.FindFirst("name");
                var a = User.Claims;
                return Ok(_mapper.Map<IList<MovimientodeStock>>(_movimiento.GetAll()));
            }
            return Unauthorized();
        }
        //[Authorize]
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            MovimientodeStock movimientodeStock= _movimiento.GetById(Id.Value);
            if (movimientodeStock is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MovimientodeStock>(movimientodeStock));
        }
        //[Authorize]
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Crear(MovimientoStockRequets movimientoStockRequets)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var movimientoBack = _mapper.Map<MovimientodeStock>(movimientoStockRequets);
            _movimiento.Save(movimientoBack);
            return Ok(movimientoBack.Id);
        }
        //[Authorize]
        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Editar(int? Id, MovimientoStockRequets movimientoStockRequets)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            MovimientodeStock movimientodeStock = _movimiento.GetById(Id.Value);
            if (movimientodeStock is null)
            { return NotFound(); }
            movimientodeStock = _mapper.Map<MovimientodeStock>( movimientoStockRequets);
            _movimiento.Save(movimientodeStock);
            return Ok();
        }
        //[Authorize]
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            MovimientodeStock movimientodeStock = _movimiento.GetById(Id.Value);
            if (movimientodeStock is null)
            { return NotFound(); }
            _movimiento.Delete(movimientodeStock.Id);
            return Ok();
        }
    }
}
