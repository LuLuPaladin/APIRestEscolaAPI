using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;

namespace EstudoAPI.Application.Adapters
{
    public static class AlunoAdapter
    {
        public static Aluno ToAluno(this AlunoDTO alunoDTO)
        {
            return new Aluno { Nome = alunoDTO.Nome };
        }
    }
}
