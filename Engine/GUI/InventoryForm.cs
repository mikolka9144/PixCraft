using Engine.GUI.Models;
using Engine.Logic;
using Engine.Logic.models;
using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.Views.CodeElements.BasicBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GUI
{
    class InventoryForm : Form, IStatusDisplayer
    {
        private CraftingModule craftingSystem;

        public int SelectedIndex { get; set; }

        public void Present(PlayerStatus currentItems)
        {
            //controls.Clear();
            Show();
        }
        public InventoryForm(CraftingModule craftingSystem) :base(new Color(10,100,200),200)
        {
            controls.Add(new RadioEntry(new Vector(0, 0), "Test"));
            this.craftingSystem = craftingSystem;
        }

    }
}
