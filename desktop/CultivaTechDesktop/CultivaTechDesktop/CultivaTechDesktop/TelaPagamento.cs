using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    public partial class TelaPagamento : Form
    {
        public TelaPagamento(string produto, decimal preco, int quantidade)
        {
            InitializeComponent();

            // Inicializa os valores com base no produto selecionado
            labelProduto.Text = $"Produto: {produto}";
            labelPreco.Text = $"Preço Unitário: R${preco:F2}";
            labelQuantidade.Text = $"Quantidade: {quantidade}";
            labelTotal.Text = $"Total: R${preco * quantidade:F2}";

            // Esconde todos os campos de pagamento inicialmente
            HideAllPaymentFields();

            // Adiciona eventos para validar a entrada dos campos
            textBoxCardNumber.KeyPress += TextBoxCardNumber_KeyPress;
            textBoxCardNumber.TextChanged += TextBoxCardNumber_TextChanged;
            textBoxCvv.KeyPress += TextBoxCvv_KeyPress;
            textBoxCvv.TextChanged += TextBoxCvv_TextChanged;
            textBoxExpiryDate.KeyPress += TextBoxExpiryDate_KeyPress;
            textBoxExpiryDate.Leave += TextBoxExpiryDate_Leave;
            textBoxCardHolder.KeyPress += TextBoxCardHolder_KeyPress;
        }

        private void HideAllPaymentFields()
        {
            // Esconde todos os campos de pagamento inicialmente
            labelPixInfo.Visible = false;
            labelCardNumber.Visible = false;
            textBoxCardNumber.Visible = false;
            labelCardHolder.Visible = false;
            textBoxCardHolder.Visible = false;
            labelExpiryDate.Visible = false;
            textBoxExpiryDate.Visible = false;
            labelCvv.Visible = false;
            textBoxCvv.Visible = false;
            panelCard.Visible = false;
            panelPix.Visible = false;
            btnConfirmarCard.Visible = false;
            btnConfirmarPix.Visible = false;
        }

        private void labelProduto_Click(object sender, EventArgs e)
        {
            // Deixe vazio ou adicione lógica extra se necessário
        }

        private void btnPix_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Pagamento via Pix selecionado.", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

            HideAllPaymentFields();
            panelPix.Visible = true; // Exibe o painel Pix
            labelPixInfo.Visible = true; // Exibe as instruções Pix
            labelPixInfo.Text = "Escaneie o QR Code para realizar o pagamento via Pix.";
            btnConfirmarPix.Visible = true;
        }

        private void btnCartao_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Pagamento via Cartão selecionado.", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);

            HideAllPaymentFields();
            // Exibe os campos de entrada de dados para o pagamento via cartão
            panelCard.Visible = true; // Exibe o painel Cartão
            labelCardNumber.Visible = true;
            textBoxCardNumber.Visible = true;
            labelCardHolder.Visible = true;
            textBoxCardHolder.Visible = true;
            labelExpiryDate.Visible = true;
            textBoxExpiryDate.Visible = true;
            labelCvv.Visible = true;
            textBoxCvv.Visible = true;
            btnConfirmarCard.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TelaInicial menuForm = new TelaInicial();
            menuForm.Show();
            this.Hide();
        }

        // Validação para Número do Cartão
        private void TextBoxCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBoxCardNumber_TextChanged(object sender, EventArgs e)
        {
            // Limita o número de caracteres a 16
            if (textBoxCardNumber.Text.Length > 16)
            {
                textBoxCardNumber.Text = textBoxCardNumber.Text.Substring(0, 16);
                textBoxCardNumber.SelectionStart = textBoxCardNumber.Text.Length;
            }
        }

        // Validação para CVV
        private void TextBoxCvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBoxCvv_TextChanged(object sender, EventArgs e)
        {
            // Limita o número de caracteres a 3 ou 4
            if (textBoxCvv.Text.Length > 4)
            {
                textBoxCvv.Text = textBoxCvv.Text.Substring(0, 4);
                textBoxCvv.SelectionStart = textBoxCvv.Text.Length;
            }
        }

        // Validação para Data de Validade (formato MM/AA)
        private void TextBoxExpiryDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos e barra
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '/';
        }

        private void TextBoxExpiryDate_Leave(object sender, EventArgs e)
        {
            // Verifica o formato MM/AA
            if (!Regex.IsMatch(textBoxExpiryDate.Text, @"^(0[1-9]|1[0-2])\/\d{2}$"))
            {
                MessageBox.Show("Data de validade inválida. Use o formato MM/AA.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxExpiryDate.Focus();
            }
        }

        // Validação para Nome do Titular (Apenas letras e espaço)
        private void TextBoxCardHolder_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas letras, espaço e teclas de controle (como backspace)
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnConfirmarCard_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos do cartão estão preenchidos
            if (string.IsNullOrWhiteSpace(textBoxCardNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxCvv.Text) ||
                string.IsNullOrWhiteSpace(textBoxExpiryDate.Text) ||
                string.IsNullOrWhiteSpace(textBoxCardHolder.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos do cartão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Exibe uma mensagem de sucesso e redireciona para a tela de confirmação de pagamento
            MessageBox.Show("Pagamento via Cartão Débito/Crédito confirmado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string formaPagamento = "Cartão de Crédito/Débito";
            TelaConfirmacaoPagamento telaConfirmacao = new TelaConfirmacaoPagamento(formaPagamento);
            telaConfirmacao.Show();
            this.Hide();
        }

        private void btnConfirmarPix_Click(object sender, EventArgs e)
        {
            // Exibe uma mensagem de sucesso para o Pix e redireciona para a tela de confirmação de pagamento
            MessageBox.Show("Pagamento via Pix feito com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string formaPagamento = "PIX";
            TelaConfirmacaoPagamento telaConfirmacao = new TelaConfirmacaoPagamento(formaPagamento);
            telaConfirmacao.Show();
            this.Hide();
        }
    }
}
