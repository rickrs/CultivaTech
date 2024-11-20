using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    class Admin
    {
        public int IdAdmin { get; set; } // 0
        public string NomeAdmin { get; set; } // 1
        public string EmailAdmin { get; set; } // 2

        private SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public List<Admin> AdminListData()
        {
            List<Admin> listData = new List<Admin>();

            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                string selectData = "SELECT * FROM admin WHERE delete_date IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Admin ad = new Admin
                            {
                                IdAdmin = (int)reader["id_admin"],
                                NomeAdmin = reader["nome_admin"].ToString(),
                                EmailAdmin = reader["email_admin"].ToString(),
                            };
                            listData.Add(ad);
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
