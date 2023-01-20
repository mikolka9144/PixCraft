using Engine.Resources;

namespace Engine.Engine.models{
    public class BlockData
    {
        public int X { get; }
        public int Y { get; }
        public BlockType Type { get; }
        public BlockData(int BlockX,int BlockY,BlockType type)
        {
            this.Type = type;
            this.Y = BlockY;
            this.X = BlockX;
            
        }
    }
}


