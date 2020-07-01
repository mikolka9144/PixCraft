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
        public LoadWorldWindow(SaveManager manager)
        {
            InitializeComponent();
            Manager = manager;
        }

        public SaveManager Manager { get; }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItem is null)
            {
                var MemStream = new MemoryStream(Convert.FromBase64String(txtBase.Text));
                Manager.LoadFromStream(MemStream);
            }
        }
    }
}
