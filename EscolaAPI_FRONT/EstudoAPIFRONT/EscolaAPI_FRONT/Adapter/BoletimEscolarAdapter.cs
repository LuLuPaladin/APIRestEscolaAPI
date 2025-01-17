﻿using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscolaAPI_FRONT.Adapter
{
    public static class BoletimEscolarAdapter
    {
        public static BoletimEscolarDTO ToBoletimEscolarResponseDTOs(this BoletimEscolar boletimEscolar)
        {
            return new BoletimEscolarDTO
            {
                NomeAluno = boletimEscolar.NomeAluno,
                DataNota = boletimEscolar.Data,
                DescricaoBoletim = boletimEscolar.Descricao,
                IdBoletimEscolar = boletimEscolar.IdBoletimEscolar,
                NotaBoletimEscolar = boletimEscolar.NotaDoAluno,
                NomeDisciplina = boletimEscolar.NomeDisciplina,
                NomeProfessor = boletimEscolar.NomeProfessor,
                IdAluno = boletimEscolar.IdAluno

            };
        }

        public static BoletimEscolar ToBoletimEscolarResponseDTO(this BoletimEscolarRequestDTO boletimEscolarRequestDTO)
        {
            return new BoletimEscolar
            {
                NotaDoAluno = boletimEscolarRequestDTO.NotaBoletim,
                IdAluno = boletimEscolarRequestDTO.IdAluno,
                IdProfessor = boletimEscolarRequestDTO.IdProfessor,
                IdDisciplina = boletimEscolarRequestDTO.IdDisciplina,
                Descricao = boletimEscolarRequestDTO.DescricaoBoletim

            };
        }

        public static BoletimEscolarRequestDTO ToBoletimEscolarRequestDTO(this BoletimEscolar boletimEscolar)
        {
            return new BoletimEscolarRequestDTO
            {
                NotaBoletim = boletimEscolar.NotaDoAluno,
                DescricaoBoletim = boletimEscolar.Descricao,
                IdProfessor = boletimEscolar.IdProfessor,
                IdDisciplina = boletimEscolar.IdDisciplina,
                IdAluno = boletimEscolar.IdAluno
            };
        }

        //Código Antigo sem Lambda
        //public static List<BoletimEscolarDTO> ToProfessoresListDTO(this List<BoletimEscolar> boletinsEscolares)
        //{
        //    List<BoletimEscolarDTO> boletinsEscolaresDTO = new List<BoletimEscolarDTO>();

        //    foreach (var boletimEscolar in boletinsEscolares)
        //    {
        //        boletinsEscolaresDTO.Add(boletimEscolar.ToBoletimEscolarResponseDTO());
        //    }
        //    return boletinsEscolaresDTO;
        //}

        // Refatorando Código com Expressão Lambda
        //public static List<BoletimEscolarDTO> ToProfessoresListDTO(this List<BoletimEscolar> boletinsEscolares)
        //{
        //   IEnumerable<BoletimEscolarDTO> BDTO =  boletinsEscolares.Select(b => b.ToBoletimEscolarResponseDTO());
        //   List<BoletimEscolarDTO> listBoletimEscolarDTO = BDTO.ToList();
        //    return listBoletimEscolarDTO;
        //}

        public static List<BoletimEscolarDTO> ToBoletinsEscolaresDTOs(this List<BoletimEscolar> boletinsEscolares)
        {
            return boletinsEscolares.Select(b => b.ToBoletimEscolarResponseDTOs()).ToList();
        }
    }
}
