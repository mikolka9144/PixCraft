using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;

namespace Engine.GUI.Models
{
    class RadioList:PixControl
    {
        public List<IndexedButton> radios { get; }
        public int Selection { get; set; }
        public int ItemsInCollumn { get; }
        public bool DisableSelection { get; }
        public event EventHandler<IndexedButton> OnSelectionChange;

        public RadioList(Vector vector,int itemsInCollumn,bool DisableSelection = false)
        {
            position = vector;
            size = 0;
            radios = new List<IndexedButton>();
            ItemsInCollumn = itemsInCollumn;
            this.DisableSelection = DisableSelection;
        }
        public void Initalize(IEnumerable<object> controls)
        {
            radios.Clear();
            var Ypos = position.y;
            var Xpos = position.x;
            var i = 0;
            foreach (var item in controls)
            {
                if (i % ItemsInCollumn == 0 && i != 0)
                {
                    Xpos += 30;
                    Ypos = position.y;
                }
                var radio = new IndexedButton(new Vector(Xpos, Ypos),item, 30, changeSelection, i);
                radios.Add(radio);
                Ypos -= 30;
                i++;
            }
            if (radios.Count == 0) return;
            
        }
        private void changeSelection(PixControl obj)
        {
            if (DisableSelection) return;

            radios.ForEach(s => s.Active = false);
            var radio = obj as IndexedButton;
            radio.Active = true;
            Selection = radio.Index;
            OnSelectionChange?.Invoke(this,radio);
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
