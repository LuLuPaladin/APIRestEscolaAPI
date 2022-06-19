using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.Models
{
    public class Professor
    {
        [JsonPropertyName("idProfessor")]
        public int IdProfessor { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
