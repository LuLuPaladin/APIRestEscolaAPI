
using EstudoAPI.Domain.DTOs;
using EstudoAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EstudoAPI.Application.Adapters
{
    public static class BoletimEscolarAdapter
    {
        public static BoletimEscolarResponseDTO ToDTO(this BoletimEscolar boletimEscolar)
        {
            return new BoletimEscolarResponseDTO
            (
                boletimEscolar.IdBoletimEscolar,
                boletimEscolar.Aluno.IdAluno,
                boletimEscolar.Aluno.Nome,
                boletimEscolar.Disciplina.Nome,
                boletimEscolar.Professor.IdProfessor,
                boletimEscolar.Professor.Nome,
                boletimEscolar.NotaBoletimEscolar,
                boletimEscolar.DescricaoBoletimEscolar,
                boletimEscolar.DataNota
            );
        }

        public static List<BoletimEscolarResponseDTO> ToDTO(this List<BoletimEscolar> boletimEscolares)
        {
            List<BoletimEscolarResponseDTO> listaBoletimDTO = new List<BoletimEscolarResponseDTO>();
            foreach (var boletimDTO in boletimEscolares)
            {
                listaBoletimDTO.Add(boletimDTO.ToDTO());
            }

            return listaBoletimDTO;
        }

        //EXEMPLO COM LINQ
        //public static List<BoletimEscolarResponseDTO> ToDTOLinq(this List<BoletimEscolar> boletimEscolares)
        //{
        //    return boletimEscolares.Select(x => x.ToDTO()).ToList();
        //}
    }
}
