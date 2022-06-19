using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.Models
{
    public class Aluno
    {
        [JsonPropertyName("idAluno")]
        public int IdAluno { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        public List<Professor> Professores { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
    }
}
