using Integration;

namespace Engine.Resources
{
    public interface IMoveDefiner
    {
        bool key(command command);
    }

    public enum command
    {
        Left,
        Right,
        Jump,
        Action,
        Pause,
        OpenInventory,
        ChangeMouseState,
        Up,
        Down
    }

    public class PlayerMoveDefiner : IMoveDefiner
    {
        private bool PauseWasPressed;
        private bool InventoryWasPressed;

        public PlayerMoveDefiner(IGameScene gameScene,IMouse mouse)
        {
            game = gameScene;
            Mouse = mouse;
        }

        public IGameScene game { get; private set; }
        public IMouse Mouse { get; }

        public bool key(command command)
        {
            switch (command)
            {

                case command.Left:
                    return game.key("a");

                case command.Right:
                    return game.key("d");

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
                    return Mouse.pressed;
            }
            return false;
        }
    }
}