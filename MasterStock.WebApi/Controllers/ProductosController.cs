using AutoMapper;
using MasterStock.Aplication.Dto.Categoria;
using MasterStock.Aplication;
using MasterStock.Entitis.MicrosoftIdentity;
using MasterStock.Entitis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MasterStock.Aplication.Dto.Producto;

namespace MasterStock.WebApi.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class ProductosController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProductosController> _logger;
        private readonly IApplication<Producto> _producto;
        private readonly IMapper _mapper;
        public ProductosController(
            ILogger<ProductosController> logger
            , UserManager<User> userManager
            , IApplication<Producto> producto
            , IMapper mapper)
        {
            _logger = logger;
            _producto = producto;
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
                return Ok(_mapper.Map<IList<ProductoResponse>>(_producto.GetAll()));
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
            Producto producto = _producto.GetById(Id.Value);
            if (producto is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductoResponse>(producto));
        }
        //[Authorize]
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Crear(ProductoRequets productoRequets)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var productoBack = _mapper.Map<Producto>(productoRequets);
            _producto.Save(productoBack);
            return Ok(productoBack.Id);
        }
        //[Authorize]
        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Editar(int? Id, ProductoRequets productoRequets)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Producto productoBack = _producto.GetById(Id.Value);
            if (productoBack is null)
            { return NotFound(); }
            productoBack = _mapper.Map<Producto>(productoRequets);
           _producto.Save(productoBack);
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
           Producto productoBack = _producto.GetById(Id.Value);
            if (productoBack is null)
            { return NotFound(); }
           _producto.Delete(productoBack.Id);
            return Ok();
        }
    }
}
