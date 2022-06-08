using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EstudoAPI.Data.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private string _connectionString;
        private readonly IConfiguration _configuration;

        public DisciplinaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlServer");
        }

        public void CadastrarDisciplina(Disciplina disciplina)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Disciplina(Nome) values(@Nome)", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Nome", disciplina.Nome);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void DeletarDisciplina(int idDisciplina)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM Disciplina WHERE idDisciplina = @idDisciplina", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idDisciplina", idDisciplina);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void EditarDisciplina(Disciplina disciplina)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(@"UPDATE
                                                             Disciplina
                                                            SET
                                                              Nome = @Nome
                                                            WHERE
                                                              IdDisciplina = @idDisciplina", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idDisciplina", disciplina.IdDisciplina);
                sqlCommand.Parameters.AddWithValue("@Nome", disciplina.Nome);
                connection.Open();  
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Disciplina ObterDisciplina(int idDisciplina)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("Select idDisciplina, Nome From Disciplina where idDisciplina = @idDisciplina", connection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@idDisciplina", idDisciplina);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    Disciplina disciplina = null;
                    while (sqlDataReader.Read())
                    {
                        disciplina = new Disciplina
                        {
                            IdDisciplina = int.Parse(sqlDataReader["IdDisciplina"].ToString()),
                            Nome = sqlDataReader["Nome"].ToString()
                        };
                    }

                    connection.Close();
                    return disciplina;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Disciplina> ObterDisciplinas()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Disciplina", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Disciplina> disciplinas = new List<Disciplina>();

                while (sqlDataReader.Read())
                {
                    disciplinas.Add(new Disciplina
                    {
                        IdDisciplina = int.Parse(sqlDataReader["IdDisciplina"].ToString()),
                        Nome = sqlDataReader["Nome"].ToString()
                    });
                }

                sqlConnection.Close();
                return disciplinas;
            }
        }
    }
}

