using Engine;
using Engine.PixBlocks_Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PixBlocks_Compatiblity_layer
{
    public class StartUpScript
    {
        public StartUpScript()
        {
            try
            {
                var PixScene = new PixScene();
                Init = new StartUp(PixScene, new PixMouse(), new Sound());
            }
            catch (Exception ex)
            {
                if (ex is ThreadInterruptedException) return;
                PixScene.ShowErrorStatic(ex);
            }
        }

        public PixScene PixScene { get; }
        public StartUp Init { get; private set; }
    }
}
