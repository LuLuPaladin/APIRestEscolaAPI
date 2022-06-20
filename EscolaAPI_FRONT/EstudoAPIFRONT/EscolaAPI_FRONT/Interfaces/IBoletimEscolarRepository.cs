using EscolaAPI_FRONT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Interfaces
{
    public interface IBoletimEscolarRepository
    {
        Task<bool> CadastrarBoletimEscolar(BoletimEscolar boletimEscolar);
        Task<BoletimEscolar> ObterBoletimEscolar(int idBoletimEscolar);
        Task<bool> EditarBoletimEscolar(BoletimEscolar boletimEscolar);
        Task<bool> DeletarBoletimEscolar(int idBoletimEscolar);
        Task<bool> AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar);
        Task<List<BoletimEscolar>> ObterBoletinsAluno(int idAluno);
    }
}
