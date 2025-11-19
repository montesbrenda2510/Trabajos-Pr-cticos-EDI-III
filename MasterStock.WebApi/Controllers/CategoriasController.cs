using AutoMapper;
using MasterStock.Aplication;
using MasterStock.Aplication.Dto.Categoria;
using MasterStock.DataAccess.MicrosoftIdentity;
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
    [Authorize(Roles = "Administrador")]
    public class CategoriasController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CategoriasController> _logger;
        private readonly IApplication<Categoria> _categoria;
        private readonly IMapper _mapper;
        public CategoriasController(
            ILogger<CategoriasController> logger
            , UserManager<User> userManager
            , IApplication<Categoria> categoria
            , IMapper mapper)
        {
            _logger = logger;
            _categoria = categoria;
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
                return Ok(_mapper.Map<IList<CategoriaResponse>>(_categoria.GetAll()));
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
            Categoria categoria = _categoria.GetById(Id.Value);
            if (categoria is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoriaResponse>(categoria));
        }
        //[Authorize]
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Crear(CategoriaRequest categoriaRequest)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var categoriaBack = _mapper.Map<Categoria>(categoriaRequest);
            _categoria.Save(categoriaBack);
            return Ok(categoriaBack.Id);
        }
        //[Authorize]
        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Editar(int? Id, CategoriaRequest categoriaRequest)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Categoria categoriaBack = _categoria.GetById(Id.Value);
            if (categoriaBack is null)
            { return NotFound(); }
            categoriaBack = _mapper.Map<Categoria>(categoriaRequest);
            _categoria.Save(categoriaBack);
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
           Categoria categoriaBack = _categoria.GetById(Id.Value);
            if (categoriaBack is null)
            { return NotFound(); }
            _categoria.Delete(categoriaBack.Id);
            return Ok();
        }
    }
}
