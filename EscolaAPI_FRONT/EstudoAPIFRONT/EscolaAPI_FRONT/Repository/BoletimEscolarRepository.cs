using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Repository
{
    public class BoletimEscolarRepository : IBoletimEscolarRepository
    {
        public void AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar)
        {
            throw new NotImplementedException();
        }

        public void CadastrarBoletimEscolar(BoletimEscolar boletimEscolar)
        {
            throw new NotImplementedException();
        }

        public void DeletarBoletimEscolar(int idBoletimEscolar)
        {
            throw new NotImplementedException();
        }

        public void EditarBoletimEscolar(int idBoletimEscolar, BoletimEscolar boletimEscolar)
        {
            throw new NotImplementedException();
        }

        public BoletimEscolar ObterBoletimEscolar(int idBoletimEscolar)
        {
            throw new NotImplementedException();
        }

        public List<BoletimEscolar> ObterBoletinsAluno(int idAluno)
        {
            throw new NotImplementedException();
        }
    }
}
