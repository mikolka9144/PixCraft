using Engine.Engine;
using Engine.Logic;
using Integration;
using System;
using System.Collections.Generic;

namespace Engine.GUI.Models
{
    class RadioList:PixControl
    {
        public List<IndexedButton> radios { get; }
        public int Selection { get; set; }
        public int ItemsInCollumn { get; }
        public IDrawer Drawer { get; }
        public bool DisableSelection { get; }
        public event EventHandler<SelectionEventArgs> OnSelectionChange;

        public RadioList(Vector2 vector,int itemsInCollumn, IDrawer drawer, IMouse mouse, bool DisableSelection = false) :base(drawer,mouse)
        {
            position = vector;
            size = 0;
            radios = new List<IndexedButton>();
            ItemsInCollumn = itemsInCollumn;
            Drawer = drawer;
            this.DisableSelection = DisableSelection;
        }
        public void Initalize(IEnumerable<object> controls,int maxElements)
        {
            radios.Clear();
            var Ypos = position.y;
            var Xpos = position.x;
            var i = 0;
            foreach (var item in controls)
            {
                if (i % ItemsInCollumn == 0 && i != 0)
                {
                    Xpos += 40;
                    Ypos = position.y;
                }
                var radio = new IndexedButton(new Vector2(Xpos, Ypos),item, 30, changeSelection,Drawer,Mouse);
                radios.Add(radio);
                Ypos -= 30;
                i++;
                if (i == maxElements) break;
            }
            
        }
        private void changeSelection(PixControl obj)
        {
            if (DisableSelection) return;

            radios.ForEach(s => s.Active = false);
            var radio = obj as IndexedButton;
            radio.Active = true;
            Selection = radios.IndexOf(radio);
            OnSelectionChange?.Invoke(this,new SelectionEventArgs(radio));
        }
        public override void Show()
        {
            radios.ForEach(s => s.Show());
        }
        public override void Hide()
        {
            radios.ForEach(s => s.Hide());
        }
    }
}
