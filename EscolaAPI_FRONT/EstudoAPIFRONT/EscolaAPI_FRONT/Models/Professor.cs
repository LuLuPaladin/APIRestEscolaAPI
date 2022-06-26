using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.Models
{
    public class Professor
    {
        [JsonPropertyName("idProfessor")]
        public int IdProfessor { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("alunos")]
        public List<Aluno> Alunos { get; set; }
        [JsonPropertyName("disciplina")]
        public Disciplina Disciplina { get; set; }
    }
}
