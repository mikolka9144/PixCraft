using System;

namespace Engine.Saves
{
    [Serializable]
    public class BlockTemplate
    {
        public BlockType Id { get; set; }
        public BlockTemplate()
        {

        }
        public BlockTemplate(BlockType id, int y, int x)
        {
            Id = id;
            Y = y;
            X = x;
        }

        public int Y { get; set; }
        public int X { get; set; }
    }
}