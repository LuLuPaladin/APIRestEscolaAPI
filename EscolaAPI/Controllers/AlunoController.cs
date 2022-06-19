using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EscolaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly IAlunoService _alunoService;
        private readonly IProfessorService _professorService;

        public AlunoController(IAlunoService alunoService, IProfessorService professorService)
        {
            _alunoService = alunoService;
            _professorService = professorService;
        }

        [HttpGet("ObterAlunos")]
        public ActionResult<List<AlunoDTO>> ObterAlunos()
        {
            var alunos = _alunoService.ObterAlunos();

            if (alunos == null)
            {
                return BadRequest();
            }

            return Ok(alunos);
        }

        [HttpGet("{idAluno}")]
        public ActionResult<Aluno> ObterAlunoId(int idAluno)
        {
            Aluno aluno = _alunoService.ObterAluno(idAluno);

            if (aluno is null)
            {
                return BadRequest();
            }

            return Ok(aluno);
        }

        [HttpPost("Cadastrar")]
        public ActionResult CadastrarAluno([FromBody] AlunoDTO alunoDTO)
        {

            var alunResponse = _alunoService.CadastrarAluno(alunoDTO);
            if (alunResponse)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("Editar/{idAluno}")]
        public ActionResult EditarAluno(int idAluno, [FromBody] AlunoDTO alunoDTO)
        {
            bool alunResponse = _alunoService.EditarAluno(idAluno,  alunoDTO);

            if (alunResponse)
            {
                return Ok();

            }

            return BadRequest();
        }

        [HttpDelete("Deletar/{idAluno}")]
        public ActionResult DeletarAluno(int idAluno)
        {
            bool alunResponse = _alunoService.DeletarAluno(idAluno);

            if (alunResponse)
            {
                return Ok();
            }

            return BadRequest();
        }





    }
}
