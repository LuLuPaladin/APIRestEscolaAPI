using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;

namespace EstudoAPI.Application.Adapters
{
    public static class ProfessorAdapter
    {
        public static ProfessorResponseDTO ToProfessorResponseDTO(this Professor professor)
        {
            return new ProfessorResponseDTO { IdProfessor = professor.IdProfessor, Nome = professor.Nome, Disciplina = professor.Disciplina.Nome, IdDisciplina = professor.Disciplina.IdDisciplina };
        }
    }
}
