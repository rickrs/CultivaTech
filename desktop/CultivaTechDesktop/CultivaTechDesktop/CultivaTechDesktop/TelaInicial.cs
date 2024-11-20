using EmployeeManagementSystem;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
            SetupProductEvents();
        }

        private void SetupProductEvents()
        {
            numericUpDownQuantidadeProduto1.ValueChanged += (s, e) =>
            {
                AtualizarPrecoTotal(5.0m, numericUpDownQuantidadeProduto1, labelTotalProduto1);
            };
            buttonComprarProduto1.Click += (s, e) =>
            {
                AbrirTelaPagamento("Alface Crespa", 5.0m, (int)numericUpDownQuantidadeProduto1.Value);
            };

            numericUpDownQuantidadeProduto2.ValueChanged += (s, e) =>
            {
                AtualizarPrecoTotal(5.0m, numericUpDownQuantidadeProduto2, labelTotalProduto2);
            };
            buttonComprarProduto2.Click += (s, e) =>
            {
                AbrirTelaPagamento("Tomate", 5.0m, (int)numericUpDownQuantidadeProduto2.Value);
            };

            numericUpDownQuantidadeProduto3.ValueChanged += (s, e) =>
            {
                AtualizarPrecoTotal(5.0m, numericUpDownQuantidadeProduto3, labelTotalProduto3);
            };
            buttonComprarProduto3.Click += (s, e) =>
            {
                AbrirTelaPagamento("Cenoura", 5.0m, (int)numericUpDownQuantidadeProduto3.Value);
            };
        }

        private void AbrirTelaPagamento(string produto, decimal preco, int quantidade)
        {
            // Abre a tela de pagamento com as informações do produto
            TelaPagamento telaPagamento = new TelaPagamento(produto, preco, quantidade);
            telaPagamento.Show();
            this.Hide();
        }

        private void AtualizarPrecoTotal(decimal preco, NumericUpDown quantidadeSelector, Label totalLabel)
        {
            decimal total = preco * quantidadeSelector.Value;
            totalLabel.Text = $"Total: R${total:F2}";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Tem certeza de que deseja sair?",
            "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
        }

        private void pictureBoxProduto2_Click(object sender, EventArgs e)
        {

        }

        private void labelPrecoProduto2_Click(object sender, EventArgs e)
        {
                
        }

        private void buttonComprarProduto1_Click(object sender, EventArgs e)
        {

        }

        private void linkQuemSomos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuemSomos quemSomosForm = new QuemSomos();
            quemSomosForm.Show();
            this.Hide();
        }
    }
}
