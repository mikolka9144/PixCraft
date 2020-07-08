using PixBlocks.PythonIron.Tools.Game;

namespace Engine.Resources
{
    public interface IMoveDefiner
    {
        bool key(command command);
    }

    public enum command
    {
        Up,
        Left,
        Right,
        down,
        Jump,
        Action,
        Pause,
        OpenInventory,
        ChangeMouseState
    }

    public class PlayerMoveDefiner : IMoveDefiner
    {
        private bool PauseWasPressed;
        private bool InventoryWasPressed;

        public PlayerMoveDefiner()
        {
            game = GameScene.gameSceneStatic;
        }

        public GameScene game { get; private set; }

        public bool key(command command)
        {
            switch (command)
            {
                case command.Up:
                    return game.key("w");

                case command.Left:
                    return game.key("a");

                case command.Right:
                    return game.key("d");

                case command.down:
                    return game.key("s");

                case command.Jump:
                    return game.key("space");

                case command.ChangeMouseState:
                    return game.key("m");

                case command.Pause:
                    var state = game.key("p");
                    if (state)
                    {
                        if (PauseWasPressed == true) return false;
                        PauseWasPressed = true;
                        return state;
                    }
                    else
                    {
                        PauseWasPressed = false;
                        return state;
                    }

                case command.OpenInventory:
                    var State = game.key("e");
                    if (State)
                    {
                        if (InventoryWasPressed == true) return false;
                        InventoryWasPressed = true;
                        return State;
                    }
                    else
                    {
                        InventoryWasPressed = false;
                        return State;
                    }

                case command.Action:
                    return game.mouse.pressed;
            }
            return false;
        }
    }
}