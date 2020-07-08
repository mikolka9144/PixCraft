using Engine.Resources;
using System;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class Settings_Form : Form
    {

        public Settings_Form()
        {
            InitializeComponent();
            numericGrid.Value = Parameters.border.Up;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var v = (int)numericGrid.Value;
            Parameters.border = (v, v, v, v);
            Close();
        }
    }
}
