using Engine.GUI.Models;
using Engine.Logic;
using Integration;
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

        public IGameScene Scene { get; }

        public CraftingForm(CraftingModule craftingSystem, PlayerStatus inventory,Form previousForm, IMouse mouse, Engine.IDrawer drawer,IGameScene scene) :base(new Color(100,200,255),300,previousForm,mouse,drawer)
        {
            this.craftingSystem = craftingSystem;
            this.inventory = inventory;
            Scene = scene;
            controls.Add(new Label(new Vector2(-80, 90), "Rcepies", 30,drawer,mouse));
            allCraftings = new RadioList(new Vector2(-80,70), 6, drawer, mouse);
            allCraftings.OnSelectionChange += AllCraftings_OnSelectionChange;
            controls.Add(allCraftings);

            controls.Add(new Label(new Vector2(0, 95), "Requirements", 30, drawer, mouse));
            neededItems = new RadioList(new Vector2(0, 75), 2, drawer, mouse, true);
            controls.Add(neededItems);

            controls.Add(new Label(new Vector2(0, 20), "Inventory", 30, drawer, mouse));
            havedItems = new RadioList(new Vector2(0, 0), 4, drawer, mouse, true);
            controls.Add(havedItems);

            controls.Add(new Button(new Vector2(-50, -90), "Craft", 20, CraftItem, drawer, mouse) { color = new Color(204, 51, 153) });
            controls.Add(new Button(new Vector2(-50, -60), "Filter", 20, Filter, drawer, mouse) { color = new Color(104, 51, 153) });
            
        }

        private void Filter(PixControl obj)
        {
            var text = Scene.GetInput("Enter query for filter").ToLower();
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
            allCraftings.Initalize(craftingSystem.craftingEntries,10);
            havedItems.Initalize(inventory.Inventory,12);
        }

        private void RefreshInventory()
        {
            havedItems.Hide();
            havedItems.Initalize(inventory.Inventory,12);
            havedItems.Show();
        }
        public override void Show()
        {
            InitData();
            base.Show();
        }
    }
}