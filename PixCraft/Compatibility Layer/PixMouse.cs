using Engine.Logic;
using Integration;
using PixBlocks.PythonIron.Tools.Game;

namespace PixBlocks_Compatiblity_layer
{
    internal class PixMouse : IMouse
    {
        public Vector2 position
        {
            get
            {
                var RawPos = GameScene.gameSceneStatic.mouse.position;
                return new Vector2((int)RawPos.x, (int)RawPos.y);
            }
        }

        public bool pressed => GameScene.gameSceneStatic.mouse.pressed;
    }
}