using EstudoAPI.Domain.Entities;
using EstudoAPI.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace EstudoAPI.Data.Repositories
{
    public class BoletimEscolarRepository : IBoletimEscolarRepository
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public BoletimEscolarRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlServer");
        }



        public void CadastrarBoletimEscolar(BoletimEscolar boletimEscolar)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO BoletimEscolar(IdDisciplina, IdAluno,
                                                       IdProfessor, DataNota, NotaBoletimEscolar, DescricaoBoletimEscolar) 
                                                            values(@IdDisciplina, @IdAluno, @IdProfessor, 
                                                            @DataNota, @NotaBoletimEscolar, @DescricaoBoletimEscolar )", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@IdBoletimEscolar", boletimEscolar.IdBoletimEscolar);
                sqlCommand.Parameters.AddWithValue("@IdDisciplina", boletimEscolar.Disciplina.IdDisciplina);
                sqlCommand.Parameters.AddWithValue("@IdAluno", boletimEscolar.Aluno.IdAluno);
                sqlCommand.Parameters.AddWithValue("@IdProfessor", boletimEscolar.Professor.IdProfessor);
                sqlCommand.Parameters.AddWithValue("@DataNota", boletimEscolar.DataNota);
                sqlCommand.Parameters.AddWithValue("@NotaBoletimEscolar", boletimEscolar.NotaBoletimEscolar);
                sqlCommand.Parameters.AddWithValue("@DescricaoBoletimEscolar", boletimEscolar.DescricaoBoletimEscolar);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void DeletarBoletimEscolar(int idBoletimEscolar)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("Delete From BoletimEscolar Where IdBoletimEscolar = @idBoletimEscolar", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idBoletimEscolar", idBoletimEscolar);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void EditarBoletimEscolar(int idBoletimEscolar, BoletimEscolar boletimEscolar)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand(@"UPDATE BoletimEscolar
                                                             
                                                            SET
                                                              DescricaoBoletimEscolar = @DescricaoBoletimEscolar,
                                                              DataNota = @DataNota,
                                                              NotaBoletimEscolar = @NotaBoletimEscolar,
                                                              IdDisciplina = @IdDisciplina,
                                                              IdProfessor = @IdProfessor,
                                                              IdAluno = @IdAluno
                                                              

                                                            WHERE
                                                              IdBoletimEscolar = @idBoletimEscolar", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@DescricaoBoletimEscolar", boletimEscolar.DescricaoBoletimEscolar);
                sqlCommand.Parameters.AddWithValue("@idBoletimEscolar", boletimEscolar.IdBoletimEscolar);
                sqlCommand.Parameters.AddWithValue("@IdDisciplina", boletimEscolar.Disciplina.IdDisciplina);
                sqlCommand.Parameters.AddWithValue("@IdProfessor", boletimEscolar.Professor.IdProfessor);
                sqlCommand.Parameters.AddWithValue("@IdAluno", boletimEscolar.Aluno.IdAluno);
                sqlCommand.Parameters.AddWithValue("@DataNota", boletimEscolar.DataNota);
                sqlCommand.Parameters.AddWithValue("@NotaBoletimEscolar", boletimEscolar.NotaBoletimEscolar);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public BoletimEscolar ObterBoletimEscolar(int idBoletimEscolar)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(@"SELECT b.IdBoletimEscolar, b.NotaBoletimEscolar, b.DataNota, b.DescricaoBoletimEscolar, 
                                                             d.IdDisciplina,d.Nome as NomeDisciplina,
                                                             p.IdProfessor, p.Nome as NomeDoProfessor,
                                                             a.IdAluno, a.Nome as NomeDoAluno
                                                             FROM BoletimEscolar b
                                                             INNER JOIN Disciplina d on b.IdDisciplina = d.IdDisciplina
                                                             INNER JOIN Professor p on b.IdProfessor = p.IdProfessor
                                                             INNER JOIN Aluno a on b.IdAluno = a.IdAluno
                                                             WHERE b.IdBoletimEscolar = @idBoletimEscolar", connection);

                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@idBoletimEscolar", idBoletimEscolar);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    BoletimEscolar boletimEscolar = null;
                  
                    while (sqlDataReader.Read())
                    {
                        boletimEscolar = new BoletimEscolar
                        {
                            IdBoletimEscolar = int.Parse(sqlDataReader["IdBoletimEscolar"].ToString()),
                            DescricaoBoletimEscolar = sqlDataReader["DescricaoBoletimEscolar"].ToString(),
                            NotaBoletimEscolar = Convert.ToDecimal(sqlDataReader["NotaBoletimEscolar"]),
                            DataNota = DateTime.Parse(sqlDataReader["DataNota"].ToString()),

                            Aluno = new Aluno
                            {
                                IdAluno = int.Parse(sqlDataReader["IdAluno"].ToString()),
                                Nome = (sqlDataReader["NomeDoAluno"].ToString())
                            },

                            Disciplina = new Disciplina
                            {
                                IdDisciplina = int.Parse(sqlDataReader["IdDisciplina"].ToString()),
                                Nome = (sqlDataReader["NomeDisciplina"].ToString())
                            },
                            Professor = new Professor
                            {
                                IdProfessor = int.Parse(sqlDataReader["IdProfessor"].ToString()),
                                Nome = (sqlDataReader["NomeDoProfessor"].ToString())
                            }
                        };



                    }

                    connection.Close();
                    return boletimEscolar;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void AssociarBoletimEscolar(int idAluno, int idProfessor, int idDisciplina, int idBoletimEscolar)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO BoletimEscolar (IdAluno, IdProfessor, IdDisciplina, IdBoletimEscolar)
                                                        VALUES (@idAluno, @idProfessor, @idDisciplina, @idBoletimEscolar)", connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@idAluno", idAluno);
                sqlCommand.Parameters.AddWithValue("@idProfessor", idProfessor);
                sqlCommand.Parameters.AddWithValue("@idProfessor", idDisciplina);
                sqlCommand.Parameters.AddWithValue("@idBoletimEscolar", idBoletimEscolar);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
