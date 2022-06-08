using EstudoAPI.Domain.Entities;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IBoletimEscolarRepository
    {
        
        void CadastrarBoletimEscolar(BoletimEscolar boletimEscolar);
        BoletimEscolar ObterBoletimEscolar(int idBoletimEscolar);
        void EditarBoletimEscolar(int idBoletimEscolar, BoletimEscolar boletimEscolar);
        void DeletarBoletimEscolar(int idBoletimEscolar);
        void AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar);
    }
}
