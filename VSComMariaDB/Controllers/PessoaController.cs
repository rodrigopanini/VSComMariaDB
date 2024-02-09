using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSComMariaDB.Model;

namespace VSComMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        /// <summary>
        /// Pegar a lista de todas as pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Pessoa> GetLista()
        {
            var _DbContext = new _DbContext();
            var vLista = _DbContext.Pessoa.ToList();

            return vLista;
        }

        [HttpGet("ListaAsync")]
        public async Task<List<Pessoa>> GetListaAsync()
        {
            var _DbContext = new _DbContext();
            var vLista = await _DbContext.Pessoa.ToListAsync();

            return vLista;
        }

        /// <summary>
        /// Pegar os dados de uma pessoa específica
        /// </summary>
        /// <param name="id">ID da Pessoa</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Pessoa> GetPessoa(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();

            //Selecionar a Pessoa pelo id
            /*var vPessoa = _DbContext.Pessoa
                .Where(p => p.Id == id)
                .FirstOrDefault();*/

            var vPessoa = await _DbContext.Pessoa.FindAsync(id);

            //retornar dos dados
            return vPessoa;
        }

        [HttpPost]
        public async Task<List<Pessoa>> Inserir(List<Pessoa> pessoa)
        {
            var _DbContext = new _DbContext();

            await _DbContext.Pessoa.AddRangeAsync(pessoa);
            await _DbContext.SaveChangesAsync();

            return pessoa;
        }

        [HttpPut]
        public async Task<Pessoa> Alterar(Pessoa pessoa)
        {
            var _DbContext = new _DbContext();

            _DbContext.Pessoa.Entry(pessoa).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();

            return pessoa;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            //Instanciar o banco de dados
            var _DbContext = new _DbContext();
            //Localizar o registro a ser removido pelo id
            var vPessoa = await _DbContext.Pessoa.FindAsync(id);
            //Remover o registro encontrado
            _DbContext.Pessoa.Remove(vPessoa);
            //Salvar alterações
            await _DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
