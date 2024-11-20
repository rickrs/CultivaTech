using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    public partial class Login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true");

        public Login()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            Cadastro regForm = new Cadastro();
            regForm.Show();
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = chkMostrarSenha.Checked ? '\0' : '*';
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos em branco", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Formato de e-mail inválido. Por favor, insira um e-mail válido.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    // Gera o hash da senha fornecida pelo usuário
                    byte[] hashedPassword = GenerateHash(txtSenha.Text.Trim());

                    // Verifica se o e-mail pertence a um administrador
                    string adminQuery = "SELECT senha_admin FROM admin WHERE LOWER(email_admin) = @EmailAdmin";
                    using (SqlCommand cmd = new SqlCommand(adminQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@EmailAdmin", txtEmail.Text.Trim().ToLower());

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // Se o resultado não for nulo, o e-mail é de um administrador
                            byte[] storedAdminHash = (byte[])result;
                            if (CompareHashes(storedAdminHash, hashedPassword))
                            {
                                MessageBox.Show("Login de administrador realizado com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MenuAdmin mForm = new MenuAdmin();
                                mForm.Show();
                                this.Hide();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Email ou Senha incorretos.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Verifica se o e-mail pertence a um usuário
                    string userQuery = "SELECT senha_usuario FROM usuario WHERE LOWER(email_usuario) = @EmailUsuario";
                    using (SqlCommand cmd = new SqlCommand(userQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@EmailUsuario", txtEmail.Text.Trim().ToLower());

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // Se o resultado não for nulo, o e-mail é de um usuário
                            byte[] storedUserHash = (byte[])result;
                            if (CompareHashes(storedUserHash, hashedPassword))
                            {
                                MessageBox.Show("Login de usuário realizado com sucesso!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TelaInicial userForm = new TelaInicial();
                                userForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Email ou Senha incorretos.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email ou Senha incorretos.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Método para gerar o hash da senha
        private byte[] GenerateHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        // Método para comparar hashes byte a byte
        private bool CompareHashes(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length) return false;

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i]) return false;
            }

            return true;
        }
        public void InserirContaUsuario()
        {
            string emailUsuario = "usuario@example.com";
            string nomeUsuario = "Usuario";
            byte[] senhaHash = GenerateHash("usuario123");

            using (SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-ROTCHQF4\SQLEXPRESS;Initial Catalog=CultivaTechDB;Integrated Security=true"))
            {
                connect.Open();
                string query = "INSERT INTO usuario (nome_usuario, email_usuario, senha_usuario) VALUES (@Nome, @Email, @SenhaHash)";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Nome", nomeUsuario);
                    cmd.Parameters.AddWithValue("@Email", emailUsuario);
                    cmd.Parameters.AddWithValue("@SenhaHash", senhaHash);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Usuário inserido com sucesso!");
        }
    }
}
