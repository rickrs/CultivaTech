using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    class Fornecedor
    {
        public int ID { get; set; } // 0
        public string IdFornecedor { get; set; } // 1
        public string NomeFornecedor { get; set; } // 2
        public string ContatoFornecedor { get; set; } // 3
        public string EnderecoFornecedor { get; set; } // 4
        public string ProdutoFornecido { get; set; } // 5
        public string Image { get; set; } // 6 (mantendo como string para compatibilidade)

        private SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public List<Fornecedor> FornecedorListData()
        {
            List<Fornecedor> listData = new List<Fornecedor>();

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string selectData = "SELECT * FROM fornecedor WHERE delete_date IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fornecedor fd = new Fornecedor
                            {
                                ID = (int)reader["id"],
                                IdFornecedor = reader["id_fornecedor"].ToString(),
                                NomeFornecedor = reader["nome_fornecedor"].ToString(),
                                ContatoFornecedor = reader["contato_fornecedor"].ToString(),
                                EnderecoFornecedor = reader["endereco_fornecedor"].ToString(),
                                ProdutoFornecido = reader["produto_fornecido"].ToString(),
                                Image = reader["image"] != DBNull.Value ? Convert.ToBase64String((byte[])reader["image"]) : null
                                // Converte a imagem para uma string Base64 se existir, mantendo compatibilidade com o DataGridView
                            };
                            listData.Add(fd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }

            return listData;
        }
    }
}
