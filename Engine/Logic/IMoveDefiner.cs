using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.Views.GameControllerView;
using System;

namespace Engine.Logic
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
        BreakBlock,
        PlaceBlock,
        cameraUp,
        cameraCast,
        cameraLeft,
        cameraRight,
        cameraDown,
        Pause,
        OpenInventory
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
                case command.BreakBlock:
                    return game.key("n");
                case command.PlaceBlock:
                    return game.key("m");
                case command.cameraUp:
                    return game.key("up");
                case command.cameraCast:
                    return game.key("c");
                case command.cameraLeft:
                    return game.key("left");
                case command.cameraRight:
                    return game.key("right");
                case command.cameraDown:
                    return game.key("down");
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
            }
            return false;
        }
    }
}