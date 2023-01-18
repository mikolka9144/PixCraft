using Engine.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.GUI.Models
{
    public class SelectBox:PixControl
    {

        public SelectBox(Vector2 vector,IList<Box> boxes, Engine.IDrawer drawer, Integration.IMouse mouse) :base(drawer,mouse)
        {
            size = 0;
            ItemsList = new List<Button>();
            for (int i = 0; i < boxes.Count(); i++)
            {
                var localVector = new Vector2(vector.x,vector.y-(30*i));
                ItemsList.Add(
                    new Button(localVector, boxes[i].Name,30,boxes[i].Task,drawer,mouse));
            }
            
        }
        internal List<Button> ItemsList { get; }

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
        public Box(string name,Action<PixControl> task)
        {
            Name = name;
            Task = task;
        }
        public Box(string name, Action task)
        {
            Name = name;
            Task = (s) =>task.Invoke();
        }

        public string Name { get; }
        public Action<PixControl> Task { get; }
    }
}
