using EscolaAPI_FRONT.Adapter;
using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using EscolaAPI_FRONT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Controllers
{
    [Route("[controller]")]
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
    

        public ProfessorController(IProfessorRepository professorRepository, IDisciplinaRepository disciplinaRepository)
        {
            _professorRepository = professorRepository;
            _disciplinaRepository = disciplinaRepository;
        }
        // GET: ProfessorController
        [HttpGet("ObterProfessores")]
        public async Task<ActionResult> Index()
        {
            return View(await _professorRepository.ObterProfessores());
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfessorController/Create
        public  ActionResult Create()
        {
            return View();
            
        }

        // POST: ProfessorController/Create
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

        // GET: ProfessorController/Edit/5
        [HttpGet("EditarProfessor/{idProfessor}")]
        public async Task<ActionResult> Edit(int idProfessor)
        {
            try
            {
                List<Disciplina> disciplinas = await _disciplinaRepository.ObterDisciplinas();
                Professor professor = await _professorRepository.ObterProfessorId(idProfessor);
                ViewBag.Disciplinas = disciplinas;
                return View("EditarProfessor", professor.ToProfessorRequestDTO());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // POST: ProfessorController/Edit/5
        [HttpPost("EditarProfessor")]
        public async Task<ActionResult> EditarProfessor(ProfessorDTO professorDTO)
        {
            bool response = await _professorRepository.EditarProfessor(new ProfessorDTO
            {
                Nome = professorDTO.Nome,
                IdProfessor = professorDTO.IdProfessor,
                IdDisciplina = professorDTO.IdDisciplina
            });

            if (response == false)
            {
                return View("EditarProfessor");
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: ProfessorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfessorController/Delete/5
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
