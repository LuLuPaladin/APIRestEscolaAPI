using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Interfaces
{
    public interface IProfessorRepository
    {
        Task<bool> CadastrarProfessor(ProfessorDTO professorDTO);
        Task<Professor> ObterProfessorId(int idProfessor);
        Task<bool> EditarProfessor(ProfessorDTO professorDTO);
        Task<bool> DeletarProfessor(int idProfessor);
        Task<bool> AssociarAluno(int idAluno, int idProfessor);
        Task<bool> DesassociarAluno(int idAluno, int idProfessor);
        Task<List<ProfessorDTO>> ObterProfessores();
    }
}
