using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EstudoAPI.Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IConfiguration _configurantion;
        private string _connectionString;

        public ProfessorRepository(IConfiguration configurantion)
        {
            _configurantion = configurantion;
            _connectionString = _configurantion.GetConnectionString("SqlServer");
        }

        public void CadastrarProfessor(Professor professor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Professor(Nome, IdDisciplina) values(@Nome, @IdDisciplina)", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Nome", professor.Nome);
                sqlCommand.Parameters.AddWithValue("@IdDisciplina", professor.Disciplina.IdDisciplina);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }

        }

        public List<Professor> ObterProfessoresAssociadosAoAluno(int idAluno)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(@"SELECT
                                                                 p.IdProfessor,
                                                                 p.Nome
                                                             FROM Professor p 
                                                             INNER JOIN
                                                                 Aluno_Professor ap on ap.IdAluno = @idAluno;", connection);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@idAluno", idAluno);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    List<Professor> professores = new List<Professor>();

                    while (sqlDataReader.Read())
                    {


                        professores.Add(new Professor
                        {
                            IdProfessor = int.Parse(sqlDataReader["IdProfessor"].ToString()),
                            Nome = sqlDataReader["Nome"].ToString()
                        });
                    }

                    connection.Close();
                    return professores;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void DeletarProfessor(int idProfessor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Delete FROM Professor where IdProfessor = @idProfessor", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idProfessor", idProfessor);
                
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditarProfessor(int idProfessor, Professor professor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand(@"UPDATE
                                                             Professor
                                                            SET
                                                              Nome = @Nome,
                                                              IdDisciplina = @IdDisciplina
                                                            WHERE
                                                              IdProfessor = @idProfessor", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idProfessor", idProfessor);
                sqlCommand.Parameters.AddWithValue("@Nome", professor.Nome);
                sqlCommand.Parameters.AddWithValue("@IdDisciplina", professor.Disciplina.IdDisciplina);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public Professor ObterProfessor(int idProfessor)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(@"SELECT p.IdProfessor, p.Nome as NomeProfessor, p.IdDisciplina, d.Nome as NomeDisciplina
                                                         FROM Professor p
                                                         INNER JOIN Disciplina d
                                                         ON p.IdDisciplina = d.IdDisciplina
                                                         WHERE 
                                                            p.IdProfessor = @idProfessor", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idProfessor", idProfessor);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Professor professor = null;


                while (sqlDataReader.Read())
                {
                    professor = new Professor
                    {
                        IdProfessor = Convert.ToInt32(sqlDataReader["IdProfessor"]),
                        Nome = sqlDataReader["NomeProfessor"].ToString(),
                        Disciplina = new Disciplina
                        {
                            IdDisciplina = Convert.ToInt32(sqlDataReader["IdDisciplina"]),
                            Nome = sqlDataReader["NomeDisciplina"].ToString()
                        }
                    };
                }
                sqlConnection.Close();
                return professor;
            }
        }



        public void AssociarAluno(int idAluno, int idProfessor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Alunos_Professores (IdAluno, IdProfessor)" +
                                                       " VALUES (@idAluno, @idProfessor)", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idAluno", idAluno);
                sqlCommand.Parameters.AddWithValue("@idProfessor", idProfessor);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DesassociarAluno(int idAluno, int idProfessor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommmand = new SqlCommand("DELETE FROM Alunos_Professores " +
                                                        "WHERE  IdAluno = @idAluno AND IdProfessor = @IdProfessor ", connection);
                sqlCommmand.CommandType = CommandType.Text;
                sqlCommmand.Parameters.AddWithValue("@idAluno", idAluno);
                sqlCommmand.Parameters.AddWithValue("@IdProfessor", idProfessor);
                connection.Open();
                sqlCommmand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Professor> ObterProfessores()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(@"SELECT p.IdProfessor, p.Nome as NomeProfessor, p.IdDisciplina, d.Nome as NomeDisciplina
                                                         FROM Professor p
                                                         INNER JOIN Disciplina d
                                                         ON p.IdDisciplina = d.IdDisciplina", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Professor> professor = new List<Professor>();


                while (sqlDataReader.Read())
                {
                    professor.Add(new Professor
                    {
                        IdProfessor = Convert.ToInt32(sqlDataReader["IdProfessor"]),
                        Nome = sqlDataReader["NomeProfessor"].ToString(),
                        Disciplina = new Disciplina
                        {
                            IdDisciplina = Convert.ToInt32(sqlDataReader["IdDisciplina"]),
                            Nome = sqlDataReader["NomeDisciplina"].ToString()
                        }
                    });
                }
                sqlConnection.Close();
                return professor;
            }
        }
    }
}
