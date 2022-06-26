using System;

namespace EstudoAPI.Domain.DTOs
{
    public class BoletimEscolarResponseDTO
    {
        public int IdBoletimEscolar { get; set; }
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; }
        public string NomeDisciplina { get; set; }
        public int IdProfessor { get; set; }
        public string NomeProfessor { get; set; }
        public decimal NotaDoAluno { get; set; }
        public string DescricaoBoletimEscolar { get; set; }
        public string DataNota { get; set; }

        public BoletimEscolarResponseDTO(int idBoletimEscolar, int idAluno, string nomeAluno, string nomeDisciplina, int idProfessor, string nomeProfessor, decimal notaDoAluno, string descricaoBoletimEscolar, DateTime dataNota)
        {
            IdBoletimEscolar = idBoletimEscolar;
            IdAluno = idAluno;
            NomeAluno = nomeAluno;
            NomeDisciplina = nomeDisciplina;
            IdProfessor = idProfessor;
            NomeProfessor = nomeProfessor;
            NotaDoAluno = notaDoAluno;
            DescricaoBoletimEscolar = descricaoBoletimEscolar;
            DataNota = dataNota.ToString("dd/MM/yyyy");
        }
    }
}
