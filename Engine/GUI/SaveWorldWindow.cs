using Engine.Engine;
using Engine.Logic;
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
    public partial class SaveWorldWindow : Form
    {
        public SaveWorldWindow(SaveManager manager)
        {
            InitializeComponent();
            Manager = manager;
        }

        public PlayerStatus PlayerStatus { get; }
        public SaveManager Manager { get; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var MemStream = new MemoryStream();
            Manager.SaveToStream(MemStream);
            txtBase.Text = Convert.ToBase64String(MemStream.ToArray());
        }
    }
}
