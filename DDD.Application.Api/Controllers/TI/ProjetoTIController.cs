using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.TI;
using DDD.Infra.SQLServer.Interfaces.SecretariaInterface;
using DDD.Infra.SQLServer.Interfaces.TIInterface;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers.TI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoTIController : ControllerBase
    {
        readonly IProjetoTIRepository _projetoTIRepository;

        public ProjetoTIController(IProjetoTIRepository projetoTIRepository)
        {
            _projetoTIRepository = projetoTIRepository;
        }

        [HttpGet]
        public ActionResult<List<ProjetoTI>> Get()
        {
            return Ok(_projetoTIRepository.GetProjetosTI());
        }

        [HttpGet("{id}")]
        public ActionResult<ProjetoTI> GetById(int id)
        {
            return Ok(_projetoTIRepository.GetProjetoTIById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjetoTI> CreateProjetoTI(int idGerente, int idProgramador)
        {
            ProjetoTI projetoTIIdSaved = _projetoTIRepository.InsertProjetoTI(idGerente, idProgramador);
            return CreatedAtAction(nameof(GetById), new { id = projetoTIIdSaved.ProjetoId }, projetoTIIdSaved);
        }

        //[HttpPut]
        //public ActionResult Put([FromBody] Aluno aluno)
        //{
        //    try
        //    {
        //        if (aluno == null)
        //            return NotFound();

        //        _alunoRepository.UpdateAluno(aluno);
        //        return Ok("Cliente Atualizado com sucesso!");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //// DELETE api/values/5
        //[HttpDelete()]
        //public ActionResult Delete([FromBody] Aluno aluno)
        //{
        //    try
        //    {
        //        if (aluno == null)
        //            return NotFound();

        //        _alunoRepository.DeleteAluno(aluno);
        //        return Ok("Cliente Removido com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

    }
}
