using Engine.Logic;
using Engine.Resources;
using System;
using System.Windows.Forms;

namespace Engine.GUI
{
    internal partial class StatusDisplay : Form, IStatusDisplayer
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
            double precentage = (double)life / Parameters.BaseHealth * 100.0;
            LifeBar.Value = (int)precentage;
            Inventory.Items.Clear();
            Inventory.Items.AddRange(ItemsConverter.LoadItemsToList(currentItems.Inventory));
            ShowDialog();
            if (Inventory.SelectedItems.Count != 0) SelectedIndex = (int)Inventory.SelectedItems[0].Tag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CraftingForm(playerStatus, Module);
            form.ShowDialog();
            Inventory.Items.Clear();
            Inventory.Items.AddRange(ItemsConverter.LoadItemsToList(playerStatus.Inventory));
        }

        private void Inventory_DoubleClick(object sender, EventArgs e) => Close();
        
    }
}