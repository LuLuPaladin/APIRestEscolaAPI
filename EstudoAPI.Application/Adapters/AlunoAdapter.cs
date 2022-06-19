using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;

namespace EstudoAPI.Application.Adapters
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
    }
}
