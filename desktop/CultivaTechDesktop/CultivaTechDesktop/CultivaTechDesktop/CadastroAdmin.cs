﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    public partial class CadastroAdmin : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public CadastroAdmin()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == ""
                || txtEmail.Text == ""
                || txtSenha.Text == ""
                || txtConfSenha.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar se as senhas são iguais
            if (txtSenha.Text != txtConfSenha.Text)
            {
                MessageBox.Show("As senhas não coincidem. Por favor, verifique e tente novamente.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar se a senha atende aos requisitos de complexidade
            if (txtSenha.Text.Length < 8) // exemplo de verificação de comprimento mínimo
            {
                MessageBox.Show("A senha deve ter pelo menos 8 caracteres.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Conexão com o banco de dados para cadastro
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                // Verificar se o e-mail já existe no banco de dados
                string selectEmail = "SELECT COUNT(id_admin) FROM admin WHERE LOWER(email_admin) = @emailAdmin";

                using (SqlCommand checkEmail = new SqlCommand(selectEmail, connect))
                {
                    checkEmail.Parameters.AddWithValue("@emailAdmin", txtEmail.Text.Trim().ToLower()); // Convertendo para minúsculas
                    int count = (int)checkEmail.ExecuteScalar();

                    if (count >= 1)
                    {
                        MessageBox.Show(txtNome.Text.Trim() + ", já existe um usuário cadastrado com esse e-mail.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DateTime today = DateTime.Today;

                        // Criptografar a senha
                        byte[] hashedPassword = GenerateHash(txtSenha.Text.Trim());

                        string insertData = "INSERT INTO admin " +
                            "(nome_admin, email_admin, senha_admin) " +
                            "VALUES(@nomeAdmin, @emailAdmin, @senhaAdmin)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@nomeAdmin", txtNome.Text.Trim());
                            cmd.Parameters.AddWithValue("@emailAdmin", txtEmail.Text.Trim().ToLower()); // Convertendo para minúsculas
                            cmd.Parameters.Add("@senhaAdmin", SqlDbType.VarBinary).Value = hashedPassword; // Senha como byte array

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Cadastro realizado com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Login loginForm = new Login();
                            loginForm.Show();
                            this.Hide();
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
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = chkMostrarSenha.Checked ? '\0' : '*';
            txtConfSenha.PasswordChar = chkMostrarSenha.Checked ? '\0' : '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Método para gerar o hash da senha como array de bytes
        private byte[] GenerateHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MenuAdmin menuAdmForm = new MenuAdmin();
            menuAdmForm.Show();
            this.Hide();
        }
    }
}