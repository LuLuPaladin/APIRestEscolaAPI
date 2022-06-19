using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.DTO
{
    public class ProfessorDTO
    {
        [JsonPropertyName("idProfessor")]
        public int IdProfessor { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("idDisciplina")]
        public int IdDisciplina { get; set; }
        [JsonPropertyName("disciplina")]
        public string NomeDisciplina { get; set; }
    }
}
