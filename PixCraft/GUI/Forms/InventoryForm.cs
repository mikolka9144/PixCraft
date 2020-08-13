using Engine.Engine;
using Engine.GUI.Models;
using Engine.Logic;
using Engine.Logic.models;
using Integration;

namespace Engine.GUI
{
    class InventoryForm : Form, IStatusDisplayer
    {
        private CraftingModule craftingSystem;
        private PlayerStatus Inventory;
        private Label HpLabel;
        private CraftingForm craftingForm;
        private readonly Engine.Engine engine;
        private readonly IMouse mouse;
        private readonly IDrawer drawer;
        private readonly IGameScene scene;

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
            craftingForm = new CraftingForm(craftingSystem,currentItems,this, mouse,drawer,scene);
            HpLabel.text = $"HP:{currentItems.health}/{Inventory.parameters.BaseHealth}";
            list.Initalize(currentItems.Inventory,25);
            if (list.radios.Count-1 >= SelectedIndex) list.radios[SelectedIndex].Active = true;
        }

        public InventoryForm(CraftingModule craftingSystem, Engine.Engine engine, IMouse mouse, Engine.IDrawer drawer,IGameScene scene) :base(new Color(10,100,200),300,null,mouse,drawer,true)
        {
            list = new RadioList(new Vector2(-70, 60),5,drawer,mouse);
            controls.Add(new Button(new Vector2(-70, 90), "Craft", 30, ShowWorkBench, drawer, mouse));
            HpLabel = new Label(new Vector2(-30, 90), "", 30, drawer, mouse) { color = new Color(200,0,0)};
            controls.Add(HpLabel);
            controls.Add(list);
            this.craftingSystem = craftingSystem;
            this.engine = engine;
            this.mouse = mouse;
            this.drawer = drawer;
            this.scene = scene;
        }

        private void ShowWorkBench(PixControl obj)
        {
            craftingForm.Show();
            Hide();
        }

        public override void Close()
        {
            base.Close();
            engine.Start();
        }

        public override void Show()
        {
            engine.Stop();
            InitFromPresent(Inventory);
            base.Show();
        }
    }
}
