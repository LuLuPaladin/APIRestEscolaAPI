using EscolaAPI_FRONT.Models;
using System.Collections.Generic;

namespace EscolaAPI_FRONT.Interfaces
{
    public interface IDisciplinaRepository
    {
        List<Disciplina> ObterDisciplinas();
        void CadastrarDisciplina(Disciplina disciplina);
        Disciplina ObterDisciplinaId(int idDisciplina);
        void EditarDisciplina(Disciplina disciplina);
        void DeletarDisciplina(int idDisciplina);
    }
}
