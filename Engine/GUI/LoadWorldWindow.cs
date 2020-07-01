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
                openFile.ShowDialog();
                if(openFile.FileName != "")Manager.LoadFromStream(File.OpenRead(openFile.FileName));               
            }
        }
    }
}
