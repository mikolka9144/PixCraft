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
            foliage = new Foliage(x, y + (int)size / 3, this);

            this.Id = Id;
            processor.ProcessSprite(this, Id);
            processor.ProcessSprite(foliage, Id);
        }

        public Foliage foliage { get; private set; }
        public BlockType Id { get; }
        public int Durablity { get; set; }
        public int MinimumPower { get; set; }
    }
}