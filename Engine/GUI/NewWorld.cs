using System;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class NewWorld : Form
    {
        private readonly IInit init;

        public NewWorld(IInit init)
        {
            InitializeComponent();
            this.init = init;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            init.GenerateWorld((int)numericSeed.Value, (int)numericSize.Value, progress);
            Close();
        }
    }
}