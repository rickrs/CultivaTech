using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    class Estoque
    {
        public int ID { get; set; } // 0
        public string IdProduto { get; set; } // 1
        public string NomeProduto { get; set; } // 2
        public string QtdProduto { get; set; } // 3
        public string Image { get; set; } // 4 (mantendo como string para compatibilidade)

        private SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public List<Estoque> EstoqueListData()
        {
            List<Estoque> listData = new List<Estoque>();

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string selectData = "SELECT * FROM estoque WHERE delete_date IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estoque ed = new Estoque
                            {
                                ID = (int)reader["id"],
                                IdProduto = reader["id_produto"].ToString(),
                                NomeProduto = reader["nome_produto"].ToString(),
                                QtdProduto = reader["qtd_produto"].ToString(),
                                Image = reader["image"] != DBNull.Value ? Convert.ToBase64String((byte[])reader["image"]) : null
                                // Converte a imagem para uma string Base64 se existir, mantendo compatibilidade com o DataGridView
                            };
                            listData.Add(ed);
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
