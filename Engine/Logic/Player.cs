using Engine;
using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
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
        private readonly PauseMenu settingsForm;

        public Player(Parameters paramters,IActiveElements activeElements,IMover manager,PointerController pointer,IMoveDefiner definer,PlayerStatus status):base(activeElements,manager,definer,pointer,paramters,status)
        {
            position = new PixBlocks.PythonIron.Tools.Integration.Vector(0, 0);
            size = 10;
            image = 0;
            status.OnKill += KillPlayer;
            PostUpdate += Update;
            settingsForm = new PauseMenu(paramters);
            OnDamageDeal += () =>Task.Run(Player_OnDamageDeal);
        }

        private void Player_OnDamageDeal()
        {
            color = new Color(204, 0, 51);
            Thread.Sleep(600);
            color = new Color(15, 142, 255);
        }

        private void Pause()
        {
            settingsForm.ShowDialog();
        }
        private void Update()
        {
            if (moveDefiner.key(command.Pause)) Pause();
            if (moveDefiner.key(command.OpenInventory)) status.OpenInventory();            
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
