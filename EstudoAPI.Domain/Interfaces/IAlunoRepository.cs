using EstudoAPI.Domain.Entities;
using System.Collections.Generic;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IAlunoRepository
    {

        void CadastrarAluno(Aluno aluno);
        Aluno ObterAluno(int idAluno);
        void EditarAluno(int idAluno, Aluno aluno);
        void DeletarAluno(int idAluno);
        List<Aluno> ObterAlunoAssociadoAoProfessor(int idProfessor);
    }
}
