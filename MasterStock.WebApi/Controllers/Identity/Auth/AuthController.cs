using MasterStock.Aplication.Dto.Identity.User;
using MasterStock.Aplication.Dto.Login;
using MasterStock.Entitis.MicrosoftIdentity;
using MasterStock.Services;
using MasterStock.WebApi.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MasterStock.WebApi.Controllers.Identity.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Entitis.MicrosoftIdentity.User> _userManager;
        private readonly ILogger<CategoriasController> _logger;
        private readonly ITokenHandlerService _servicioToken;
        public AuthController(
            UserManager<Entitis.MicrosoftIdentity.User> userManager
            , ILogger<CategoriasController> logger
            , ITokenHandlerService servicioToken)
        {
            _userManager = userManager;
            _logger = logger;
            _servicioToken = servicioToken;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UserRequet user)
        {
            if (ModelState.IsValid)
            {
                var existeUsuario = await _userManager.FindByEmailAsync(user.Email);
                if (existeUsuario != null)
                {
                    return BadRequest("Existe un usuario registrado con el mal " + user.Email + ".");
                }
                var Creado = await _userManager.CreateAsync(new Entitis.MicrosoftIdentity.User()
                {
                    Email = user.Email,
                    UserName = user.Email.Substring(0, user.Email.IndexOf('@')),
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    FechaNacimiento = user.FechaNacimiento
                }, user.Password);
                if (Creado.Succeeded)
                {
                    return Ok(new UserResponse
                    {
                        NombreCompleto = string.Join(" ", user.Nombres, user.Apellidos),
                        Email = user.Email,
                        UserName = user.Email.Substring(0, user.Email.IndexOf('@'))
                    });
                }

                else
                {
                    return BadRequest(Creado.Errors.Select(e => e.Description).ToList());
                }
            }
            else
            {
                return BadRequest("Los datos enviados no son validos.");
            }
        }

        [HttpPost]
        [Route("RegisterSincronico")]
        public IActionResult RegistrarUsuarioincronico([FromBody] UserRequet user)
        {
            if (ModelState.IsValid)
            {
                var existeUsuario = _userManager.FindByEmailAsync(user.Email).Result;
                if (existeUsuario != null)
                {
                    return BadRequest("Existe un usuario registrado con el mal " + user.Email + ".");
                }
                var Creado = _userManager.CreateAsync(new Entitis.MicrosoftIdentity.User()
                {
                    Email = user.Email,
                    UserName = user.Email.Substring(0, user.Email.IndexOf('@')),
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    FechaNacimiento = user.FechaNacimiento
                }, user.Password).Result;
                if (Creado.Succeeded)
                {
                    var userBack = _userManager.FindByEmailAsync(user.Email);
                    _ = _userManager.AddToRoleAsync(userBack.Result, "Administrador");
                    return Ok(new UserResponse
                    {
                        NombreCompleto = string.Join(" ", user.Nombres, user.Apellidos),
                        Email = user.Email,
                        UserName = user.Email.Substring(0, user.Email.IndexOf('@'))
                    });
                }
                else
                {
                    return BadRequest(Creado.Errors.Select(e => e.Description).ToList());
                }
            }
            else
            {
                return BadRequest("Los datos enviados no son validos.");
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserRequet userlogin)
        {
            if (ModelState.IsValid)
            {
                var existeUsuario = await _userManager.FindByEmailAsync(userlogin.Email);
                if (existeUsuario != null)
                {
                    var isCorrect = await _userManager.CheckPasswordAsync(existeUsuario, userlogin.Password);
                    if (isCorrect)
                    {
                        try
                        {
                            var parametros = new TokenParameters()
                            {
                                Id = existeUsuario.Id.ToString(),
                                PaswordHash = existeUsuario.PasswordHash,
                                UserName = existeUsuario.UserName,
                                Email = existeUsuario.Email
                            };
                            var jwt = _servicioToken.GenerateJwtTokens(parametros);
                            return Ok(new LoginUserResponse()
                            {
                                Login = true,
                                Token = jwt,
                                UserName = existeUsuario.UserName,
                                Mail = existeUsuario.Email
                            });
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
            return BadRequest(new LoginUserResponse()
            {
                Login = false,
                Errores = new List<string>()
                    {
                       "Usuario o contraseña incorrecto!"
                    }
            });
        }
    }
}
