using Engine.Logic;
using Engine.Saves;
using System;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class PauseMenu : System.Windows.Forms.Form
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            new SaveWorldWindow(Manager).ShowDialog();
        }
    }
}