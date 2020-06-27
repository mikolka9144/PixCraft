using Engine;
using Engine.Engine;
using Engine.Engine.models;
using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.Views.GameControllerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Player:Movable_object
    {
        public Player(Parameters paramters,IActiveElements activeElements,IMover manager,PointerController pointer,IMoveDefiner definer):base(activeElements,manager,definer,pointer,paramters)
        {
            position = new Vector(0, 0);
            size = 10;
            image = 0;
        }
    }
}
