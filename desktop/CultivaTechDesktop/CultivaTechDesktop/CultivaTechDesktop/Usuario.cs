using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    class Usuario
    {
        public int IdUsuario { get; set; } // 0
        public string NomeUsuario { get; set; } // 1
        public string EmailUsuario { get; set; } // 2
        public string EnderecoUsuario { get; set; } // 3
        public string TelefoneUsuario { get; set; } // 4

        private SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public List<Usuario> UsuarioListData()
        {
            List<Usuario> listData = new List<Usuario>();

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string selectData = "SELECT * FROM usuario WHERE delete_date IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario ud = new Usuario
                            {
                                IdUsuario = (int)reader["id_usuario"],
                                NomeUsuario = reader["nome_usuario"].ToString(),
                                EmailUsuario = reader["email_usuario"].ToString(),
                                EnderecoUsuario = reader["endereco_usuario"].ToString(),
                                TelefoneUsuario = reader["telefone_usuario"].ToString(),
                            };
                            listData.Add(ud);
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
