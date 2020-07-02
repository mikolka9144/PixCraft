using Engine.Logic;
using Engine.Saves;
using System;
using System.IO;
using System.Windows;

namespace Engine.GUI
{
    public partial class SaveWorldWindow : System.Windows.Forms.Form
    {
        public SaveWorldWindow(SaveManager manager)
        {
            InitializeComponent();
            Manager = manager;
        }

        public PlayerStatus PlayerStatus { get; }
        public SaveManager Manager { get; }

        private void txtBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCloud_Click(object sender, EventArgs e)
        {
            Manager.SaveToFile(txtName.Text);
        }
    }
}
