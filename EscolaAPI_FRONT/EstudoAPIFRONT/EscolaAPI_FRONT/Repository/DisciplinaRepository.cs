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
    public class DisciplinaRepository : IDisciplinaRepository
    {

        private readonly string _urlAPI;

        public DisciplinaRepository(IConfiguration configuration)
        {
            _urlAPI = configuration["UrlAPI"] + "Disciplina/";
        }

        public async Task<bool> CadastrarDisciplina(Disciplina disciplina)
        {
            using (var client = new HttpClient())
            {
                string JsonObjeto = JsonSerializer.Serialize(disciplina);
                StringContent conteudo = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");
                HttpResponseMessage resposta = await client.PostAsync(_urlAPI + "CadastrarDisciplina", conteudo);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeletarDisciplina(int idDisciplina)
        {
            using (var cliente = new HttpClient())
            {
                HttpResponseMessage resposta = await cliente.DeleteAsync(_urlAPI + "DeletarDIsciplina");

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> EditarDisciplina(Disciplina disciplina)
        {
            using (HttpClient cliente = new HttpClient())
            {
                string JsonObjeto = JsonSerializer.Serialize(disciplina);
                StringContent conteudo = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");
                HttpResponseMessage resposta = await cliente.PutAsync(_urlAPI + "EditarDisciplina/" + disciplina.IdDisciplina, conteudo);

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<Disciplina> ObterDisciplinaId(int idDisciplina)
        {
            using (HttpClient cliente = new HttpClient())
            {
                Disciplina disciplina = null;
                HttpResponseMessage resposta = await cliente.GetAsync(_urlAPI + "ObterDisciplina/" + idDisciplina);

                if (resposta.IsSuccessStatusCode)
                {
                    string jsonObjeto = await resposta.Content.ReadAsStringAsync();
                    disciplina = JsonSerializer.Deserialize<Disciplina>(jsonObjeto);
                }
                return disciplina;
            }
        }

        public async Task<List<Disciplina>> ObterDisciplinas()
        {
            using (HttpClient cliente = new HttpClient())
            {
                List<Disciplina> disciplinas = new List<Disciplina>();

                HttpResponseMessage resposta = await cliente.GetAsync(_urlAPI + "ObterDisciplinas");

                if (resposta.IsSuccessStatusCode)
                {
                    string conteudo = await resposta.Content.ReadAsStringAsync();
                    disciplinas = JsonSerializer.Deserialize<List<Disciplina>>(conteudo);
                }
                return disciplinas;
            }
        }
    }
}
