
namespace EstudoAPI.Domain.Entities
{
    public class Disciplina
    {
        public int IdDisciplina { get; set; }
        public string Nome { get; set; }

        public Disciplina()
        {

        }

        public Disciplina(int idDisciplina, string nome)
        {
            IdDisciplina = idDisciplina;
            Nome = nome;
        }
    }
}
