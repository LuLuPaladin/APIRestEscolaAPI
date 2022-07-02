using System;

namespace EscolaAPI_FRONT.DTO
{
    public class BoletimEscolarDTO
    {
        public int IdBoletimEscolar { get; set; }
        public string DescricaoBoletim { get; set; }
        public decimal NotaBoletimEscolar { get; set; }
        public string DataNota { get; set; }
        public string NomeAluno { get; set; }
        public int IdAluno { get; set; }
        public string NomeProfessor { get; set; }
        public string NomeDisciplina { get; set; }
    }
}
