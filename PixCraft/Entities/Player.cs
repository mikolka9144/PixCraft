using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using Integration;

namespace Engine.Logic
{
    internal class Player : MovableObject 
    {
        private PauseForm settingsForm;

        public IMover Mover { get; }
        public IGameScene Scene { get; }

        public Player(PauseForm pauseMenu, IActiveElements activeElements,IMoveDefiner definer, PlayerStatus status,IDrawer drawer,IMover mover,IPixSound sound,IMovableObjectParameters parameters,IGameScene scene) : base(activeElements, drawer, definer, status,sound,parameters)
        {
            position = new Vector(0, 0);
            size = 10;
            image = 0;
            status.OnKill = KillPlayer;
            settingsForm = pauseMenu;
            Mover = mover;
            Scene = scene;
        }
       

        public override void update()
        {
            base.update();
            if (!Active) return;
            if (moveDefiner.key(command.Pause)) Pause();
            if (moveDefiner.key(command.OpenInventory)) status.OpenInventory();
            MoveCamera();
        }

        private void MoveCamera()
        {
            if (Position.X != 0)
            {
                Mover.Move(roation.Left, Position.X);
                Position.X = 0;
            }
            if (Position.Y != 0)
            {
                Mover.Move(roation.Down, Position.Y);
                Position.Y = 0;
            }
        }

        private void Pause()
        {
            settingsForm.Show();
        }

        private void KillPlayer()
        {
            Scene.stop();
            Scene.ShowMessage("You Died.");
        }
    }
}