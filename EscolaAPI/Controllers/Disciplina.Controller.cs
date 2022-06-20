using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {

        private readonly IDisciplinaService _disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpGet("ObterDisciplina/{idDisciplina}")]
        public ActionResult<Disciplina> ObterDisciplinaId(int idDisciplina)
        {
            Disciplina disciplina = _disciplinaService.ObterDisciplina(idDisciplina);

            if (disciplina is null)
            {
                return BadRequest();
            }

            return Ok(disciplina);
        }

        [HttpPost("CadastrarDisciplina")]
        public ActionResult CadastrarDisciplina([FromBody] DisciplinaDTO disciplinaDTO)
        {
            var discResponse = _disciplinaService.CadastrarDisciplina(disciplinaDTO);
            if (discResponse)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("EditarDisciplina/{idDisciplina}")]
        public ActionResult EditarDisciplina(int idDisciplina, [FromBody] DisciplinaDTO disciplinaDTO)
        {
            var discResponse = _disciplinaService.EditarDisciplina(idDisciplina, disciplinaDTO);

            if (discResponse)
            {
                return Ok();

            }

            return BadRequest();
        }

        [HttpDelete("DeletarDisciplina/{idDisciplina}")]
        public ActionResult DeletarDisciplina(int idDisciplina)
        {
            bool discResponse = _disciplinaService.DeletarDisciplina(idDisciplina);

            if (discResponse)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
