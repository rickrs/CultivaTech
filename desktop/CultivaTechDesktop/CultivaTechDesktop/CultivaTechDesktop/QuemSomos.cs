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

namespace EmployeeManagementSystem
{
    public partial class QuemSomos : Form
    {
        public QuemSomos()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicial menuForm = new TelaInicial();
            menuForm.Show();
            this.Hide();
        }
    }
}
