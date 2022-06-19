using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Controllers
{
    [Route("[controller]")]

    public class AlunoController : Controller
    {

        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: AlunoController
        [HttpGet("ObterAlunos")]
        public async Task< ActionResult> Index()
        {
            IEnumerable<AlunoDTO> listaAlunos = await _alunoRepository.ObterAlunos();
            return View(listaAlunos);
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet("CriarAluno")]

        public ActionResult Create()
        {
            return View("CriarAluno");
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
        public async Task<ActionResult> EditarAluno(AlunoDTO aluno)
        {
            try
            {
                bool response = await _alunoRepository.EditarAluno(aluno.IdAluno, new AlunoDTO { Nome = aluno.Nome });

                if (response)
                {
                    return RedirectToAction(nameof(Index));
                    //RedirectToAction("EditarAluno/", new RouteValueDictionary ( new  { idAluno = aluno.IdAluno } ));
                }

            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
    }
}
