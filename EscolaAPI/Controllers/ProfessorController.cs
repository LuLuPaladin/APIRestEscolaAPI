using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        private readonly IAlunoService _alunoService;
        private readonly IProfessorService _professorService;

        public ProfessorController(IAlunoService alunoService, IProfessorService professorService)
        {
            _alunoService = alunoService;
            _professorService = professorService;
        }


        [HttpGet("ObterProfessorPorId/{idProfessor}")]
        public ActionResult<Professor> ObterProfessorId(int idProfessor)
        {
            Professor professor = _professorService.ObterProfessor(idProfessor);

            if (professor is null)
            {
                return BadRequest();
            }

            return Ok(professor);
        }

        [HttpPost("CadastrarProfessor")]
        public ActionResult CadastrarProfessor([FromBody] ProfessorDTO professorDTO)
        {
            var profResponse = _professorService.CadastrarProfessor(professorDTO);
            if (profResponse)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("EditarProfessor/{idProfessor}")]
        public ActionResult EditarProfessor(int idProfessor, [FromBody] ProfessorDTO professorDTO)
        {
            var profResponse = _professorService.EditarProfessor(idProfessor, professorDTO);


            if (profResponse)
            {
                return Ok();

            }

            return BadRequest();
        }

        [HttpDelete("DeletarProfessor/{idProfessor}")]
        public ActionResult DeletarProfessor(int idProfessor)
        {
            bool profResponse = _professorService.DeletarProfessor(idProfessor);

            if (profResponse)
            {
                return Ok();
            }

            return BadRequest();
        }


        [HttpPost("DessasociarAluno/{idAluno}/{idProfessor}")]
        public ActionResult DesassociarAluno(int idAluno, int idProfessor)
        {
            var proffResponse = _professorService.DesassociarAluno(idAluno, idProfessor);

            if (proffResponse)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("AssociarAluno/{idAluno}/{idProfessor}")]
        public ActionResult AssociarAluno(int idAluno, int idProfessor)
        {
            var alunResponse = _professorService.AssociarAluno(idAluno, idProfessor);

            if (alunResponse)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("ObterProfessores")]
        public ActionResult<List<ProfessorResponseDTO>> ObterProfessores()
        {
            var professores = _professorService.ObterProfessores();

            if (professores == null)
            {
                return BadRequest();
            }

            return Ok(professores);
        }
    }
}
