using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;

using PixBlocks.PythonIron.Tools.Game;

using System.Windows.Forms;

namespace Engine.Logic
{
    internal class Player : MovableObject 
    {
        private PauseForm settingsForm;

        public IMover Mover { get; }

        public Player(PauseForm pauseMenu, IActiveElements activeElements, PointerController pointer, IMoveDefiner definer, PlayerStatus status,IDrawer drawer,IMover mover,IPixSound sound) : base(activeElements, drawer, definer, pointer, status,sound)
        {
            position = new PixBlocks.PythonIron.Tools.Integration.Vector(0, 0);
            size = 10;
            image = 0;
            status.OnKill = KillPlayer;
            settingsForm = pauseMenu;
            Mover = mover;
        }
       

        public override void update()
        {
            base.update();
            if (moveDefiner.key(command.Pause)) Pause();
            if (moveDefiner.key(command.OpenInventory)) status.OpenInventory();
            MoveCamera();
        }

        private void MoveCamera()
        {
            if (X != 0)
            {
                Mover.Move(roation.Left, X);
                X = 0;
            }
            if (Y != 0)
            {
                Mover.Move(roation.Down, Y);
                Y = 0;
            }
        }

        private void Pause()
        {
            settingsForm.Show();
        }

        private void KillPlayer()
        {
            GameScene.gameSceneStatic.stop();
            MessageBox.Show("You Died.");
        }
    }
}