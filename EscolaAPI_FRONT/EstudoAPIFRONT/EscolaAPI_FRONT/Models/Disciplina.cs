using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.Models
{
    public class Disciplina
    {
        [JsonPropertyName("idDisciplina")]
        public int IdDisciplina { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}
