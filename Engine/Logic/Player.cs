using Engine.Engine.models;
using Engine.GUI;
using Engine.Resources;
using PixBlocks.TopPanel.Components.Basic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Engine.Logic
{
    class Player:Movable_object
    {
        private readonly PauseMenu settingsForm;

        public Player(PauseMenu pauseMenu,IActiveElements activeElements,IMover manager,PointerController pointer,IMoveDefiner definer,PlayerStatus status):base(activeElements,manager,definer,pointer,status)
        {
            position = new PixBlocks.PythonIron.Tools.Integration.Vector(0, 0);
            size = 10;
            image = 0;
            status.OnKill += KillPlayer;
            PostUpdate += Update;
            settingsForm = pauseMenu;
            OnDamageDeal += () =>Task.Run(Player_OnDamageDeal);
        }

        private void Player_OnDamageDeal()
        {
            color = Parameters.RedColor;
            Thread.Sleep(600);
            color = Parameters.DefaultColor;
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
