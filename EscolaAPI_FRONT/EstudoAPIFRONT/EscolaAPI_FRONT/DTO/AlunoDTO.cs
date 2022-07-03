using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.DTO
{
    public class AlunoDTO
    {
        [JsonPropertyName("idAluno")]
        public int IdAluno { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}
