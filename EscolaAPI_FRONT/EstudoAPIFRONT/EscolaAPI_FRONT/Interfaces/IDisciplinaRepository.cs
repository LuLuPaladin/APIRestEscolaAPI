using EscolaAPI_FRONT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<List<Disciplina>> ObterDisciplinas();
        Task<bool> CadastrarDisciplina(Disciplina disciplina);
        Task<Disciplina> ObterDisciplinaId(int idDisciplina);
        Task<bool> EditarDisciplina(Disciplina disciplina);
        Task<bool> DeletarDisciplina(int idDisciplina);
    }
}
