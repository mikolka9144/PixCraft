using Engine.Saves;
using System;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class Main_Menu : Form
    {
        private readonly IInit init;

        public SaveManager Manager { get; }

        public Main_Menu(IInit init, SaveManager manager)
        {
            InitializeComponent();
            this.init = init;
            Manager = manager;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            new NewWorld(init).ShowDialog();
            if (init.IsWorldGenerated == true) Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsWindow = new Settings_Form();
            settingsWindow.ShowDialog();
        }

        private void btnLoadWorld_Click(object sender, EventArgs e)
        {
            new LoadWorldWindow(Manager, init).ShowDialog();
            if (init.IsWorldGenerated == true) Close();
        }
    }
}