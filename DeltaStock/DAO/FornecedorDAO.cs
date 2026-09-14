using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DeltaStock.Configs;
using DeltaStock.Models;

namespace DeltaStock.DAO
{
    public class FornecedorDAO
    {
      
        public void Cadastrar(Fornecedor fornecedor)
        {
            using (var conexao = Conexao.GetConexao())
            {
                string sql = @"INSERT INTO fornecedor
                               (nome, cnpj, telefone, email)
                               VALUES
                               (@nome, @cnpj, @telefone, @email)";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", fornecedor.Nome);
                    comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                    comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                    comando.Parameters.AddWithValue("@email", fornecedor.Email);

                    comando.ExecuteNonQuery();
                }
            }
        }

  
        public List<Fornecedor> Listar()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            using (var conexao = Conexao.GetConexao())
            {
                string sql = "SELECT * FROM fornecedor ORDER BY nome";

                using (var comando = new MySqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Fornecedor fornecedor = new Fornecedor
                        {
                            Id = Convert.ToInt32(leitor["id"]),
                            Nome = leitor["nome"].ToString(),
                            Cnpj = leitor["cnpj"].ToString(),
                            Telefone = leitor["telefone"].ToString(),
                            Email = leitor["email"].ToString()
                        };

                        fornecedores.Add(fornecedor);
                    }
                }
            }

            return fornecedores;
        }

    
        public Fornecedor BuscarPorId(int id)
        {
            Fornecedor fornecedor = null;

            using (var conexao = Conexao.GetConexao())
            {
                string sql = "SELECT * FROM fornecedor WHERE id = @id";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    using (var leitor = comando.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            fornecedor = new Fornecedor
                            {
                                Id = Convert.ToInt32(leitor["id"]),
                                Nome = leitor["nome"].ToString(),
                                Cnpj = leitor["cnpj"].ToString(),
                                Telefone = leitor["telefone"].ToString(),
                                Email = leitor["email"].ToString()
                            };
                        }
                    }
                }
            }

            return fornecedor;
        }

        
        public List<Fornecedor> BuscarPorNome(string nome)
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            using (var conexao = Conexao.GetConexao())
            {
                string sql = @"SELECT * FROM fornecedor
                               WHERE nome LIKE @nome
                               ORDER BY nome";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", "%" + nome + "%");

                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Fornecedor fornecedor = new Fornecedor
                            {
                                Id = Convert.ToInt32(leitor["id"]),
                                Nome = leitor["nome"].ToString(),
                                Cnpj = leitor["cnpj"].ToString(),
                                Telefone = leitor["telefone"].ToString(),
                                Email = leitor["email"].ToString()
                            };

                            fornecedores.Add(fornecedor);
                        }
                    }
                }
            }

            return fornecedores;
        }

  
        public Fornecedor BuscarPorCnpj(string cnpj)
        {
            Fornecedor fornecedor = null;

            using (var conexao = Conexao.GetConexao())
            {
                string sql = "SELECT * FROM fornecedor WHERE cnpj = @cnpj";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cnpj", cnpj);

                    using (var leitor = comando.ExecuteReader())
                    {
                        if (leitor.Read())
                        {
                            fornecedor = new Fornecedor
                            {
                                Id = Convert.ToInt32(leitor["id"]),
                                Nome = leitor["nome"].ToString(),
                                Cnpj = leitor["cnpj"].ToString(),
                                Telefone = leitor["telefone"].ToString(),
                                Email = leitor["email"].ToString()
                            };
                        }
                    }
                }
            }

            return fornecedor;
        }

       
        public void Alterar(Fornecedor fornecedor)
        {
            using (var conexao = Conexao.GetConexao())
            {
                string sql = @"UPDATE fornecedor
                               SET nome = @nome,
                                   cnpj = @cnpj,
                                   telefone = @telefone,
                                   email = @email
                               WHERE id = @id";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", fornecedor.Id);
                    comando.Parameters.AddWithValue("@nome", fornecedor.Nome);
                    comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                    comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                    comando.Parameters.AddWithValue("@email", fornecedor.Email);

                    comando.ExecuteNonQuery();
                }
            }
        }

       
        public void Excluir(int id)
        {
            using (var conexao = Conexao.GetConexao())
            {
                string sql = "DELETE FROM fornecedor WHERE id = @id";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }

       
        public bool Existe(int id)
        {
            using (var conexao = Conexao.GetConexao())
            {
                string sql = "SELECT COUNT(*) FROM fornecedor WHERE id = @id";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    int quantidade = Convert.ToInt32(comando.ExecuteScalar());
                    return quantidade > 0;
                }
            }
        }

       
        public bool CnpjExiste(string cnpj)
        {
            using (var conexao = Conexao.GetConexao())
            {
                string sql = "SELECT COUNT(*) FROM fornecedor WHERE cnpj = @cnpj";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@cnpj", cnpj);
                    int quantidade = Convert.ToInt32(comando.ExecuteScalar());
                    return quantidade > 0;
                }
            }
        }

       
        public int Contar()
        {
            using (var conexao = Conexao.GetConexao())
            {
                string sql = "SELECT COUNT(*) FROM fornecedor";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

       
        public void ExcluirTodos()
        {
            using (var conexao = Conexao.GetConexao())
            {
                string sql = "DELETE FROM fornecedor";

                using (var comando = new MySqlCommand(sql, conexao))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}