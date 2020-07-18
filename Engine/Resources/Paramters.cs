using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Resources
{
    public class Parameters
    {
        public static (int Up, int Left, int Right, int Down) border = (100, 100, 100, 100);
        public static (int Up, int Left, int Right, int Down) hitboxArea = (20, 20, 20, 20);
        internal static int PointerRange = 50;
        public static int Delay = 0;

        //Generator Parameters
        public static int BlockSize = 20;
        public static int sizeOfStoneCollumn = 20;
        public static int TreeSpread = 3;
        public static int minimumFillarHeightForTree = 3;
        public static int treeChance = 5;
        public static int ChunkSize = 20;
        //Gameplay
        public static int moveSpeed = 5;
        public static int MaxFallSpeed = 6;
        internal static int MaxWaterFallSpeed = 2;
        internal static int StandUpSpeed = 3;
        internal static int WaterJumpSpeed = 4;

        internal static int WaterLevel = 2;
        public static int BlocksCollisionDelay = 2;

        public static int MoveDelay = 3;
        public static int BaseHealth = 20;
        internal static int MaxSlotCapatility = 64;
        internal static int minimumBlocksForFall = 3;
        internal static int PointerStatusChangeDelay = 300;
        //colors
        internal static Color DefaultColor = new Color(15, 142, 255);
        internal static Color RedColor = new Color(255, 51, 0);
        public static int MaxBreath = 2;
    }
}