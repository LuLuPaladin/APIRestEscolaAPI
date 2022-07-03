using EscolaAPI_FRONT.Adapter;
using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Controllers
{
    [Route("[controller]")]

    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IBoletimEscolarRepository _boletimEscolarRepository;
        private readonly IProfessorRepository _professorRepository;

        public AlunoController(IAlunoRepository alunoRepository, IBoletimEscolarRepository boletimEscolarRepository,
            IProfessorRepository professorRepository)
        {
            _alunoRepository = alunoRepository;
            _boletimEscolarRepository = boletimEscolarRepository;
            _professorRepository = professorRepository;
        }

        // GET: AlunoController
        [HttpGet("ObterAlunos")]
        public async Task<ActionResult> Index()
        {
            IEnumerable<AlunoDTO> listaAlunos = await _alunoRepository.ObterAlunos();
            return View(listaAlunos);
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet("CadastrarAluno")]
        public ActionResult CadastrarAluno()
        {
            return View("CadastrarAluno");
        }

        // POST: AlunoController/Create
        [HttpPost("CadastrarAluno")]
        public async Task<ActionResult> CadastrarAluno(AlunoDTO alunoDTO)
        {

            bool response = await _alunoRepository.CadastrarAluno(alunoDTO);

            if (response == false)
            {

                return View("CadastrarAluno");
            }

            return RedirectToAction("Index");

        }

        // GET: AlunoController/Edit/5

        [HttpGet("EditarAluno/{idAluno}")]
        public async Task<ActionResult> Edit(int idAluno)
        {
            try
            {
                Aluno aluno = await _alunoRepository.ObterAlunoId(idAluno);
                return View("EditarAluno", aluno);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        // POST: AlunoController/Edit/5

        [HttpPost("EditarAluno")]
        public async Task<ActionResult> EditarAluno(AlunoDTO alunoDTO)
        {
            try
            {
                bool response = await _alunoRepository.EditarAluno(alunoDTO.IdAluno, new AlunoDTO { Nome = alunoDTO.Nome });

                if (response)
                {
                    return RedirectToAction(nameof(Index));
                    //RedirectToAction("EditarAluno/", new RouteValueDictionary ( new  { idAluno = aluno.IdAluno } ));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return RedirectToAction("Index");
        }

        // GET: AlunoController/Delete/5
        [HttpGet("DeletarAluno/{idAluno}")]
        public async Task<ActionResult> Delete(int idAluno)
        {
            Aluno aluno = await _alunoRepository.ObterAlunoId(idAluno);

            return View("DeletarAluno", aluno);
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("BoletimEscolar/{idAluno}")]
        public async Task<ActionResult> ObterBoletimEscolar(int idAluno)
        {
            try
            {
                List<BoletimEscolarDTO> boletimEscolarDTO = (await _boletimEscolarRepository.ObterBoletinsAluno(idAluno)).ToBoletinsEscolaresDTOs();
                if (boletimEscolarDTO == null || !boletimEscolarDTO.Any())
                {
                    Aluno alunoBoletim = await _alunoRepository.ObterAlunoId(idAluno);
                    ViewBag.IdAluno = alunoBoletim.IdAluno;
                    ViewBag.NomeAluno = alunoBoletim.Nome;
                }
                else
                {
                    ViewBag.IdAluno = boletimEscolarDTO.First().IdAluno;
                    ViewBag.NomeAluno = boletimEscolarDTO.First().NomeAluno;
                }
                return View("ObterBoletimEscolar", boletimEscolarDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("CriarBoletimEscolar/{idAluno}")]
        public async Task<ActionResult> CriarBoletimEscolar(int idAluno)
        {

            List<ProfessorDTO> professores = await _professorRepository.ObterProfessores();
            ViewBag.Professores = professores;
            ViewBag.IdAluno = idAluno;
            ViewBag.NomeAluno = (await _alunoRepository.ObterAlunoId(idAluno)).Nome;
            return View("CriarBoletimEscolar");
        }

        [HttpPost("CriarBoletimEscolarPost")]
        public async Task<ActionResult> CriarBoletimEscolarPost(BoletimEscolarRequestDTO boletimEscolarRequestDTO)
        {


            bool response = await _boletimEscolarRepository.CadastrarBoletimEscolar(boletimEscolarRequestDTO.ToBoletimEscolarResponseDTO());

            if (response)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
