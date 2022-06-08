using EstudoAPI.Application.Adapters;
using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using System;

namespace EstudoAPI.Application.Services
{
    public class AlunoService : IAlunoService
    {
        
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        
        public AlunoService(IAlunoRepository alunoRepository, IProfessorRepository professorRepository, IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }
        
        
 
        public bool CadastrarAluno(AlunoDTO alunoDTO)
        {
            try
            {
                _alunoRepository.CadastrarAluno(alunoDTO.ToAluno());
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool DeletarAluno(int idAluno)
        {
            try
            {
                _alunoRepository.DeletarAluno(idAluno);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool EditarAluno(int idAluno, AlunoDTO alunoDTO)
        {
            try
            {
                _alunoRepository.EditarAluno(idAluno, alunoDTO.ToAluno());
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Aluno ObterAluno(int idAluno)
        {
            Aluno alunoObtido = _alunoRepository.ObterAluno(idAluno);
            alunoObtido.Disciplinas = _disciplinaRepository.ObterDisciplinas();
            return alunoObtido;
        }
        

    }
}
