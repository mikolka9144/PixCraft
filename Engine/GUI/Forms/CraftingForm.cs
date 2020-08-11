using Engine.GUI.Models;
using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
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
            allCraftings = new RadioList(new Vector(-80,70), 6);
            allCraftings.OnSelectionChange += AllCraftings_OnSelectionChange;
            controls.Add(allCraftings);

            controls.Add(new Label(new Vector(0, 95), "Requirements", 30));
            neededItems = new RadioList(new Vector(0, 75), 2,true);
            controls.Add(neededItems);

            controls.Add(new Label(new Vector(0, 20), "Inventory", 30));
            havedItems = new RadioList(new Vector(0, 0), 4,true);
            controls.Add(havedItems);

            controls.Add(new Button(new Vector(-50, -90), "Craft", 20, CraftItem) { color = new Color(204, 51, 153) });
            controls.Add(new Button(new Vector(-50, -60), "Filter", 20, Filter) { color = new Color(104, 51, 153) });
            InitData();
        }

        private void Filter(PixControl obj)
        {
            var text = GameScene.gameSceneStatic.PythonCodeRunner.show("Enter query for filter").ToLower();
            var filtredCraftings = craftingSystem.craftingEntries.Where(s => s.CraftedItem.Name.ToLower().Contains(text));
            allCraftings.Hide();
            allCraftings.Initalize(filtredCraftings, 10);
            allCraftings.Show();
        }

        private void CraftItem(PixControl obj)
        {
            var item = allCraftings.radios[allCraftings.Selection].ObjectToRepresent as CraftingEntry;
            craftingSystem.Craft(inventory, item.CraftedItem.Type);
            RefreshInventory();
            Thread.Sleep(100);
        }

        private void AllCraftings_OnSelectionChange(object sender,SelectionEventArgs args)
        {
            var obj = args.radio.ObjectToRepresent as CraftingEntry;
            neededItems.Hide();
            neededItems.Initalize(obj.NeededItems,6);
            neededItems.Show();
        }

        private void InitData()
        {
            allCraftings.Initalize(craftingSystem.craftingEntries,11);
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