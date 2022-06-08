using System;

namespace EstudoAPI.Domain.Entities
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

        public BoletimEscolar() 
        { 

        }

        public BoletimEscolar(int idBoletim, string descricaoBoletimEscolar, Aluno aluno, Professor professor, Disciplina disciplina,
            decimal notaBoletimEscolar, DateTime dataNota)
        {
            NotaBoletimEscolar = notaBoletimEscolar;
            DataNota = dataNota;
            IdBoletimEscolar = idBoletim;
            DescricaoBoletimEscolar = descricaoBoletimEscolar;
            Aluno = aluno;
            Professor = professor;
            Disciplina = disciplina;
        }
    }
}
