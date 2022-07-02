using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletimEscolarController : ControllerBase
    {

        private readonly IBoletimEscolarService _boletimEscolarService;

        public BoletimEscolarController(IBoletimEscolarService boletimEscolarService)
        {
            _boletimEscolarService = boletimEscolarService;
        }

        [HttpPost("AssociarBoletimEscolar/{idBoletimEscolar}/{idAluno}/{idProfessor}/{Disciplina}")]
        public ActionResult AssociarBoletimEscolar(int idBoletimEscolar, int idAluno, int idProfessor, int idDisciplina)
        {
            var response = _boletimEscolarService.AssociarBoletimEscolar(idAluno, idProfessor, idDisciplina, idBoletimEscolar);

            if (response)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("ObterBoletimEscolarID/{idBoletimEscolar}")]
        public ActionResult<BoletimEscolarResponseDTO> ObterBoletimEscolarId(int idBoletimEscolar)
        {
            BoletimEscolarResponseDTO boletimEscolarDTO = _boletimEscolarService.ObterBoletimEscolar(idBoletimEscolar);

            if (boletimEscolarDTO is null)
            {
                return BadRequest();
            }

            return Ok(boletimEscolarDTO);
        }

        [HttpPost("CadastrarBoletimEscolar")]
        public ActionResult CadastrarBoletimEscolar([FromBody] BoletimEscolarDTO boletimEscolarDTO)
        {
            var bolResponse = _boletimEscolarService.CadastrarBoletimEscolar(boletimEscolarDTO);

            if (bolResponse != true)
            {
                return BadRequest();
                
            }

            return Ok();


        }

        [HttpPut("AtualizarBoletimEscolar/{idBoletimEscolar}")]
        public ActionResult EditarBoletimEscolar(int idBoletimEscolar, [FromBody] BoletimEscolarDTO boletimEscolarDTO)
        {
            var bolResponse = _boletimEscolarService.EditarBoletimEscolar(idBoletimEscolar, boletimEscolarDTO);

            if (bolResponse)
            {
                return Ok();

            }

            return BadRequest();
        }

        [HttpDelete("DeletarBoletimEscolar/{idBoletimEscolar}")]
        public ActionResult DeletarBoletimEscolar(int idBoletimEscolar)
        {
            bool bolResponse = _boletimEscolarService.DeletarBoletimEscolar(idBoletimEscolar);

            if (bolResponse)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("ObterBoletinsAssociadoAoAluno/{idAluno}")]
        public ActionResult<BoletimEscolar>  ObterBoletinsAluno(int idAluno)
        {
            var boletins = _boletimEscolarService.ObterBoletinsAluno(idAluno);

            if (boletins is null)
            {
                return BadRequest();
            }

            return Ok(boletins);
        }
    }
}
