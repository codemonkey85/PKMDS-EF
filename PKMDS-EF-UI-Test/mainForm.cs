using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKMDS;

namespace PKMDS_EF_UI_Test
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        StorageSystem pc = new StorageSystem();
        private void mainForm_Load(object sender, EventArgs e)
        {
            pc[0][0] = new Pokemon();

            dgData.DataSource = pc[0].Pokemon;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
