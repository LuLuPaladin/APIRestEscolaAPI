using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using System.Collections.Generic;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IDisciplinaService
    {   
        bool CadastrarDisciplina(DisciplinaDTO disciplinaDTO);
        Disciplina ObterDisciplina(int idDisciplina);
        bool EditarDisciplina(int idDisciplina, DisciplinaDTO disciplinaDTO);
        bool DeletarDisciplina(int idDisciplina);
        List<Disciplina> ObterDisciplinas();
    }
}
