using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public List<Pessoa> GetLista()
        {
            var _DbContext = new _DbContext();
            var vLista = _DbContext.Pessoa.ToList();

            return vLista;
        }
    }
}
