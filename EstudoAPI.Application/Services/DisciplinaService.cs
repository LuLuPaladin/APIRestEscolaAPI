using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using System;

namespace EstudoAPI.Application.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        public bool CadastrarDisciplina(DisciplinaDTO disciplinaDTO)
        {
            try
            {
                _disciplinaRepository.CadastrarDisciplina(new Disciplina {Nome = disciplinaDTO.Nome });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletarDisciplina(int idDisciplina)
        {
            try
            {
                _disciplinaRepository.DeletarDisciplina(idDisciplina);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EditarDisciplina(int idDisciplina, DisciplinaDTO disciplinaDTO)
        {
            try
            {
                _disciplinaRepository.EditarDisciplina(new Disciplina { Nome = disciplinaDTO.Nome, IdDisciplina = idDisciplina });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Disciplina ObterDisciplina(int idDisciplina)
        {
            Disciplina disciplina = _disciplinaRepository.ObterDisciplina(idDisciplina);
            return disciplina;
        }
        
    }
}
