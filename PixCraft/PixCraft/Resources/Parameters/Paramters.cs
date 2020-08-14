using Engine.Engine;
using Engine.Logic;
using Integration;

namespace Engine.Resources
{
    public class Parameters:IMovableObjectParameters,ITileManagerParameters,IPointerControllerParameters,IPlayerStatusParameters,IGeneratorParameters,IDrawerParameters
    {
        public  RangeBox border { get; } = new RangeBox(100, 100, 100, 100);
        public  int hitboxArea { get; } = 20;
        public  int BreakingRange { get; } = 50;
        public int PointerRange { get; } = 80;

        //Generator Parameters
        public static int BlockSize { get; } = 20;
        public int sizeOfStoneCollumn { get; } = 20;
        public int TreeSpread { get; } = 3;
        public int minimumFillarHeightForTree { get; } = 3;
        public int treeChance { get; } = 5;
        public int ChunkSize { get; } = 20;
        //Gameplay
        public int moveSpeed { get; set; } = 5;
        public int MaxFallSpeed { get; } = 6;
        public int MaxWaterFallSpeed { get; } = 2;
        public int StandUpSpeed { get; } = 3;
        public int WaterJumpSpeed { get; } = 4;

        public int WaterLevel { get; } = 2;
        public int BlocksCollisionDelay { get; } = 2;

        public int MoveDelay { get; } = 3;
        public int BaseHealth { get; } = 20;
        public int MaxSlotCapatility { get; } = 64;
        public int minimumBlocksForFall { get; } = 3;
        public int PointerStatusChangeDelay { get; } = 300;
        //colors
        public Color DefaultColor { get; set; } = new Color(15, 142, 255);
        public Color RedColor { get; } = new Color(255, 51, 0);
        public int MaxBreath { get; } = 10;
        public int LavaDamage { get; } = 5;
    }

    public struct RangeBox
    {


        public RangeBox(int Up, int Left, int Right, int Down)
        {
            this.Up = Up;
            this.Left = Left;
            this.Right = Right;
            this.Down = Down;
        }

        public int Up { get; }
        public int Left { get; }
        public int Right { get; }
        public int Down { get; }
    }
}