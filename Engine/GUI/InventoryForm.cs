using Engine.GUI.Models;
using Engine.GUI.Models.Controls;
using Engine.Logic;
using Engine.Logic.models;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;

namespace Engine.GUI
{
    class InventoryForm : Form, IStatusDisplayer
    {
        private CraftingModule craftingSystem;
        private readonly Engine.Engine engine;

        public int SelectedIndex { get => list.Selection; }
        public RadioList list { get; }

        public void Present(PlayerStatus currentItems)
        {
            var elements = new List<RadioTemplate>();
            foreach (var item in currentItems.Inventory)
            {
                elements.Add(new RadioTemplate($"{item.Name} X:{item.Count}"));
            }
            list.Initalize(elements);
            Show();
        }
        public InventoryForm(CraftingModule craftingSystem,Engine.Engine engine) :base(new Color(10,100,200),300)
        {
            list = new RadioList(new Vector(0, 0));
            controls.Add(list);
            controls.Add(new CloseButton(new Vector(90, 90), 20, CloseForm));
            this.craftingSystem = craftingSystem;
            this.engine = engine;
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
