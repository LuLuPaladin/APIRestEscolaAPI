using EstudoAPI.Domain.Entities;
using System;

namespace EstudoAPI.Domain.DTOs
{
    public class BoletimEscolarDTO
    {
        public string DescricaoBoletim { get; set; }
        public DateTime DataBoletim { get; set; }
        public decimal NotaBoletim { get; set; }
        public int IdAluno { get; set; }
        public int IdProfessor { get; set; }
        public int IdDisciplina { get; set; }
    }
}
