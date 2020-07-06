using IronPython.Runtime;
using System.Collections.Generic;

namespace Engine.Logic
{
    public interface IStatusDisplayer
    {
        void Present(int life, PlayerStatus currentItems);
        int SelectedIndex { get; set; }
    }
}