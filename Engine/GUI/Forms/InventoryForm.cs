﻿using Engine.GUI.Models;
using Engine.Logic;
using Engine.Logic.models;
using PixBlocks.PythonIron.Tools.Integration;

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
            InitFromPresent(currentItems);
            Show();
        }

        private void InitFromPresent(PlayerStatus currentItems)
        {
            Inventory = currentItems;

            list.Initalize(currentItems.Inventory);
            if (list.radios.Count-1 >= SelectedIndex) list.radios[SelectedIndex].Active = true;
        }

        public InventoryForm(CraftingModule craftingSystem,Engine.Engine engine) :base(new Color(10,100,200),300,null,true)
        {
            list = new RadioList(new Vector(-70, 60),5);
            controls.Add(new Button(new Vector(-70, 90), "Craft", 30, ShowWorkBench));
            controls.Add(list);
            this.craftingSystem = craftingSystem;
            this.engine = engine;
        }

        private void ShowWorkBench(PixControl obj)
        {
            var craftingForm = new CraftingForm(craftingSystem, Inventory,this);
            craftingForm.Show();
            Hide();
        }

        public override void Close()
        {
            base.Close();
            engine.Sprites.ForEach(s => s.Active = true);
        }

        public override void Show()
        {
            engine.Sprites.ForEach(s => s.Active = false);
            InitFromPresent(Inventory);
            base.Show();
        }
    }
}