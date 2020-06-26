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
    public partial class PauseMenu : Form
    {
        public PauseMenu()
        {
            InitializeComponent();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
