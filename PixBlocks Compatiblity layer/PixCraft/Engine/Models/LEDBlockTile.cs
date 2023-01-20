using Engine.Resources;

namespace Engine.Engine.models
{
    public class LEDBlockTile : SpriteOverlay
    {
        internal ToolType tool;

        public BlockData Data {get; private set;}

        public LEDBlockTile(int x, int y, BlockData data, IDrawer engine, IIdProcessor processor) : base(x, y, engine)
        {
            this.Data = data;
            size = Parameters.BlockSize;
            if (data.Type == BlockType.None) image = 2;
            processor.ProcessSprite(this, Id);
        }
        public void morphInto(BlockData data,IIdProcessor processor){
            this.Data = data;
            processor.ProcessSprite(this, Id);
            Engine.Draw(this);
        }
        public BlockType Id { get => Data.Type; }
        public int Durablity { get; set; }
        public int MinimumPower { get; set; }
        public bool IsFluid { get;  set; }
    }
}