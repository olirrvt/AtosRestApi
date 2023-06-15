using Microsoft.AspNetCore.Mvc;

namespace AtosRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimeiraController : ControllerBase
    {
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

        //[HttpPost("")]
        //public string PostNomeIdade([FromBody] Pessoa pessoa)
        //{
        //    if (pessoa.Idade >= 18)
        //    {
        //        return $"{pessoa.Nome} é maior de idade.";
        //    }
        //    else
        //    {
        //        return $"{pessoa.Nome} não é maior de idade.";
        //    }
        //}

    }
}
