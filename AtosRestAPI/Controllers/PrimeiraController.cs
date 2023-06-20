using AtosRestAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtosRestAPI.Controllers
{
    [Authorize] // => Para tornar o acesso ao endpoint privado
    [ApiController]
    [Route("[controller]")]
    public class PrimeiraController : ControllerBase
    {

        private readonly IJWTAuthManager _jWTAuthManager;

        public PrimeiraController(IJWTAuthManager jWTAuthManager)
        {
            this._jWTAuthManager = jWTAuthManager;
        }

        [AllowAnonymous] // => Para liberar o acesso ao endpoint
        [HttpGet("primeiro")]
        public string primeiroEndPoint()
        {
            return "Aula Rest API";
        }

        [HttpGet("nome")]
        public string nomeEndPoint()
        {
            return "Taylor";
        }

        [HttpGet("idade")]
        public int idadeEndPoint()
        {
            return 18;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Authenticate([FromBody] Usuario user)
        {
            var token = _jWTAuthManager.Authenticate(user.Username, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}
