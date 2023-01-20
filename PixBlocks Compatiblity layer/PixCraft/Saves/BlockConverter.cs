using Engine.Engine;
using Engine.Engine.models;
using Engine.Resources;
using Engine.Saves.Models;
using System.Collections.Generic;
//TODO Fix Saving
namespace Engine.Saves
{
    public class BlockConverter
    {
        public BlockConverter(IDrawer drawer, IIdProcessor processor)
        {
            Drawer = drawer;
            Processor = processor;
        }

        public IDrawer Drawer { get; }
        public IIdProcessor Processor { get; }

        public List<BlockData> Convert(List<BlockTemplate> blocks)
        {
            var list = new List<BlockData>();
            foreach (var item in blocks)
            {
                list.Add(new BlockData(item.X , item.Y , item.Id));
            }
            return list;
        }

        public List<BlockTemplate> Convert(List<BlockData> blocks)
        {
            var list = new List<BlockTemplate>();
            foreach (var item in blocks)
            {
                list.Add(new BlockTemplate(item.Type, item.Y, item.X));
            }
            return list;
        }
    }
}