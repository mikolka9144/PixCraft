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
    public partial class NewWorld : Form
    {
        private readonly IInit init;

        public NewWorld(IInit init)
        {
            InitializeComponent();
            this.init = init;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            init.InitWithParameters((int)numericSeed.Value, (int)numericSize.Value);
            Close();
        }
    }
}
