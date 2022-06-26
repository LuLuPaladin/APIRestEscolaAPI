using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.DTO
{
    public class AlunoDTO
    {
        [JsonPropertyName("idProfessor")]
        public int IdAluno { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}
