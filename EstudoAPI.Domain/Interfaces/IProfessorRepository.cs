using EstudoAPI.Domain.Entities;
using System.Collections.Generic;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IProfessorRepository
    {
        void CadastrarProfessor(Professor professor);
        Professor ObterProfessor(int idProfessor);
        void EditarProfessor(int idProfessor, Professor professor);
        void DeletarProfessor(int idProfessor);
        void AssociarAluno(int idAluno, int idProfessor);
        void DesassociarAluno(int idAluno, int idProfessor);
        List<Professor> ObterProfessoresAssociadosAoAluno(int idAluno);
        List<Professor> ObterProfessores();
    }
}
