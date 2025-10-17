using MasterStock.Aplication;
using MasterStock.Entitis;
using Microsoft.AspNetCore.Mvc;

namespace MasterStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController:ControllerBase
    {
       
            private readonly ILogger<CategoriasController> _logger;
            private readonly IApplication<Categorias> _categoria;
            public CategoriasController(ILogger<CategoriasController> logger, IApplication<Categorias> categoria)
            {
                _logger = logger;
                _categoria = categoria;
            }

            [HttpGet]
            [Route("All")]
            public async Task<IActionResult> All()
            {
                return Ok(_categoria.GetAll());
            }

            [HttpGet]
            [Route("ById")]
            public async Task<IActionResult> ById(int? Id)
            {
                if (!Id.HasValue)
                {
                    return BadRequest();
                }
                Categorias categoria = _categoria.GetById(Id.Value);
                if (categoria is null)
                {
                    return NotFound();
                }
                return Ok(categoria);
            }

            [HttpPost]
            public async Task<IActionResult> Crear(Categorias categorias)
            {
                if (!ModelState.IsValid)
                { return BadRequest(); }
                _categoria.Save(categorias);
                return Ok(categorias.Id);
            }

            [HttpPut]
            public async Task<IActionResult> Editar(int? Id, Categorias categorias)
            {
                if (!Id.HasValue)
                { return BadRequest(); }
                if (!ModelState.IsValid)
                { return BadRequest(); }
                Categorias categoriaBack = _categoria.GetById(Id.Value);
                if (categoriaBack is null)
                { return NotFound(); }
                categoriaBack.NombreCategoria = categorias.NombreCategoria;
              
                return Ok(categoriaBack);
            }

            [HttpDelete]
            public async Task<IActionResult> Borrar(int? Id)
            {
                if (!Id.HasValue)
                { return BadRequest(); }
                if (!ModelState.IsValid)
                { return BadRequest(); }
                Categorias categoriaBack = _categoria.GetById(Id.Value);
                if (categoriaBack is null)
                { return NotFound(); }
           
                _categoria.Delete(categoriaBack.Id);
                return Ok();
            }
        }
}
