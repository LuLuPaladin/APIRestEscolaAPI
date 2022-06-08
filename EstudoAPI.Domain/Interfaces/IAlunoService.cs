using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IAlunoService
    {
        
        bool CadastrarAluno(AlunoDTO alunoDTO);
        Aluno ObterAluno(int idAluno);
        bool EditarAluno(int idAluno, AlunoDTO alunoDTO);
        bool DeletarAluno(int idAluno);
        
    }
}
