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
    public partial class GerenciarEstoque : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public GerenciarEstoque()
        {
            InitializeComponent();
            displayEstoque();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            displayEstoque();
        }

        public void displayEstoque()
        {
            Estoque ed = new Estoque();
            List<Estoque> listData = ed.EstoqueListData();

            dataGridView1.DataSource = listData;
        }

        public void clearFields()
        {
            txtIdProduto.Text = "";
            txtNomeProduto.Text = "";
            txtQtd.Text = "";
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
            if (txtIdProduto.Text == "" || txtNomeProduto.Text == "" || txtQtd.Text == "" || pictureImagem.Image == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkProductId = "SELECT COUNT(*) FROM estoque WHERE id_produto = @idProduto AND delete_date IS NULL";

                        using (SqlCommand checkProduct = new SqlCommand(checkProductId, connect))
                        {
                            checkProduct.Parameters.AddWithValue("@idProduto", txtIdProduto.Text.Trim());
                            int count = (int)checkProduct.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(txtIdProduto.Text.Trim() + " Já existe um produto com esse ID", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO estoque (id_produto, nome_produto, qtd_produto, image, insert_date) " +
                                    "VALUES(@idProduto, @nomeProduto, @qtdProduto, @image, @insertDate)";

                                byte[] imageBytes = ImageToByteArray(pictureImagem.Image);

                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@idProduto", txtIdProduto.Text.Trim());
                                    cmd.Parameters.AddWithValue("@nomeProduto", txtNomeProduto.Text.Trim());
                                    cmd.Parameters.AddWithValue("@qtdProduto", txtQtd.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", imageBytes);
                                    cmd.Parameters.AddWithValue("@insertDate", today);

                                    cmd.ExecuteNonQuery();
                                    displayEstoque();

                                    MessageBox.Show("Produto adicionado com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearFields();
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
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtIdProduto.Text == "" || txtNomeProduto.Text == "" || txtQtd.Text == "" || pictureImagem.Image == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer atualizar o Id produto: " + txtIdProduto.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string updateData = "UPDATE estoque SET nome_produto = @nomeProduto, qtd_produto = @qtdProduto, update_date = @updateDate, image = @image " +
                            "WHERE id_produto = @idProduto";

                        byte[] imageBytes = ImageToByteArray(pictureImagem.Image);

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@nomeProduto", txtNomeProduto.Text.Trim());
                            cmd.Parameters.AddWithValue("@qtdProduto", txtQtd.Text.Trim());
                            cmd.Parameters.AddWithValue("@updateDate", today);
                            cmd.Parameters.AddWithValue("@idProduto", txtIdProduto.Text.Trim());
                            cmd.Parameters.AddWithValue("@image", imageBytes);

                            cmd.ExecuteNonQuery();
                            displayEstoque();

                            MessageBox.Show("Produto atualizado com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
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
                    MessageBox.Show("Atualização cancelada.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProduto.Text))
            {
                MessageBox.Show("Por favor, insira o ID do produto a ser excluído.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult check = MessageBox.Show("Você tem certeza que quer remover o produto com ID " + txtIdProduto.Text.Trim() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (check == DialogResult.Yes)
                {
                    try
                    {
                        connect.Open();
                        DateTime today = DateTime.Today;

                        string deleteData = "UPDATE estoque SET delete_date = @deleteDate WHERE id_produto = @idProduto";

                        using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                        {
                            cmd.Parameters.AddWithValue("@deleteDate", today);
                            cmd.Parameters.AddWithValue("@idProduto", txtIdProduto.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                displayEstoque();
                                MessageBox.Show("Produto removido com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFields();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum produto encontrado com o ID especificado.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtIdProduto.Text = row.Cells[1].Value.ToString();
                txtNomeProduto.Text = row.Cells[2].Value.ToString();
                txtQtd.Text = row.Cells[3].Value.ToString();

                if (row.Cells[4].Value != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row.Cells[4].Value;
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

        public static implicit operator GerenciarEstoque(GerenciarAdmin v)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
