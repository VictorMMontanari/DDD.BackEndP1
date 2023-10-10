using DDD.Domain.SecretariaContext;
using DDD.Domain.TI;
using DDD.Infra.SQLServer.Interfaces.TIInterface;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers.TI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramadorController : ControllerBase
    {
        readonly IProgramadorRepository _programadorRepository;

        public ProgramadorController(IProgramadorRepository programadorRepository)
        {
            _programadorRepository = programadorRepository;
        }

        // GET: api/<ProgramadorController>
        [HttpGet]
        public ActionResult<List<Programador>> Get()
        {
            return Ok(_programadorRepository.GetProgramadors());
        }

        [HttpGet("{id}")]
        public ActionResult<Programador> GetById(int id)
        {
            return Ok(_programadorRepository.GetProgramadorById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Programador> CreateAluno(Programador programador)
        {
            if (programador.Nome.Length < 3 || programador.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _programadorRepository.InsertProgramador(programador);
            return CreatedAtAction(nameof(GetById), new { id = programador.UserId }, programador);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Programador programador)
        {
            try
            {
                if (programador == null)
                    return NotFound();

                _programadorRepository.UpdateProgramador(programador);
                return Ok("Programador Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Programador programador)
        {
            try
            {
                if (programador == null)
                    return NotFound();

                _programadorRepository.DeleteProgramador(programador);
                return Ok("Programador Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
