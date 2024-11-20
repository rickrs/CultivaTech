using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CultivaTechNovo
{
    public partial class TelaConfirmacaoPagamento : Form
    {
        public TelaConfirmacaoPagamento(string formaPagamento)
        {
            InitializeComponent();

            labelFormaPagamento.Text = $"Forma de pagamento: {formaPagamento}";
            labelNumeroPedido.Text = $"Nº do pedido: #{new Random().Next(100000, 999999)}";
            labelStatusPagamento.Text = "Status de pagamento: Confirmado.";
            labelTempoEstimado.Text = "Tempo estimado: Hoje entre 12:00 - 13:00";
            labelStatusEntrega.Text = "Status da entrega: Preparando Pedido";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicial menuForm = new TelaInicial();
            menuForm.Show();
            this.Hide();
        }
    }
}
