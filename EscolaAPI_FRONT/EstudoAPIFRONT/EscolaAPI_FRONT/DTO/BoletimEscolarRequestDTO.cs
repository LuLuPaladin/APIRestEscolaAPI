using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.DTO
{
    public  class BoletimEscolarRequestDTO
    {
        // Ao escolher um aluno, ja tem os professores em dropDown associado ao aluno e também o Id do professor
        //achar o professor pelo aluno e achar o IdDisciplina Pelo Professor
        //Nota é um input aberto
        //Descricao tambem
        public BoletimEscolarRequestDTO()
        {
            DataNota = DateTime.Now;
        }

        public decimal Nota { get; set; }
        public int IdAluno { get; set; }
        public int IdProfessor { get; set; }
        public int IdDisciplina { get; set; }
        public string Descricao { get; set; }
        // nao colocar na tela
        public DateTime DataNota { get; set; }

        
    }
}
