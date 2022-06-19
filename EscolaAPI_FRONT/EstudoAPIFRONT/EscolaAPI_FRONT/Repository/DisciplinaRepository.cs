using EscolaAPI_FRONT.Interfaces;
using EscolaAPI_FRONT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace EscolaAPI_FRONT.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly string urlAPI = "http://localhost:3163/api/Disciplina/";

        public void CadastrarDisciplina(Disciplina disciplina)
        {
            try
            {
                var disciplinaCriada = new Disciplina();

                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(disciplina);
                    var conteudo = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = client.PostAsync(urlAPI + "CadastrarDisciplina", conteudo);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        disciplinaCriada = JsonConvert.DeserializeObject<Disciplina>(retorno.Result);
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void DeletarDisciplina(int idDisciplina)
        {
            var disciplinaCriada = new Disciplina();
            disciplinaCriada.IdDisciplina = idDisciplina;
            try
            {
                

                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(disciplinaCriada);
                    var conteudo = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = client.PostAsync(urlAPI + "DeletarDisciplina", conteudo);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        disciplinaCriada = JsonConvert.DeserializeObject<Disciplina>(retorno.Result);
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void EditarDisciplina(Disciplina disciplina)
        {
            var disciplinaCriada = new Disciplina();
            try
            {


                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(disciplinaCriada);
                    var conteudo = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = client.PostAsync(urlAPI + "DeletarDisciplina", conteudo);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        disciplinaCriada = JsonConvert.DeserializeObject<Disciplina>(retorno.Result);
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Disciplina ObterDisciplinaId(int idDisciplina)
        {
            var disciplinaCriada = new Disciplina();
            try
            {
                disciplinaCriada.IdDisciplina = idDisciplina;

                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(disciplinaCriada);
                    var conteudo = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = client.PostAsync(urlAPI + "ObterDisciplinaId/", conteudo);

                    resposta.Wait();

                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        disciplinaCriada = JsonConvert.DeserializeObject<Disciplina>(retorno.Result);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return disciplinaCriada;
        }

        public List<Disciplina> ObterDisciplinas()
        {
            var listaDeDisciplinas = new List<Disciplina>();
            try
            {

                using (var client = new HttpClient())
                {
                    var resposta = client.GetStringAsync(urlAPI + "ObterDisciplinas");
                    resposta.Wait();

                    if (resposta.Result != null)
                    {
                        listaDeDisciplinas = JsonConvert.DeserializeObject<Disciplina[]>(resposta.Result).ToList();
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return listaDeDisciplinas;
        }
    }
}
