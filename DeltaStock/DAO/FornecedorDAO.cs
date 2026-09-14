using DeltaStock.Configs;
using DeltaStock.Models;
using MySql.Data.MySqlClient;

namespace DeltaStock.DAO
{
    public class FornecedorDAO
    {
        // ==============================
        // CADASTRAR FORNECEDOR
        // ==============================
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


        // ==============================
        // LISTAR TODOS OS FORNECEDORES
        // ==============================
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
                        Fornecedor fornecedor = new Fornecedor();

                        fornecedor.Id = Convert.ToInt32(leitor["id"]);
                        fornecedor.Nome = leitor["nome"].ToString();
                        fornecedor.Cnpj = leitor["cnpj"].ToString();
                        fornecedor.Telefone = leitor["telefone"].ToString();
                        fornecedor.Email = leitor["email"].ToString();

                        fornecedores.Add(fornecedor);
                    }
                }
            }

            return fornecedores;
        }


        // ==============================
        // BUSCAR FORNECEDOR PELO ID
        // ==============================
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
                            fornecedor = new Fornecedor();

                            fornecedor.Id = Convert.ToInt32(leitor["id"]);
                            fornecedor.Nome = leitor["nome"].ToString();
                            fornecedor.Cnpj = leitor["cnpj"].ToString();
                            fornecedor.Telefone = leitor["telefone"].ToString();
                            fornecedor.Email = leitor["email"].ToString();
                        }
                    }
                }
            }

            return fornecedor;
        }


        // ==============================
        // BUSCAR PELO NOME
        // ==============================
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
                            Fornecedor fornecedor = new Fornecedor();

                            fornecedor.Id = Convert.ToInt32(leitor["id"]);
                            fornecedor.Nome = leitor["nome"].ToString();
                            fornecedor.Cnpj = leitor["cnpj"].ToString();
                            fornecedor.Telefone = leitor["telefone"].ToString();
                            fornecedor.Email = leitor["email"].ToString();

                            fornecedores.Add(fornecedor);
                        }
                    }
                }
            }

            return fornecedores;
        }


        // ==============================
        // BUSCAR PELO CNPJ
        // ==============================
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
                            fornecedor = new Fornecedor();

                            fornecedor.Id = Convert.ToInt32(leitor["id"]);
                            fornecedor.Nome = leitor["nome"].ToString();
                            fornecedor.Cnpj = leitor["cnpj"].ToString();
                            fornecedor.Telefone = leitor["telefone"].ToString();
                            fornecedor.Email = leitor["email"].ToString();
                        }
                    }
                }
            }

            return fornecedor;
        }


        // ==============================
        // ALTERAR FORNECEDOR
        // ==============================
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


        // ==============================
        // EXCLUIR FORNECEDOR
        // ==============================
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


        // ==============================
        // VERIFICAR SE EXISTE
        // ==============================
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


        // ==============================
        // VERIFICAR CNPJ
        // ==============================
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


        // ==============================
        // CONTAR FORNECEDORES
        // ==============================
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


        // ==============================
        // EXCLUIR TODOS
        // ==============================
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