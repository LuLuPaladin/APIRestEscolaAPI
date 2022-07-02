using System;
using System.Text.Json.Serialization;

namespace EscolaAPI_FRONT.Models
{
    public class BoletimEscolar
    {
        [JsonPropertyName("idBoletimEscolar")]
        public int IdBoletimEscolar { get; set; }
        [JsonPropertyName("idAluno")]
        public int IdAluno { get; set; }
        [JsonPropertyName("nomeAluno")]
        public string NomeAluno { get; set; }
        [JsonPropertyName("nomeDisciplina")]
        public string NomeDisciplina { get; set; }
        [JsonPropertyName("idDisciplina")]
        public int IdDisciplina { get; set; }
        [JsonPropertyName("idProfessor")]
        public int IdProfessor { get; set; }
        [JsonPropertyName("nomeProfessor")]
        public string NomeProfessor { get; set; }
        [JsonPropertyName("notaDoAluno")]
        public decimal NotaDoAluno { get; set; }
        [JsonPropertyName("descricaoBoletimEscolar")]
        public string Descricao { get; set; }
        [JsonPropertyName("dataNota")]
        public string Data { get; set; }
    }
}
