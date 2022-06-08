
using System.Collections.Generic;

namespace EstudoAPI.Domain.Entities
{
    public class Professor
    {
        public int IdProfessor { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
        public Disciplina Disciplina { get; set; }

        public Professor()
        {

        }

        public Professor(int idProfessor, string nome, Disciplina disciplina)
        {
            IdProfessor = idProfessor;
            Nome = nome;
            Disciplina = disciplina;
            Alunos = new List<Aluno>();
        }
    }
}
