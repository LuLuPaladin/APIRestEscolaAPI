
using System.Collections.Generic;

namespace EstudoAPI.Domain.Entities
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public List<Professor> Professores { get; set; }
        public List<Disciplina> Disciplinas { get; set; }


        public Aluno()
        {

        }

        public Aluno(int idAluno, string nome)
        {
            IdAluno = idAluno;
            Nome = nome;
            Professores = new List<Professor>();
            Disciplinas = new List<Disciplina>();
        }
    }
}
