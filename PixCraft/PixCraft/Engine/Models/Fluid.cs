using Engine.Resources;

namespace Engine.Engine.models
{
    public class Fluid : SpriteOverlay { 
        public Fluid(int x, int y, BlockType Id, IDrawer engine, IIdProcessor processor) : base(x,y,engine)
        {
            image = 88;
            size = Parameters.BlockSize;
            processor.ProcessSprite(this, Id);
            this.Id = Id;
        }

        public BlockType Id { get; }
    }
}