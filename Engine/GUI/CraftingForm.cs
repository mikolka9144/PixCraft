using Engine.Logic;
using Engine.Resources;
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
    public partial class CraftingForm : Form
    {
        public CraftingForm(PlayerStatus playerStatus,CraftingModule craftingModule)
        {
            InitializeComponent();
            PlayerStatus = playerStatus;
            CraftingModule = craftingModule;
            listOfItemsToCraft.Items.AddRange(craftingModule.craftingEntries.Select(s => s.CraftedItem.type).Cast<object>().ToArray());
            UpdateInventory();
        }

        public PlayerStatus PlayerStatus { get; }
        public CraftingModule CraftingModule { get; }

        private void btnCraft_Click(object sender, EventArgs e)
        {

            if (!CraftingModule.Craft(PlayerStatus,(BlockType)listOfItemsToCraft.SelectedItem))
            {
                MessageBox.Show("Can't craft item.");
            }
            UpdateInventory();
        }
        private void UpdateNeededItems(List<Item> neededItems)
        {
            neededItemsList.Items.Clear();
            neededItemsList.Items.AddRange(ItemsConverter.LoadItemsToList(neededItems));
        }
        private void UpdateInventory()
        {
            Inventory.Items.Clear();
            Inventory.Items.AddRange(ItemsConverter.LoadItemsToList(PlayerStatus.Inventory));
        }

        private void listOfItemsToCraft_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedBlockType = (BlockType)listOfItemsToCraft.SelectedItem;
            UpdateNeededItems(CraftingModule.craftingEntries.Find(
                s => s.CraftedItem.type == selectedBlockType).NeededItems.ToList());
        }
    }
}
