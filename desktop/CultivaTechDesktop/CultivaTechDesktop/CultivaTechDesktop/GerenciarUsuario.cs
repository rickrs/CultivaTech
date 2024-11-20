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
    public partial class GerenciarUsuario : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public GerenciarUsuario()
        {
            InitializeComponent();
            displayUsuario();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayUsuario();
        }

        public void displayUsuario()
        {
            Usuario ud = new Usuario();
            List<Usuario> listData = ud.UsuarioListData();

            dataGridView3.DataSource = listData;
        }

        public void clearFields()
        {
            txtIdUsuario.Text = "";
            txtNomeUsuario.Text = "";
            txtEmailUsuario.Text = "";
            txtEnderecoUsuario.Text = "";
            txtTelefoneUsuario.Text = "";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtIdUsuario.Text == ""
                || txtNomeUsuario.Text == ""
                || txtEnderecoUsuario.Text == ""
                || txtEmailUsuario.Text == ""
                || txtTelefoneUsuario.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer atualizar o " +
                    "Id usuario: " + txtIdUsuario.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE usuario SET nome_usuario = @nomeUsuario, " +
                            "email_usuario = @emailUsuario, endereco_usuario = @enderecoUsuario, " +
                            "telefone_usuario = @telefoneUsuario, update_date = @updateDate " +
                            "WHERE id_usuario = @idUsuario";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@nomeUsuario", txtNomeUsuario.Text.Trim());
                            cmd.Parameters.AddWithValue("@emailUsuario", txtEmailUsuario.Text.Trim());
                            cmd.Parameters.AddWithValue("@enderecoUsuario", txtEnderecoUsuario.Text.Trim());
                            cmd.Parameters.AddWithValue("@telefoneUsuario", txtTelefoneUsuario.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);
                            cmd.Parameters.AddWithValue("@idUsuario", txtIdUsuario.Text.Trim());

                            cmd.ExecuteNonQuery();

                            displayUsuario();

                            MessageBox.Show("Usuario atualizado com sucesso!"
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
            if (string.IsNullOrWhiteSpace(txtIdUsuario.Text))
            {
                MessageBox.Show("Por favor, insira o ID do usuario a ser excluído.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer remover o usuario com ID " +
                    txtIdUsuario.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE usuario SET delete_date = @deleteDate WHERE id_usuario = @idUsuario";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@idUsuario", txtIdUsuario.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                displayUsuario();
                                MessageBox.Show("Usuario removido com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum usuario encontrado com o ID especificado.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                txtIdUsuario.Text = row.Cells[1].Value.ToString();
                txtNomeUsuario.Text = row.Cells[2].Value.ToString();
                txtEmailUsuario.Text = row.Cells[3].Value.ToString();
                txtEnderecoUsuario.Text = row.Cells[4].Value.ToString();
                txtTelefoneUsuario.Text = row.Cells[5].Value.ToString();
            }
        }

        private void txtEmailUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}