using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Models;
using Models.Interfaces;

namespace Dados
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly string _cnnString = ConfigurationManager.ConnectionStrings["DESAFIO_PARTINER_Conection"].ConnectionString;

        public List<Marca> GetMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"SELECT MarcaId, Nome FROM TbMarca WITH (NOLOCK)";
                    SqlCommand cmdx = new SqlCommand(sql, conn);
                    conn.Open();
                    var reader = cmdx.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Marca marca = new Marca()
                        {
                            MarcaId = Convert.ToInt64(reader["MarcaId"]),
                            Nome = reader["Nome"].ToString()
                        };
                        marcas.Add(marca);
                    }
                    return marcas;
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

        public Marca GetMarca(Int64 Id)
        {
            Marca marca = new Marca();
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"SELECT MarcaId, Nome FROM TbMarca WITH (NOLOCK) Where MarcaId = @Id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        marca.MarcaId = Convert.ToInt64(reader["MarcaId"]);
                        marca.Nome = reader["Nome"].ToString();
                    }
                    return marca;
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

        public Marca GetMarca(string Nome)
        {
            Marca marca = new Marca();
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"SELECT MarcaId, Nome FROM TbMarca WITH (NOLOCK) Where Nome = @Nome";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    conn.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        marca.MarcaId = Convert.ToInt64(reader["MarcaId"]);
                        marca.Nome = reader["Nome"].ToString();
                    }
                    return marca;
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

        public Marca GetPatrimonioByMarca(Int64 Id, string Nome)
        {
            Marca marca = new Marca();
            
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"SELECT M.MarcaId, M.Nome, p.Id, P.Nome as NomePatrimonio, p.MarcaId as MarcaIdPatrimonio, p.Descricao, p.NumTombo FROM [dbo].[TbMarca] M WITH (NOLOCK) ";
                    sql += "INNER JOIN [dbo].[TbPatrimonio] P WITH (NOLOCK) ON M.MarcaId = P.MarcaId WHERE M.MarcaId = @MarcaId and P.Nome = @Nome";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MarcaId", Id);
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    conn.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    var registro = 1;
                    while (reader.Read())
                    {
                        Patrimonio patrimonio = new Patrimonio();

                        if (registro == 1)
                        {
                            marca = new Marca()
                            {
                                MarcaId = Convert.ToInt64(reader["MarcaId"]),
                                Nome = reader["Nome"].ToString()
                            };
                            registro++;
                        }

                        patrimonio.Id = Convert.ToInt32(reader["Id"]);
                        patrimonio.MarcaId = Convert.ToInt64(reader["MarcaIdPatrimonio"]);
                        patrimonio.Nome = reader["NomePatrimonio"].ToString();
                        patrimonio.Descricao = reader["Descricao"].ToString();
                        patrimonio.NumTombo = Convert.ToInt32(reader["NumTombo"]);

                        marca.patrimonios.Add(patrimonio);
                    }
                    return marca;
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

        public void PostMarca(Marca marca)
        {
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"INSERT INTO TbMarca (Nome) VALUES(@Nome)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nome", marca.Nome);
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

        public void PutMarca(Marca marca)
        {
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"UPDATE TbMarca SET Nome = @Nome WHERE MarcaId = @MarcaId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nome", marca.Nome);
                    cmd.Parameters.AddWithValue("@MarcaId", marca.MarcaId);
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

        public void DeleteMarca(Int64 Id)
        {
            using (var conn = new SqlConnection(_cnnString))
            {
                try
                {
                    string sql = @"DELETE FROM TbMarca Where MarcaId = @MarcaId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MarcaId", Id);
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
