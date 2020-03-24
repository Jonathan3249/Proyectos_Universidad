using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2
{
    public partial class Padre : Form
    {
        public Padre()
        {
            InitializeComponent();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados hijo = new Empleados();
            hijo.MdiParent = this;
            hijo.Show();
            
        }

        private void Padre_Load(object sender, EventArgs e)
        {

        }
    }
}
