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
        public StatusDisplay(CraftingModule module)
        {
            InitializeComponent();
            Module = module;
        }

        public CraftingModule Module { get; private set; }
        public PlayerStatus playerStatus { get; private set; }
        public int SelectedIndex { get; set; }

        public void Present(int life, PlayerStatus currentItems)
        {
            playerStatus = currentItems;
            SelectedIndex = -1;
            Inventory.Items.Clear();
            double precentage = ((double)life / Parameters.BaseHealth) * 100.0;
            LifeBar.Value = (int)precentage;
            for (int i = 0; i < currentItems.Inventory.Count; i++)
            {
                var elementToTransform = currentItems.Inventory[i];
                var ViewItem = new ListViewItem($"{elementToTransform.Name} x{elementToTransform.Count}");
                ViewItem.Tag = i;
                Inventory.Items.Add(ViewItem);
            }
            ShowDialog();
            if(Inventory.SelectedItems.Count != 0)SelectedIndex = (int)Inventory.SelectedItems[0].Tag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CraftingForm(playerStatus,Module);
            form.ShowDialog();
        }
    }
}
