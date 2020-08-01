using Engine.GUI.Models;
using Engine.GUI.Models.Controls;
using Engine.Logic;
using Engine.Logic.models;
using PixBlocks.PythonIron.Tools.Integration;
using System.Threading;

namespace Engine.GUI
{
    class InventoryForm : Form, IStatusDisplayer
    {
        private CraftingModule craftingSystem;
        private PlayerStatus Inventory;
        private readonly Engine.Engine engine;

        public int SelectedIndex { get => list.Selection; }
        public RadioList list { get; }

        public void Present(PlayerStatus currentItems)
        {
            Inventory = currentItems;
            
            list.Initalize(currentItems.Inventory);
            if(list.radios.Count !=0)list.radios[SelectedIndex].Active = true;
            Show();
        }
        public InventoryForm(CraftingModule craftingSystem,Engine.Engine engine) :base(new Color(10,100,200),300)
        {
            list = new RadioList(new Vector(-70, 60),5);
            controls.Add(new Button(new Vector(-70, 90), "Craft", 30, ShowWorkBench));
            controls.Add(list);
            controls.Add(new CloseButton(new Vector(90, 90), 20, CloseForm));
            this.craftingSystem = craftingSystem;
            this.engine = engine;
        }

        private void ShowWorkBench(PixControl obj)
        {
            var craftingForm = new CraftingForm(craftingSystem, Inventory,ShowAfterCrafting);
            craftingForm.Show();
            Hide();
        }

        private void ShowAfterCrafting()
        {
            Present(Inventory);
            Thread.Sleep(80);
        }

        private void CloseForm(PixControl obj)
        {
            Hide();
            engine.Sprites.ForEach(s => s.Active = true);
        }

        public override void Show()
        {
            engine.Sprites.ForEach(s => s.Active = false);
            base.Show();
        }
    }
}
