using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Interfaces
{
    public interface IAlunoRepository
    {
        Task<List<AlunoDTO>> ObterAlunos();
        Task<bool> CadastrarAluno(AlunoDTO alunoDTO);
        Task<Aluno> ObterAlunoId(int idAluno);
        Task<bool> EditarAluno(int idAluno, AlunoDTO alunoDTO);
        Task<bool> DeletarAluno(int idAluno);
    }
}
