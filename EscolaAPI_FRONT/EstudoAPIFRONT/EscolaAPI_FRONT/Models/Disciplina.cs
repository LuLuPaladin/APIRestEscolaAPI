using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.Models
{
    public class Disciplina
    {
        public int IdDisciplina { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}
