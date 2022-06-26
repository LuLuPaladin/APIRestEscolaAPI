using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Models;
using System.Collections.Generic;

namespace EscolaAPI_FRONT.Adapter
{
    public static class ProfessorAdapter
    {
        public static ProfessorDTO ToProfessorRequestDTO(this Professor professor)
        {
            return new ProfessorDTO
            {
                IdProfessor = professor.IdProfessor,
                Nome = professor.Nome,
                NomeDisciplina = professor.Disciplina.Nome,
                IdDisciplina = professor.Disciplina.IdDisciplina
            };
        }

        public static List<ProfessorDTO> ToProfessoresListDTO(this List<Professor> professores)
        {
            List<ProfessorDTO> professorListDTO = new List<ProfessorDTO>();
            foreach (Professor professor in professores)
            {
                professorListDTO.Add(new ProfessorDTO { Nome = professor.Nome, NomeDisciplina = professor.Disciplina.Nome });
            }

            return professorListDTO;
        }
    }
}
