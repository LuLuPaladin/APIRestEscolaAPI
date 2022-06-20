using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EscolaAPI_FRONT.Repository
{
    public class BoletimEscolarRepository : IBoletimEscolarRepository
    {
        private readonly string _urlAPI;

        public BoletimEscolarRepository(IConfiguration configuration)
        {
            _urlAPI = configuration["UrlApi"] + "BoletimEscolar/";
        }

        public async Task<bool> AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar)
        {
            using (HttpClient cliente = new HttpClient())
            {
                HttpResponseMessage resposta = await cliente.PostAsync(_urlAPI + "AssociarBoletimEscolar/" +
                    idAluno + "/" + idProfessor + "/" + idDisciplina + "/" + idBoletimEscolar, null);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> CadastrarBoletimEscolar(BoletimEscolar boletimEscolar)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string JsonObjeto = JsonSerializer.Serialize(boletimEscolar);
                StringContent conteudoSerializado = new StringContent(JsonObjeto, Encoding.UTF8, "application/Json");
                HttpResponseMessage resposta = await cliente.PostAsync(_urlAPI + "CadastrarBoletimEscolar", conteudoSerializado);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeletarBoletimEscolar(int idBoletimEscolar)
        {
            using (HttpClient cliente = new HttpClient())
            {
                HttpResponseMessage resposta = await cliente.DeleteAsync(_urlAPI + "DeletarBoletimEscolar/" + idBoletimEscolar);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> EditarBoletimEscolar(BoletimEscolar boletimEscolar)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string jsonObjeto = JsonSerializer.Serialize(boletimEscolar);
                StringContent conteudoSerializado = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                HttpResponseMessage resposta = await cliente.PutAsync(_urlAPI + "EditarBoletimEscolar"
                    + boletimEscolar.IdBoletimEscolar, conteudoSerializado);
                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<BoletimEscolar> ObterBoletimEscolar(int idBoletimEscolar)
        {
            using (HttpClient cliente = new HttpClient())
            {
                BoletimEscolar boletimEscolar = null;
                HttpResponseMessage resposta = await cliente.GetAsync(_urlAPI + "ObterBoletimEscolarId/" + idBoletimEscolar);

                if (resposta.IsSuccessStatusCode)
                {
                    string conteudoDesseralizado = await resposta.Content.ReadAsStringAsync();
                    boletimEscolar = JsonSerializer.Deserialize<BoletimEscolar>(conteudoDesseralizado);
                }
                return boletimEscolar;
            }
        }

        public async Task<List<BoletimEscolar>> ObterBoletinsAluno(int idAluno)
        {
            using (HttpClient cliente = new HttpClient())
            {
                List<BoletimEscolar> boletinsEscolar = null;
                HttpResponseMessage resposta = await cliente.GetAsync(_urlAPI + "ObterBoletinsAssociadoAoAluno/" + idAluno);
                string conteudo = await resposta.Content.ReadAsStringAsync();

                if (resposta.IsSuccessStatusCode)
                {
                    boletinsEscolar = JsonSerializer.Deserialize<List<BoletimEscolar>>(conteudo);
                }
                return boletinsEscolar;
            }
        }
    }
}
