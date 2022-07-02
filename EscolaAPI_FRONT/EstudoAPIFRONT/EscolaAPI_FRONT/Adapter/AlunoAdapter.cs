using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Models;
using System.Collections.Generic;

namespace EscolaAPI_FRONT.Adapter
{
    public static class AlunoAdapter
    {
        public static Aluno ToAluno(this AlunoDTO alunoDTO)
        {
            return new Aluno { Nome = alunoDTO.Nome, IdAluno = alunoDTO.IdAluno };
        }
        public static AlunoDTO ToAlunoDTO(this Aluno aluno)
        {
            return new AlunoDTO { Nome = aluno.Nome, IdAluno = aluno.IdAluno }; 
        }
        /// <summary>
        /// Este método converte uma lista de Aluno para uma Lista de AlunoDTO
        /// </summary>
        /// <param name="alunos">Lista De Alunos</param>
        /// <returns>Lista De AlunosDTO</returns>
        public static List<AlunoDTO> ToListAlunosDTO(this List<Aluno> alunos)
        {
            List<AlunoDTO> alunosDTO = new List<AlunoDTO>();

            foreach (Aluno aluno in alunos)
            {
               alunosDTO.Add(aluno.ToAlunoDTO());
            }
            return alunosDTO;
        }


    }
}
