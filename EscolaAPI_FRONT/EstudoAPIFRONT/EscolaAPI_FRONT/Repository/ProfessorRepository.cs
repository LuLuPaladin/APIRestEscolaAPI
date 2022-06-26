using EscolaAPI_FRONT.Adapter;
using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly string _urlAPI;

        public ProfessorRepository(IConfiguration configuration)
        {
            _urlAPI = configuration["UrlApi"] + "Professor/";
        }

        public async Task<bool> AssociarAluno(int idAluno, int idProfessor)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = await client.PostAsync(_urlAPI + "AssociarAluno/" + idAluno + "/" + idProfessor, null);

                    if (resposta.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> CadastrarProfessor(ProfessorDTO professorDTO)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonSerializer.Serialize(professorDTO);
                    var conteudo = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = await client.PostAsync(_urlAPI + "CadastrarProfessor", conteudo);

                    if (resposta.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeletarProfessor(int idProfessor)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonSerializer.Serialize(idProfessor);
                    var resposta = await client.DeleteAsync(_urlAPI + "DeletarProfessor/" + idProfessor);

                    if (resposta.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DesassociarAluno(int idAluno, int idProfessor)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = await client.PostAsync(_urlAPI + "DesassociarAluno/" + idAluno + "/" + idProfessor, null);

                    if (resposta.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> EditarProfessor(ProfessorDTO professorDTO)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonSerializer.Serialize(professorDTO);
                    var conteudo = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = await client.PutAsync(_urlAPI + "EditarProfessor/" + professorDTO.IdProfessor, conteudo);

                    if (resposta.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Professor> ObterProfessorId(int idProfessor)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = await client.GetAsync(_urlAPI + "ObterProfessorPorId/" + idProfessor);

                    if (resposta.IsSuccessStatusCode)
                    {
                        var retorno = await resposta.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<Professor>(retorno);
                    }
                    return null;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<ProfessorDTO>> ObterProfessores()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(_urlAPI + "ObterProfessores");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<List<ProfessorDTO>>(content).ToList();
                    }
                    return null;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
