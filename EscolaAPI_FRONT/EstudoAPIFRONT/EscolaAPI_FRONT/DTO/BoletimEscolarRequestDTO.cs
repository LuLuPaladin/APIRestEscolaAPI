using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.DTO
{
    public  class BoletimEscolarRequestDTO
    {
        // Ao escolher um aluno, ja tem os professores em dropDown associado ao aluno e também o Id do professor
        //achar o professor pelo aluno e achar o IdDisciplina Pelo Professor
        //Nota é um input aberto
        //Descricao tambem
        public BoletimEscolarRequestDTO()
        {
            DataBoletim = DateTime.Now;
        }

        [JsonPropertyName("descricaoBoletim")]
        public string DescricaoBoletim { get; set; }
        [JsonPropertyName("dataBoletim")]
        public DateTime DataBoletim { get; set; }
        [JsonPropertyName("notaBoletim")]
        public decimal NotaBoletim { get; set; }
        [JsonPropertyName("idAluno")]
        public int IdAluno { get; set; }
        [JsonPropertyName("idProfessor")]
        public int IdProfessor { get; set; }
        [JsonPropertyName("idDisciplina")]
        public int IdDisciplina { get; set; }
    }
}
