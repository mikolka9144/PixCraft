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

        public LoadWorldWindow(SaveManager manager,IInit init)
        {
            InitializeComponent();
            Manager = manager;
            Init = init;
        }

        public SaveManager Manager { get; }
        public IInit Init { get; }

        private void button1_Click(object sender, EventArgs e)
        {
          
                Manager.LoadFromFile(txtBase.Text);
            Init.IsWorldGenerated = true;
            Close();
            
        }
    }
}
