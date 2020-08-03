using Engine.GUI.Models;
using Engine.GUI.Models.Controls;
using PixBlocks.PythonIron.Tools.Integration;
using System.Collections.Generic;
using System.Threading;

namespace Engine.GUI
{
    public class Form : PixControl
    {
        public Form(Color color, int size,Form previousForm,bool IsCloseAble = false)
        {
            this.size = size;
            image = 63;
            this.color = color;
            FormToClose = previousForm;
            if(previousForm != null||IsCloseAble) controls.Add(new CloseButton(new Vector(90, 90), 20, (s) =>Close()));
        }
        public List<PixControl> controls = new List<PixControl>();

        public Form FormToClose { get; }

        public override void Show()
        {
            base.Show();
            controls.ForEach(s => s.Show());
        }

        public override void Hide()
        {
            base.Hide();
            controls.ForEach(s => s.Hide());
                Thread.Sleep(80);
        }
        public virtual void Close()
        {
            FormToClose?.Show();   
            Hide();          
        }
    }
}