using System;

namespace Engine.Saves
{
    [Serializable]
    public class BlockTemplate
    {
        public BlockType Id { get; internal set; }

        public BlockTemplate(BlockType id, int y, int x)
        {
            Id = id;
            Y = y;
            X = x;
        }

        public int Y { get; internal set; }
        public int X { get; internal set; }
    }
}