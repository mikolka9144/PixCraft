using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class Main_Menu : Form
    {
        private readonly IInit init;

        public Main_Menu(IInit init)
        {
            InitializeComponent();
            this.init = init;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            new NewWorld(init).ShowDialog();
            Close();
        }
    }
}
