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
        private readonly Parameters paramters;

        public Main_Menu(IInit init,Parameters paramters)
        {
            InitializeComponent();
            this.init = init;
            this.paramters = paramters;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            new NewWorld(init).ShowDialog();
            Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsWindow = new Settings_Form(paramters);
            settingsWindow.ShowDialog();
        }
    }
}
