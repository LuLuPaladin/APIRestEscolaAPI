using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EstudoAPI.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IConfiguration _configurantion;
        private string _connectionString;


        public AlunoRepository(IConfiguration configuration)
        {
            _configurantion = configuration;
            _connectionString = _configurantion.GetConnectionString("SqlServer");
        }

        public void CadastrarAluno(Aluno aluno)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand("Insert Into Aluno(Nome) values(@Nome)", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Nome", aluno.Nome);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void DeletarAluno(int idAluno)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand("Delete From Aluno where IdAluno = @idAluno", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idAluno", idAluno);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public List<Aluno> ObterAlunoAssociadoAoProfessor(int idProfessor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(@"SELECT
                                                                 a.IdAluno,
                                                                 a.Nome
                                                             FROM Aluno a 
                                                             INNER JOIN
                                                                 Aluno_Professor ap on ap.IdProfessor = @idProfessor", connection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@idProfessor", idProfessor);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Aluno> alunos = new List<Aluno>();

                    while (sqlDataReader.Read())
                    {


                        alunos.Add(new Aluno
                        {
                            IdAluno = int.Parse(sqlDataReader["IdAluno"].ToString()),
                            Nome = sqlDataReader["Nome"].ToString()
                        });
                    }

                    connection.Close();
                    return alunos;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void EditarAluno(int idAluno, Aluno aluno)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand(@"UPDATE
                                                             Aluno
                                                            SET
                                                              Nome = @Nome
                                                            WHERE
                                                              IdAluno = @idAluno", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idAluno", idAluno);
                sqlCommand.Parameters.AddWithValue("@Nome", aluno.Nome);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public Aluno ObterAluno(int idAluno)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand("Select idAluno, Nome From Aluno where idAluno = @idAluno", connection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@idAluno", idAluno);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    Aluno aluno = null;
                    while (sqlDataReader.Read())
                    {
                        aluno = new Aluno
                        {
                            IdAluno = int.Parse(sqlDataReader["IdAluno"].ToString()),
                            Nome = sqlDataReader["Nome"].ToString(),
                            Disciplinas = new List<Disciplina>
                            {
                                new Disciplina{}
                            }
                        };
                    }



                    connection.Close();
                    return aluno;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }


        }

        public void DesassociarProfessor(int idAluno, int idProfessor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommmand = new SqlCommand("DELETE FROM Aluno_Professor " +
                                                        "WHERE  Aluno.IdAluno = @IdAluno, Professor.IdProfessor = @IdProfessor ", connection);
                sqlCommmand.CommandType = CommandType.Text;
                sqlCommmand.Parameters.AddWithValue("@IdAluno", idAluno);
                sqlCommmand.Parameters.AddWithValue("@IdProfessor", idProfessor);
                connection.Open();
                sqlCommmand.ExecuteNonQuery();
                connection.Close();
            }
        }


    }
}

