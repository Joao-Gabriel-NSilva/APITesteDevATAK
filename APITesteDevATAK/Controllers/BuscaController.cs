using APITesteDevAtak;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITesteDevATAK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscaController : ControllerBase
    {
        [HttpGet(Name = "GetBusca")]
        public string Get(string busca)
        {

            return Buscador.BuscaAsync(busca).Result;
        }
    }
}
