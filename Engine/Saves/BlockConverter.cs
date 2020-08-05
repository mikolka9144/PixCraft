using Engine.Engine;
using Engine.Engine.models;
using Engine.Resources;
using Engine.Saves.Models;
using System.Collections.Generic;

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

        public List<Fluid> Convert(List<FluidTemplate> blocks, int CenterX, int CenterY)
        {
            var list = new List<Fluid>();
            foreach (var item in blocks)
            {
                list.Add(new Fluid(item.X - CenterX, item.Y - CenterY, item.Id, Drawer, Processor));
            }
            return list;
        }
        public List<Block> Convert(List<BlockTemplate> blocks, int CenterX, int CenterY)
        {
            var list = new List<Block>();
            foreach (var item in blocks)
            {
                list.Add(new Block(item.X - CenterX, item.Y - CenterY, item.Id, Drawer, Processor));
            }
            return list;
        }

        public List<BlockTemplate> Convert(List<Block> blocks)
        {
            var list = new List<BlockTemplate>();
            foreach (var item in blocks)
            {
                list.Add(new BlockTemplate(item.Id, item.Position.Y, item.Position.X));
            }
            return list;
        }
        public List<FluidTemplate> Convert(List<Fluid> blocks)
        {
            var list = new List<FluidTemplate>();
            foreach (var item in blocks)
            {
                list.Add(new FluidTemplate(item.Id, item.Position.Y, item.Position.X));
            }
            return list;
        }
    }
}