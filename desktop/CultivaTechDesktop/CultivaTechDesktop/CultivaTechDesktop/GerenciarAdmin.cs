using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    public partial class GerenciarAdmin : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public GerenciarAdmin()
        {
            InitializeComponent();
            displayAdmin();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayAdmin();
        }

        public void displayAdmin()
        {
            Admin ad = new Admin();
            List<Admin> listData = ad.AdminListData();

            dataGridView4.DataSource = listData;
        }

        public void clearFields()
        {
            txtIdAdmin.Text = "";
            txtNomeAdmin.Text = "";
        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                txtIdAdmin.Text = row.Cells[1].Value.ToString();
                txtNomeAdmin.Text = row.Cells[2].Value.ToString();
                txtEmailAdmin.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtIdAdmin.Text == ""
                || txtNomeAdmin.Text == ""
                || txtEmailAdmin.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer atualizar o " +
                    "Id admin: " + txtIdAdmin.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE admin SET nome_admin = @nomeAdmin, email_admin = @emailAdmin, " +
                            "update_date = @updateDate " +
                        "WHERE id_admin = @idAdmin";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@idAdmin", txtIdAdmin.Text.Trim());
                            cmd.Parameters.AddWithValue("@nomeAdmin", txtNomeAdmin.Text.Trim());
                            cmd.Parameters.AddWithValue("@emailAdmin", txtEmailAdmin.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);


                            cmd.ExecuteNonQuery();

                            displayAdmin();

                            MessageBox.Show("Admin atualizado com sucesso!"
                                , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex
                        , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Atualização cancelada."
                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdAdmin.Text))
            {
                MessageBox.Show("Por favor, insira o ID do admin a ser excluído.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer remover o admin com ID " +
                    txtIdAdmin.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE admin SET delete_date = @deleteDate WHERE id_admin = @idAdmin";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@idAdmin", txtIdAdmin.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                displayAdmin();
                                MessageBox.Show("Admin removido com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum admin encontrado com o ID especificado.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
                else
                {
                    MessageBox.Show("Exclusão cancelada.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtEmailAdmin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
