using Engine.GUI.Models;
using Engine.Logic;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.GUI
{
    internal class CraftingForm:Form
    {
        private CraftingModule craftingSystem;
        private PlayerStatus inventory;

        private RadioList allCraftings;
        private RadioList neededItems;
        private RadioList havedItems;

        public CraftingForm(CraftingModule craftingSystem, PlayerStatus inventory):base(new Color(100,200,255),300)
        {
            this.craftingSystem = craftingSystem;
            this.inventory = inventory;
            allCraftings = new RadioList(new Vector(-80,90), 6);
            controls.Add(allCraftings);
            neededItems = new RadioList(new Vector(0, 90), 4);
            controls.Add(neededItems);
            havedItems = new RadioList(new Vector(0, 0), 4);
            controls.Add(havedItems);
        }
    }
}