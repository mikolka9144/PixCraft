using PixBlocks.PythonIron.Tools.Game;
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
        private readonly Parameters paramters;

        public PauseMenu(Parameters paramters)
        {
            InitializeComponent();
            this.paramters = paramters;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsWindow = new Settings_Form(paramters);
            settingsWindow.ShowDialog();
        }
    }
}
