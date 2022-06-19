using System;

namespace EscolaAPI_FRONT.Models
{
    public class BoletimEscolar
    {
        public int IdBoletimEscolar { get; set; }
        public string DescricaoBoletimEscolar { get; set; }
        public decimal NotaBoletimEscolar { get; set; }
        public DateTime DataNota { get; set; }
        public Aluno Aluno { get; set; }
        public Professor Professor { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
