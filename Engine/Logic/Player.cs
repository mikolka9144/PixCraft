using Engine;
using Engine.Engine;
using Engine.Engine.models;
using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.TopPanel.Components.Basic;
using PixBlocks.Views.GameControllerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Logic
{
    class Player:Movable_object
    {
        public Player(Parameters paramters,IActiveElements activeElements,IMover manager,PointerController pointer,IMoveDefiner definer,PlayerStatus status):base(activeElements,manager,definer,pointer,paramters,status)
        {
            position = new PixBlocks.PythonIron.Tools.Integration.Vector(0, 0);
            size = 10;
            image = 0;
            status.OnKill += KillPlayer;
        }

        private void KillPlayer()
        {
            Application.Current.Dispatcher.Invoke(ShowMessage);
            Thread.CurrentThread.Abort();
        }

        private void ShowMessage()
        {
            CustomMessageBox.Show("You Died");
        }
    }
}
