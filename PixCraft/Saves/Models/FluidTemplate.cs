using Engine.Resources;

namespace Engine.Saves
{
    public class FluidTemplate
    {
        public FluidTemplate(BlockType id, int y, int x)
        {
            Id = id;
            Y = y;
            X = x;
        }

        public FluidTemplate()
        {

        }
        public BlockType Id { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
    }
}