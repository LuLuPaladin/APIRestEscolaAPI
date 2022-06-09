using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using System.Collections.Generic;

namespace EstudoAPI.Domain.Interfaces
{
    public interface IBoletimEscolarService
    {

        bool CadastrarBoletimEscolar(BoletimEscolarDTO boletimEscolarDTO);
        BoletimEscolarResponseDTO ObterBoletimEscolar(int idBoletimEscolar);
        bool EditarBoletimEscolar(int idBoletimEscolar, BoletimEscolarDTO boletimEscolarDTO);
        bool DeletarBoletimEscolar(int idBoletimEscolar);
        bool AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar);
        List<BoletimEscolarResponseDTO> ObterBoletinsAluno(int idAluno);

    }
}
