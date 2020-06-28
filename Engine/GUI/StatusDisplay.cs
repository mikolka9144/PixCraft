using Engine.Logic;
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
    internal partial class StatusDisplay : Form,IStatusDisplayer
    {
        public StatusDisplay(Parameters parameters)
        {
            InitializeComponent();
            Parameters = parameters;
        }

        public int SelectedIndex { get; set; }
        public Parameters Parameters { get; }

        public void Present(int life, List<Item> currentItems)
        {
            SelectedIndex = -1;
            Inventory.Items.Clear();
            LifeBar.Value = life / Parameters.BaseHealth;
            for (int i = 0; i < currentItems.Count; i++)
            {
                var elementToTransform = currentItems[i];
                var ViewItem = new ListViewItem($"{elementToTransform.Type} x{elementToTransform.Count}");
                ViewItem.Tag = i;
                Inventory.Items.Add(ViewItem);
            }
            ShowDialog();
            if(Inventory.SelectedItems.Count != 0)SelectedIndex = (int)Inventory.SelectedItems[0].Tag;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StatusDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
