using DDD.Domain.SecretariaContext;
using DDD.Domain.TI;
using DDD.Infra.SQLServer.Interfaces.TIInterface;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers.TI
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {
        readonly IGerenteRepository _gerenteRepository;

        public GerenteController(IGerenteRepository gerenteRepository)
        {
            _gerenteRepository = gerenteRepository;
        }

        // GET: api/<GerenteController>
        [HttpGet]
        public ActionResult<List<Gerente>> Get()
        {
            return Ok(_gerenteRepository.GetGerentes());
        }

        [HttpGet("{id}")]
        public ActionResult<Gerente> GetById(int id)
        {
            return Ok(_gerenteRepository.GetGerenteById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Gerente> CreateGerente(Gerente gerente)
        {
            if (gerente.Nome.Length < 3 || gerente.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _gerenteRepository.InsertGerente(gerente);
            return CreatedAtAction(nameof(GetById), new { id = gerente.UserId }, gerente);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Gerente gerente)
        {
            try
            {
                if (gerente == null)
                    return NotFound();

                _gerenteRepository.UpdateGerente(gerente);
                return Ok("Gerente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Gerente gerente)
        {
            try
            {
                if (gerente == null)
                    return NotFound();

                _gerenteRepository.DeleteGerente(gerente);
                return Ok("Gerente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
