using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using System;
using System.Globalization;

namespace EstudoAPI.Application.Services
{
    public class BoletimEscolarService : IBoletimEscolarService
    {
        private readonly IBoletimEscolarRepository _boletimEscolarRepository;
        private readonly IDisciplinaRepository  _disciplinaRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IAlunoRepository _alunosRepository;


        public BoletimEscolarService(IBoletimEscolarRepository boletimEscolarRepository, IDisciplinaRepository disciplinaRepository,
            IProfessorRepository professorRepository, IAlunoRepository alunosRepository)
        {
            _boletimEscolarRepository = boletimEscolarRepository;
            _disciplinaRepository =  disciplinaRepository;
            _alunosRepository = alunosRepository;
            _professorRepository = professorRepository;
        }

        public bool AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar)
        {
            try
            {
                if (idAluno <= 0 || idProfessor <= 0 || idDisciplina <= 0 || idBoletimEscolar <= 0)
                {
                    return false;
                }
                _boletimEscolarRepository.AssociarBoletimEscolar(idAluno, idProfessor, idDisciplina, idBoletimEscolar);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CadastrarBoletimEscolar(BoletimEscolarDTO boletimEscolarDTO)
        {
            try
            {
                var disciplina = _disciplinaRepository.ObterDisciplina(boletimEscolarDTO.IdDisciplina);
                var aluno = _alunosRepository.ObterAluno(boletimEscolarDTO.IdAluno);
                var professor = _professorRepository.ObterProfessor(boletimEscolarDTO.IdProfessor);

                if (disciplina is null || aluno is null || professor is null)
                {
                    return false;
                }

                if (boletimEscolarDTO is null)
                {
                    return false;
                }

                _boletimEscolarRepository.CadastrarBoletimEscolar(new BoletimEscolar {
                    DescricaoBoletimEscolar = boletimEscolarDTO.DescricaoBoletim,
                    DataNota = boletimEscolarDTO.DataBoletim,
                    NotaBoletimEscolar = boletimEscolarDTO.NotaBoletim,
                    Aluno = aluno,
                    Professor = professor,
                    Disciplina = disciplina
                    });

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeletarBoletimEscolar(int idBoletimEscolar)
        {
            try
            {
                _boletimEscolarRepository.DeletarBoletimEscolar(idBoletimEscolar);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool EditarBoletimEscolar(int idBoletimEscolar, BoletimEscolarDTO boletimEscolarDTO)
        {
            try
            {
                _boletimEscolarRepository.EditarBoletimEscolar(idBoletimEscolar,
                    new BoletimEscolar
                    {
                        IdBoletimEscolar = idBoletimEscolar,
                        DescricaoBoletimEscolar = boletimEscolarDTO.DescricaoBoletim,
                        NotaBoletimEscolar = boletimEscolarDTO.NotaBoletim,
                        DataNota = boletimEscolarDTO.DataBoletim,
                        Aluno = new Aluno { IdAluno = boletimEscolarDTO.IdAluno },
                        Professor = new Professor { IdProfessor = boletimEscolarDTO.IdProfessor},
                        Disciplina = new Disciplina { IdDisciplina = boletimEscolarDTO.IdDisciplina}
                    });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public BoletimEscolar ObterBoletimEscolar(int idBoletimEscolar)
        {
            
            BoletimEscolar boletimEscolar = _boletimEscolarRepository.ObterBoletimEscolar(idBoletimEscolar);
            return boletimEscolar;
        }
    }
}
