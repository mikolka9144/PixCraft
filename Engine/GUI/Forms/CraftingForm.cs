using Engine.GUI.Models;
using Engine.Logic;
using PixBlocks.PythonIron.Tools.Integration;
using System.Linq;
using System.Threading;

namespace Engine.GUI
{
    internal class CraftingForm:Form
    {
        private CraftingModule craftingSystem;
        private PlayerStatus inventory;
        private RadioList allCraftings;
        private RadioList neededItems;
        private RadioList havedItems;

        public CraftingForm(CraftingModule craftingSystem, PlayerStatus inventory,Form previousForm):base(new Color(100,200,255),300,previousForm)
        {
            this.craftingSystem = craftingSystem;
            this.inventory = inventory;

            controls.Add(new Label(new Vector(-80, 90), "Rcepies", 30));
            allCraftings = new RadioList(new Vector(-80,70), 7);
            allCraftings.OnSelectionChange += AllCraftings_OnSelectionChange;
            controls.Add(allCraftings);

            controls.Add(new Label(new Vector(0, 95), "Requirements", 30));
            neededItems = new RadioList(new Vector(0, 75), 2,true);
            controls.Add(neededItems);

            controls.Add(new Label(new Vector(0, 20), "Inventory", 30));
            havedItems = new RadioList(new Vector(0, 0), 4,true);
            controls.Add(havedItems);

            controls.Add(new Button(new Vector(-50, -90), "Craft", 20, CraftItem) { color = new Color(204, 51, 153) });
            InitData();
        }

        private void CraftItem(PixControl obj)
        {
            var item = allCraftings.radios[allCraftings.Selection].ObjectToRepresent as Item;
            craftingSystem.Craft(inventory, item.type);
            RefreshInventory();
            Thread.Sleep(100);
        }

        private void AllCraftings_OnSelectionChange(object sender,SelectionEventArgs args)
        {
            neededItems.Hide();
            neededItems.Initalize(craftingSystem.craftingEntries[args.radio.Index].NeededItems,6);
            neededItems.Show();
        }

        private void InitData()
        {
            allCraftings.Initalize(craftingSystem.craftingEntries.Select(s => s.CraftedItem),11);
            havedItems.Initalize(inventory.Inventory,12);
        }

        private void RefreshInventory()
        {
            havedItems.Hide();
            havedItems.Initalize(inventory.Inventory,12);
            havedItems.Show();
        }
    }
}