using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using System.Collections.Generic;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IProfessorService
    {
        
        bool CadastrarProfessor(ProfessorDTO professorDTO);
        Professor ObterProfessor(int idProfessor);
        bool EditarProfessor(int idProfessor, ProfessorDTO ProfessorDTO);
        bool DeletarProfessor(int idProfessor);
        bool AssociarAluno(int idAluno, int idProfessor);
        bool DesassociarAluno(int idAluno, int idProfessor);
        public List<ProfessorResponseDTO> ObterProfessores();


    }
}
