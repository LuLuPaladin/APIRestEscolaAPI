using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IBoletimEscolarService
    {

        bool CadastrarBoletimEscolar(BoletimEscolarDTO boletimEscolarDTO);
        BoletimEscolar ObterBoletimEscolar(int idBoletimEscolar);
        bool EditarBoletimEscolar(int idBoletimEscolar, BoletimEscolarDTO boletimEscolarDTO);
        bool DeletarBoletimEscolar(int idBoletimEscolar);
        bool AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar);

    }
}
