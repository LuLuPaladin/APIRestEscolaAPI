using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using System.Collections.Generic;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IAlunoService
    {
        List<AlunoDTO> ObterAlunos();
        bool CadastrarAluno(AlunoDTO alunoDTO);
        Aluno ObterAluno(int idAluno);
        bool EditarAluno(int idAluno, AlunoDTO alunoDTO);
        bool DeletarAluno(int idAluno);
    }
}
