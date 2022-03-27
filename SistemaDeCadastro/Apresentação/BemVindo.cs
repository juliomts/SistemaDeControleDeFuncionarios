using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeCadastro.Apresentação
{
    public partial class BemVindo : Form
    {
        public BemVindo()
        {
            InitializeComponent();
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.Show();
        }
    }
}
