using Engine.Resources;

namespace Engine.Engine.models
{
    public class Block : SpriteOverlay
    {
        internal ToolType tool;
        private readonly BlockData data;

        public Block(int x, int y, BlockData data, IDrawer engine, IIdProcessor processor) : base(x, y, engine)
        {
            this.data = data;
            image = 63;
            size = Parameters.BlockSize;

            this.Id = Id;
            processor.ProcessSprite(this, Id);
        }

        public BlockType Id { get => data.id; }
        public int Durablity { get; set; }
        public int MinimumPower { get; set; }
    }
}