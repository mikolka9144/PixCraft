using IronPython.Runtime;
using System.Collections.Generic;

namespace Engine.Logic
{
    internal interface IStatusDisplayer
    {
        void Present(int life, List<Item> currentItems);
        int SelectedIndex { get; set; }
    }
}