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
    public partial class CraftingForm : Form
    {
        public CraftingForm(PlayerStatus playerStatus,CraftingModule craftingModule)
        {
            InitializeComponent();
            PlayerStatus = playerStatus;
            CraftingModule = craftingModule;
            listOfItemsToCraft.Items.AddRange(craftingModule.craftingEntries.Select(s => s.CraftedItem.type).Cast<object>().ToArray());
        }

        public PlayerStatus PlayerStatus { get; }
        public CraftingModule CraftingModule { get; }

        private void btnCraft_Click(object sender, EventArgs e)
        {

            if (CraftingModule.Craft(PlayerStatus,(BlockType)listOfItemsToCraft.SelectedItem))
            {
                Close();
            }
            else
            {

            }
        }
    }
}
