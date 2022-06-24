using EscolaAPI_FRONT.Adapter;
using EscolaAPI_FRONT.DTO;
using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace EscolaAPI_FRONT.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _urlAPI;

        public AlunoRepository(IConfiguration configuration)
        {
            _urlAPI = configuration["UrlApi"] + "Aluno/";


        }

        public async Task<bool> CadastrarAluno(AlunoDTO alunoDTO)
        {
            using (var client = new HttpClient())
            {
                string jsonObjeto = JsonSerializer.Serialize(alunoDTO);
                StringContent conteudo = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                HttpResponseMessage resposta = await client.PostAsync(_urlAPI + "Cadastrar", conteudo);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeletarAluno(int idAluno)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage resposta = await client.DeleteAsync(_urlAPI + "Deletar/" + idAluno);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }


        public async Task<bool> EditarAluno(int idAluno, AlunoDTO alunoDTO)
        {
            using (var client = new HttpClient())
            {

                StringContent content = new StringContent(JsonSerializer.Serialize(alunoDTO), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(_urlAPI + "Editar/" + idAluno, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<Aluno> ObterAlunoId(int idAluno)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Aluno aluno = null;
                    var resposta = await client.GetAsync(_urlAPI + idAluno);


                    if (resposta.IsSuccessStatusCode)
                    {
                        var test = await resposta.Content.ReadAsStringAsync();
                        aluno = JsonSerializer.Deserialize<Aluno>(test);
                    }
                    return aluno;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        public async Task<List<AlunoDTO>> ObterAlunos()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage resposta = await client.GetAsync(_urlAPI + "ObterAlunos");
                    string conteudo = await resposta.Content.ReadAsStringAsync();

                    List<Aluno> alunos = JsonSerializer.Deserialize<List<Aluno>>(conteudo).ToList();
                    return alunos.ToListAlunosDTO();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
