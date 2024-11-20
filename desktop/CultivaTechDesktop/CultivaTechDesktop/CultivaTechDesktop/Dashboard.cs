using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CultivaTechNovo
{
    public partial class Dashboard : UserControl
    {
        private readonly string connectionString = @"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true";

        public Dashboard()
        {
            InitializeComponent();
            displayEstoque();
            displayFornecedor();
            displayUsuario();
            displayAdmin();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayEstoque();
            displayFornecedor();
            displayUsuario();
            displayAdmin();
        }

        public void displayEstoque()
        {
            string selectData = "SELECT COUNT(id_produto) FROM estoque WHERE delete_date IS NULL";

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_Estoque.Text = count.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayFornecedor()
        {
            string selectData = "SELECT COUNT(id_fornecedor) FROM fornecedor WHERE delete_date IS NULL";

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_Fornecedor.Text = count.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayUsuario()
        {
            string selectData = "SELECT COUNT(id_usuario) FROM usuario WHERE delete_date IS NULL";

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_Usuario.Text = count.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayAdmin()
        {
            string selectData = "SELECT COUNT(id_admin) FROM admin WHERE delete_date IS NULL";

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_Admins.Text = count.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dashboard_Estoque_Click(object sender, EventArgs e)
        {
        }

        private void dashboard_Fornecedor_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Admins_Click(object sender, EventArgs e)
        {

        }
    }
}
