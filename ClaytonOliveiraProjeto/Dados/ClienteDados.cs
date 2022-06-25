using ClaytonOliveiraProjeto.Models;
using System.Data.SqlClient;

using System.Data;

namespace ClaytonOliveiraProjeto.Dados
{
    public class ClienteDados
    {
        public List<Cliente> Listar()
        {
            var oLista = new List<Cliente>();

            var cn = new Conexao();

            using (var conexao = new SqlConnection(cn.getAnotacaoSQL()))
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Cliente()
                        {
                            Id = Convert.ToInt32(dr["IDCliente"]),
                            NomeCliente = dr["nomeCliente"].ToString(),
                            Telefone = dr["telefone"].ToString(),
                            Email = dr["email"].ToString(),
                            Cpf = dr["cpf"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Cliente Buscar(int Id)
        {
            var oCliente = new Cliente();

            var cn = new Conexao();

            using (var conexao = new SqlConnection(cn.getAnotacaoSQL()))
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand("sp_Obter", conexao);
                cmd.Parameters.AddWithValue("IDCliente",Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oCliente.Id = Convert.ToInt32(dr["IDCliente"]);
                        oCliente.NomeCliente = dr["nomeCliente"].ToString();
                        oCliente.Telefone = dr["telefone"].ToString();
                        oCliente.Email = dr["email"].ToString();
                        oCliente.Cpf = dr["cpf"].ToString();
                       
                    }
                }
            }
            return oCliente;
        }

        public bool Salvar(Cliente oCliente)
        {
            bool resposta;

            try
            {
              var cn = new Conexao();

                using (var conexao = new SqlConnection(cn.getAnotacaoSQL()))
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexao);
                    cmd.Parameters.AddWithValue("nomeCliente", oCliente.NomeCliente);
                    cmd.Parameters.AddWithValue("telefone", oCliente.Telefone);
                    cmd.Parameters.AddWithValue("email", oCliente.Email);
                    cmd.Parameters.AddWithValue("cpf", oCliente.Cpf);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resposta = true;

            }
            catch(Exception e)
            {
                string erro = e.Message;
                resposta = false;
            }

            return resposta;
        }

        public bool Editar(Cliente oCliente)
        {
            bool resposta;

            try
            {
                var cn = new Conexao();

                using (var conexao = new SqlConnection(cn.getAnotacaoSQL()))
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexao);
                    cmd.Parameters.AddWithValue("IdCliente", oCliente.Id);
                    cmd.Parameters.AddWithValue("nomeCliente", oCliente.NomeCliente);
                    cmd.Parameters.AddWithValue("telefone", oCliente.Telefone);
                    cmd.Parameters.AddWithValue("email", oCliente.Email);
                    cmd.Parameters.AddWithValue("cpf", oCliente.Cpf);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resposta = true;

            }
            catch (Exception e)
            {
                string erro = e.Message;
                resposta = false;
            }

            return resposta;
        }

        public bool Excluir(int IdCliente)
        {
            bool resposta;

            try
            {
                var cn = new Conexao();

                using (var conexao = new SqlConnection(cn.getAnotacaoSQL()))
                {
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexao);
                    cmd.Parameters.AddWithValue("IdCliente", IdCliente);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resposta = true;

            }
            catch (Exception e)
            {
                string erro = e.Message;
                resposta = false;
            }

            return resposta;

        }

        }
    }
