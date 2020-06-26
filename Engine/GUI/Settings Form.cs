using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.GUI
{
    public partial class Settings_Form : Form
    {
        private readonly Parameters paramters;

        public Settings_Form(Parameters paramters)
        {
            this.paramters = paramters;
            InitializeComponent();
            numericGrid.Value = paramters.border.Up;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var v = (int)numericGrid.Value;
            paramters.border = (v, v, v, v);
            Close();
        }
    }
}
