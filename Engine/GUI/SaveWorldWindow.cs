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
            worldManager = new WorldManager();
        }

        public PlayerStatus PlayerStatus { get; }
        public SaveManager Manager { get; }

        private WorldManager worldManager;

        private void txtBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCloud_Click(object sender, EventArgs e)
        {
            var MemStream = new MemoryStream();
            Manager.SaveToStream(MemStream);
            worldManager.(txtName.Text, Convert.ToBase64String(MemStream.ToArray()));
        }
    }
}
