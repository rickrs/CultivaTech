using CultivaTechNovo;
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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();

            // Inicialização dos componentes
            dashboard1 = new Dashboard();
            gerenciarEstoque1 = new GerenciarEstoque();
            gerenciarFornecedor1 = new GerenciarFornecedor();
            gerenciarUsuario1 = new GerenciarUsuario();
            gerenciarAdmin1 = new GerenciarAdmin();

            // Adicione os controles ao panel3
            panel3.Controls.Add(dashboard1);
            panel3.Controls.Add(gerenciarEstoque1);
            panel3.Controls.Add(gerenciarFornecedor1);
            panel3.Controls.Add(gerenciarUsuario1);
            panel3.Controls.Add(gerenciarAdmin1);


            // Defina o dock para preencher o panel3
            dashboard1.Dock = DockStyle.Fill;
            gerenciarEstoque1.Dock = DockStyle.Fill;
            gerenciarFornecedor1.Dock = DockStyle.Fill;
            gerenciarUsuario1.Dock = DockStyle.Fill;
            gerenciarAdmin1.Dock = DockStyle.Fill;

            // Defina a visibilidade inicial
            dashboard1.Visible = true;
            gerenciarEstoque1.Visible = false;
            gerenciarFornecedor1.Visible = false;
            gerenciarUsuario1.Visible = false;
            gerenciarAdmin1.Visible = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
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

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            gerenciarEstoque1.Visible = false;
            gerenciarFornecedor1.Visible = false;
            gerenciarUsuario1.Visible = false;
            gerenciarAdmin1.Visible = false;

            Dashboard dashForm = dashboard1 as Dashboard;

            if (dashForm != null)
            {
                dashForm.RefreshData();
            }
        }

        private void btnGerEstoque_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            gerenciarEstoque1.Visible = true;
            gerenciarFornecedor1.Visible = false;
            gerenciarUsuario1.Visible = false;
            gerenciarAdmin1.Visible = false;


            GerenciarEstoque gerEstoqueForm = gerenciarEstoque1 as GerenciarEstoque;

            if (gerEstoqueForm != null)
            {
                gerEstoqueForm.RefreshData();
            }
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnGerFornecedores_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            gerenciarEstoque1.Visible = false;
            gerenciarFornecedor1.Visible = true;
            gerenciarUsuario1.Visible = false;
            gerenciarAdmin1.Visible = false;

            GerenciarFornecedor gerFornecedorForm = gerenciarFornecedor1 as GerenciarFornecedor;

            if (gerFornecedorForm != null)
            {
                gerFornecedorForm.RefreshData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastar_Click(object sender, EventArgs e)
        {
            CadastroAdmin cadastroForm = new CadastroAdmin();
            cadastroForm.Show();
            this.Hide();
        }

        private void btnGerenciarUsuario_Click_2(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            gerenciarEstoque1.Visible = false;
            gerenciarFornecedor1.Visible = false;
            gerenciarUsuario1.Visible = true;
            gerenciarAdmin1.Visible = false;

            GerenciarUsuario gerUsuarioForm = gerenciarUsuario1 as GerenciarUsuario;

            if (gerUsuarioForm != null)
            {
                gerUsuarioForm.RefreshData();
            }
        }

        private void btnGerenciarAdmins_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            gerenciarEstoque1.Visible = false;
            gerenciarFornecedor1.Visible = false;
            gerenciarUsuario1.Visible = false;
            gerenciarAdmin1.Visible = true;

            GerenciarAdmin gerAdminForm = gerenciarAdmin1 as GerenciarAdmin;

            if (gerAdminForm != null)
            {
                gerAdminForm.RefreshData();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            CadastroAdmin cadAdminForm = new CadastroAdmin();
            cadAdminForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
