using Engine.Saves;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class LoadWorldWindow : Form
    {
        private readonly WorldManager worldManager;

        public LoadWorldWindow(SaveManager manager,IInit init)
        {
            worldManager = new WorldManager();
            InitializeComponent();
            Manager = manager;
            Init = init;
            listBox.Items.AddRange(worldManager.ListOfWorlds.ToArray());
        }

        public SaveManager Manager { get; }
        public IInit Init { get; }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItem != null)
            {
                var selection = (WorldEntry)listBox.SelectedItem;
                var data = worldManager.LoadWorld(selection.Name);
                var MemStream = new MemoryStream(Convert.FromBase64String(data));
                Manager.LoadFromStream(MemStream);
            Init.IsWorldGenerated = true;
            Close();
            }
        }
    }
}
