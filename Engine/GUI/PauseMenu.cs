using Engine.Engine;
using Engine.Logic;
using Engine.Saves;
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
        public SaveManager Manager { get; }
        public PlayerStatus Status { get; }

        public PauseMenu(SaveManager manager)
        {
            InitializeComponent();
            Manager = manager;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsWindow = new Settings_Form();
            settingsWindow.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            new SaveWorldWindow(Manager).ShowDialog();
        }
    }
}
