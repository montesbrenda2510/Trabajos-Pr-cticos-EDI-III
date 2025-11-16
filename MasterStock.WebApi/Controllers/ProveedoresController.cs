using AutoMapper;
using MasterStock.Aplication;
using MasterStock.Aplication.Dto.Categoria;
using MasterStock.Aplication.Dto.Preveedor;
using MasterStock.Entitis;
using MasterStock.Entitis.MicrosoftIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MasterStock.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProveedoresController> _logger;
        private readonly IApplication<Proveedor> _proveedor;
        private readonly IMapper _mapper;
        public ProveedoresController(
            ILogger<ProveedoresController> logger
            , UserManager<User> userManager
            , IApplication<Proveedor> proveedor
            , IMapper mapper)
        {
            _logger = logger;
            _proveedor = proveedor;
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
                return Ok(_mapper.Map<IList<ProveedorResponse>>(_proveedor.GetAll()));
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
            Proveedor proveedor = _proveedor.GetById(Id.Value);
            if (proveedor is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProveedorResponse>(proveedor));
        }
        //[Authorize]
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Crear(ProveedorResquets proveedorRequest)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var proveedorBack = _mapper.Map<Proveedor>(proveedorRequest);
            _proveedor.Save(proveedorBack);
            return Ok(proveedorBack.Id);
        }
        //[Authorize]
        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Editar(int? Id, ProveedorResquets proveedorRequest)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Proveedor proveedorBack = _proveedor.GetById(Id.Value);
            if (proveedorBack is null)
            { return NotFound(); }
            proveedorBack = _mapper.Map<Proveedor>(proveedorRequest);
            _proveedor.Save(proveedorBack);
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
            Proveedor proveedorBack = _proveedor.GetById(Id.Value);
            if (proveedorBack is null)
            { return NotFound(); }
           _proveedor.Delete(proveedorBack.Id);
            return Ok();
        }
    }
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ProveedorController : ControllerBase
    //{
    //    private readonly ILogger<ProveedorController> _logger;
    //    private readonly IApplication<Proveedor> _proveedor;
    //    public ProveedorController(ILogger<ProveedorController> logger, IApplication<Proveedor> proveedor)
    //    {
    //        _logger = logger;
    //        _proveedor = proveedor;
    //    }

    //    [HttpGet]
    //    [Route("All")]
    //    public async Task<IActionResult> All()
    //    {
    //        return Ok(_proveedor.GetAll());
    //    }

    //    [HttpGet]
    //    [Route("ById")]
    //    public async Task<IActionResult> ById(int? Id)
    //    {
    //        if (!Id.HasValue)
    //        {
    //            return BadRequest();
    //        }
    //        Proveedor proveedor = _proveedor.GetById(Id.Value);
    //        if (proveedor is null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(proveedor);
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Crear(Proveedor proveedor)
    //    {
    //        if (!ModelState.IsValid)
    //        { return BadRequest(); }
    //        _proveedor.Save(proveedor);
    //        return Ok(proveedor.Id);
    //    }

    //    [HttpPut]
    //    public async Task<IActionResult> Editar(int? Id, Proveedor proveedor)
    //    {
    //        if (!Id.HasValue)
    //        { return BadRequest(); }
    //        if (!ModelState.IsValid)
    //        { return BadRequest(); }
    //        Proveedor proveedorBack = _proveedor.GetById(Id.Value);
    //            if (proveedorBack is null)
    //            { return NotFound(); }
    //            proveedorBack.RazonSocial = proveedor.RazonSocial;
    //            proveedorBack.Telefono = proveedor.Telefono;
    //            proveedorBack.Email = proveedor.Email;
    //            proveedorBack.Direccion = proveedor.Direccion;
    //            _proveedor.Save(proveedorBack);
    //            return Ok(proveedorBack);
    //        }

    //        [HttpDelete]
    //        public async Task<IActionResult> Borrar(int? Id)
    //        {
    //            if (!Id.HasValue)
    //            { return BadRequest(); }
    //            if (!ModelState.IsValid)
    //            { return BadRequest(); }
    //        Proveedor proveedorBack = _proveedor.GetById(Id.Value);
    //        if (proveedorBack is null)
    //            { return NotFound(); }
    //            _proveedor.Delete(proveedorBack.Id);
    //            return Ok();
    //        }
    //}
}

