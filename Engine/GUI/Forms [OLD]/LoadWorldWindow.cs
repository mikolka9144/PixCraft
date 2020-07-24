using Engine.Saves;
using System;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class LoadWorldWindow : System.Windows.Forms.Form
    {
        public LoadWorldWindow(SaveManager manager)
        {
            InitializeComponent();
            Manager = manager;
        }

        public SaveManager Manager { get; }

        private void button1_Click(object sender, EventArgs e)
        {
            var save = Manager.LoadFromFile(txtBase.Text);
            Manager.LoadSave(save);
            Close();
        }
    }
}