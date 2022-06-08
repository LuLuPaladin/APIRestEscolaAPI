using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace EstudoAPI.Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;

        public ProfessorService(IProfessorRepository professorRepository, IAlunoRepository alunoRepository, IDisciplinaRepository disciplinaRepository)
        {
            _professorRepository = professorRepository;
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        public bool AssociarAluno(int idAluno, int idProfessor)
        {
            try
            {
                if (idAluno <= 0 && idProfessor <= 0)
                {
                    return false;
                }
                _professorRepository.AssociarAluno(idAluno, idProfessor);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CadastrarProfessor(ProfessorDTO professorDTO)
        {
            try
            {
                if (professorDTO.IdDisciplina <= 0)
                {
                    return false;
                }

                var disciplina = _disciplinaRepository.ObterDisciplina(professorDTO.IdDisciplina);

                if (disciplina is null)
                {
                    return false;
                }
                
                Professor professor = new Professor
                {
                    Nome = professorDTO.Nome,
                    Disciplina = disciplina

                };

                _professorRepository.CadastrarProfessor(professor);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletarProfessor(int idProfessor)
        {
            try
            {
                _professorRepository.DeletarProfessor(idProfessor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DesassociarAluno(int idAluno, int idProfessor)
        {
            try
            {
                _professorRepository.DesassociarAluno(idAluno, idProfessor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditarProfessor(int idProfessor, ProfessorDTO professorDTO)
        {
            try
            {
                
                _professorRepository.EditarProfessor(idProfessor, new Professor 
                {Nome = professorDTO.Nome, Disciplina = new Disciplina {IdDisciplina = professorDTO.IdDisciplina } });
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public Professor ObterProfessor(int idProfessor)
        {

            Professor professor = _professorRepository.ObterProfessor(idProfessor);

            return professor;
        }

        public List<ProfessorResponseDTO> ObterProfessores()
        {
            try
            {
                
                List<Professor> professores = _professorRepository.ObterProfessores();
                List<ProfessorResponseDTO> professoresDTO = new List<ProfessorResponseDTO>();

                foreach (var prof in professores)
                {
                    professoresDTO.Add(new ProfessorResponseDTO { Nome = prof.Nome, Disciplina = prof.Disciplina.Nome });
                    
                }
                return professoresDTO;
            }
            catch (Exception)
            {

                return null;
            }
            

            
        }
    }
}
