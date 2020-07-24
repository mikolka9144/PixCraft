using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.GUI.Models
{
    public class SelectBox:PixControl
    {

        public SelectBox(Vector vector,IList<Box> boxes)
        {
            size = 0;
            ItemsList = new List<BoxItem>();
            for (int i = 0; i < boxes.Count(); i++)
            {
                var localVector = new Vector(vector.x,vector.y-(30*i));
                ItemsList.Add(
                    new BoxItem(localVector, boxes[i].Name,30,boxes[i].Task));
            }
            
        }
        internal List<BoxItem> ItemsList { get; }

        public override void Hide()
        {
            ItemsList.ForEach(s => s.Hide());
            base.Hide();
        }

        public override void Show()
        {
            ItemsList.ForEach(s => s.Show());
            base.Show();
        }
    }

    public struct Box
    {
        public Box(string name,Action task)
        {
            Name = name;
            Task = task;
        }

        public string Name { get; }
        public Action Task { get; }
    }
}
