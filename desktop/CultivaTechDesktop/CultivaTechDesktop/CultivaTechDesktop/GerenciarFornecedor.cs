using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CultivaTechNovo
{
    public partial class GerenciarFornecedor : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public GerenciarFornecedor()
        {
            InitializeComponent();
            displayFornecedor();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayFornecedor();
        }

        public void displayFornecedor()
        {
            Fornecedor fd = new Fornecedor();
            List<Fornecedor> listData = fd.FornecedorListData();

            dataGridView2.DataSource = listData;
        }

        public void clearFields()
        {
            txtIdFornecedor.Text = "";
            txtNomeFornecedor.Text = "";
            txtContatoFornecedor.Text = "";
            txtEnderecoFornecedor.Text = "";
            txtProdutoFornecido.Text = "";
            pictureImagem.Image = null;
        }

        // Função para converter imagem em byte array
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtIdFornecedor.Text == ""
                || txtNomeFornecedor.Text == ""
                || txtContatoFornecedor.Text == ""
                || txtEnderecoFornecedor.Text == ""
                || txtProdutoFornecido.Text == ""
                || pictureImagem.Image == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkFornId = "SELECT COUNT(*) FROM fornecedor WHERE id_fornecedor = @idFornecedor AND delete_date IS NULL";

                        using (SqlCommand checkForn = new SqlCommand(checkFornId, connect))
                        {
                            checkForn.Parameters.AddWithValue("@idFornecedor", txtIdFornecedor.Text.Trim());
                            int count = (int)checkForn.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(txtIdFornecedor.Text.Trim() + " Já existe um fornecedor cadastrado com esse ID"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO fornecedor " +
                                    "(id_fornecedor, nome_fornecedor, contato_fornecedor, endereco_fornecedor, produto_fornecido" +
                                    ", image, insert_date) " +
                                    "VALUES(@idFornecedor, @nomeFornecedor, @contatoFornecedor, @enderecoFornecedor, @produtoFornecido" +
                                    ", @image, @insertDate)";

                                byte[] imageBytes = ImageToByteArray(pictureImagem.Image);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@idFornecedor", txtIdFornecedor.Text.Trim());
                                    cmd.Parameters.AddWithValue("@nomeFornecedor", txtNomeFornecedor.Text.Trim());
                                    cmd.Parameters.AddWithValue("@contatoFornecedor", txtContatoFornecedor.Text.Trim());
                                    cmd.Parameters.AddWithValue("@enderecoFornecedor", txtEnderecoFornecedor.Text.Trim());
                                    cmd.Parameters.AddWithValue("@produtoFornecido", txtProdutoFornecido.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", imageBytes);
                                    cmd.Parameters.AddWithValue("@insertDate", today);

                                    cmd.ExecuteNonQuery();

                                    displayFornecedor();

                                    MessageBox.Show("Fornecedor cadastrado com sucesso!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    clearFields();
                                }
                            }
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
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtIdFornecedor.Text == ""
                || txtNomeFornecedor.Text == ""
                || txtContatoFornecedor.Text == ""
                || txtEnderecoFornecedor.Text == ""
                || txtProdutoFornecido.Text == ""
                || pictureImagem.Image == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco"
                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer atualizar o " +
                    "Id forncedor: " + txtIdFornecedor.Text.Trim() + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE fornecedor SET nome_fornecedor = @nomeFornecedor, " +
                            "contato_fornecedor = @contatoFornecedor, endereco_fornecedor = @enderecoFornecedor, " +
                            "produto_fornecido = @produtoFornecido, update_date = @updateDate, image = @image " +
                            "WHERE id_fornecedor = @idFornecedor";

                        byte[] imageBytes = ImageToByteArray(pictureImagem.Image);

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@nomeFornecedor", txtNomeFornecedor.Text.Trim());
                            cmd.Parameters.AddWithValue("@contatoFornecedor", txtContatoFornecedor.Text.Trim());
                            cmd.Parameters.AddWithValue("@enderecoFornecedor", txtEnderecoFornecedor.Text.Trim());
                            cmd.Parameters.AddWithValue("@produtoFornecido", txtProdutoFornecido.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);
                            cmd.Parameters.AddWithValue("@idFornecedor", txtIdFornecedor.Text.Trim());
                            cmd.Parameters.AddWithValue("@image", imageBytes);

                            cmd.ExecuteNonQuery();

                            displayFornecedor();

                            MessageBox.Show("Fornecedor atualizado com sucesso!"
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
            if (string.IsNullOrWhiteSpace(txtIdFornecedor.Text))
            {
                MessageBox.Show("Por favor, insira o ID do fornecedor a ser excluído.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer remover o fornecedor com ID " +
                    txtIdFornecedor.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE fornecedor SET delete_date = @deleteDate WHERE id_fornecedor = @idFornecedor";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@idFornecedor", txtIdFornecedor.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                displayFornecedor();
                                MessageBox.Show("Fornecedor removido com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum fornecedor encontrado com o ID especificado.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureImagem.ImageLocation = dialog.FileName;
                    pictureImagem.Image = Image.FromFile(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtIdFornecedor.Text = row.Cells[1].Value.ToString();
                txtNomeFornecedor.Text = row.Cells[2].Value.ToString();
                txtContatoFornecedor.Text = row.Cells[3].Value.ToString();
                txtEnderecoFornecedor.Text = row.Cells[4].Value.ToString();
                txtProdutoFornecido.Text = row.Cells[5].Value.ToString();

                if (row.Cells[6].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row.Cells[6].Value;
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureImagem.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureImagem.Image = null;
                }
            }
        }
    }
}
