using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Models;
using Models.Interfaces;

namespace Dados
{
    public class PatrimonioRepository : IPatrimonioRepository
    {
        private readonly string _cnnString = ConfigurationManager.ConnectionStrings["DESAFIO_PARTINER_Conection"].ConnectionString;

        public List<Patrimonio> GetPatrimonios()
        {
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"SELECT Id,Nome,MarcaId,Descricao,NumTombo FROM [dbo].[TbPatrimonio] WITH (NOLOCK)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Patrimonio patrimonio = new Patrimonio()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            MarcaId = Convert.ToInt64(reader["MarcaId"]),
                            Descricao = reader["Descricao"].ToString(),
                            NumTombo = Convert.ToInt64(reader["NumTombo"])
                        };
                        patrimonios.Add(patrimonio);
                    }
                    return patrimonios;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Patrimonio GetPatrimonio(Int64 Id)
        {
            Patrimonio patrimonio = new Patrimonio();
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"SELECT Id,Nome,MarcaId,Descricao,NumTombo FROM [dbo].[TbPatrimonio] WITH (NOLOCK) WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        patrimonio.Id = Convert.ToInt32(reader["Id"]);
                        patrimonio.Nome = reader["Nome"].ToString();
                        patrimonio.MarcaId = Convert.ToInt64(reader["MarcaId"]);
                        patrimonio.Descricao = reader["Descricao"].ToString();
                        patrimonio.NumTombo = Convert.ToInt64(reader["NumTombo"]);
                    }
                    return patrimonio;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Patrimonio GetPatrimonio(string Nome)
        {
            Patrimonio patrimonio = new Patrimonio();
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"SELECT Id,Nome,MarcaId,Descricao,NumTombo FROM [dbo].[TbPatrimonio] WITH (NOLOCK) WHERE Nome = @Nome";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    conn.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        patrimonio.Id = Convert.ToInt32(reader["Id"]);
                        patrimonio.Nome = reader["Nome"].ToString();
                        patrimonio.MarcaId = Convert.ToInt64(reader["MarcaId"]);
                        patrimonio.Descricao = reader["Descricao"].ToString();
                        patrimonio.NumTombo = Convert.ToInt64(reader["NumTombo"]);
                    }
                    return patrimonio;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void PostPatrimonio(Patrimonio patrimonio)
        {
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    Random randNum = new Random();
                    var NumTombo = randNum.Next();

                    string sql = @"INSERT INTO TbPatrimonio (Nome,MarcaId,Descricao,NumTombo) VALUES(@Nome,@MarcaId,@Descricao,@NumTombo)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nome", patrimonio.Nome);
                    cmd.Parameters.AddWithValue("@MarcaId", patrimonio.MarcaId);
                    cmd.Parameters.AddWithValue("@Descricao", patrimonio.Descricao);
                    cmd.Parameters.AddWithValue("@NumTombo", NumTombo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void PutPatrimonio(Patrimonio patrimonio)
        {
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"UPDATE TbPatrimonio SET Nome = @Nome, MarcaId = @MarcaId, Descricao = @Descricao WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", patrimonio.Id);
                    cmd.Parameters.AddWithValue("@Nome", patrimonio.Nome);
                    cmd.Parameters.AddWithValue("@MarcaId", patrimonio.MarcaId);
                    cmd.Parameters.AddWithValue("@Descricao", patrimonio.Descricao);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void DeletePatrimonio(Int64 Id)
        {
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"DELETE FROM TbPatrimonio Where Id = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
