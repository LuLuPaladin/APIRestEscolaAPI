using EstudoAPI.Domain.Entities;
using System.Collections.Generic;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IDisciplinaRepository
    {
        List<Disciplina> ObterDisciplinas();
        void CadastrarDisciplina(Disciplina disciplina);
        Disciplina ObterDisciplina(int idDisciplina);
        void EditarDisciplina(Disciplina disciplina);
        void DeletarDisciplina(int idDisciplina);
    }
}
