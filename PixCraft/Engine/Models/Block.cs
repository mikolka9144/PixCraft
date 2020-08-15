using Engine.Resources;

namespace Engine.Engine.models
{
    public class Block : SpriteOverlay
    {
        internal ToolType tool;

        public Block(int x, int y, BlockType Id, IDrawer engine, IIdProcessor processor) : base(x, y, engine)
        {
            image = 63;
            size = Parameters.BlockSize;

            this.Id = Id;
            processor.ProcessSprite(this, Id);
        }

        public BlockType Id { get; }
        public int Durablity { get; set; }
        public int MinimumPower { get; set; }
    }
}