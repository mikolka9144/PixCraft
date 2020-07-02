﻿using Engine.Engine;
using Engine.Engine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Saves
{
    public  class BlockConverter
    {
        public BlockConverter(Parameters parameters,IDrawer drawer,IIdProcessor processor)
        {
            Parameters = parameters;
            Drawer = drawer;
            Processor = processor;
        }

        public Parameters Parameters { get; }
        public IDrawer Drawer { get; }
        public IIdProcessor Processor { get; }

        public  List<Block> Convert(List<BlockTemplate> blocks)
        {
            var list = new List<Block>();
            foreach (var item in blocks)
            {
                list.Add(new Block(item.X, item.Y, item.Id, Parameters.BlockSize, Drawer, Processor, Parameters));
            }
            return list;
        }
        public List<BlockTemplate> Convert(List<Block> blocks)
        {
            var list = new List<BlockTemplate>();
            foreach (var item in blocks)
            {
                list.Add(new BlockTemplate(item.Id, item.Y, item.X));
            }
            return list;
        }
    }
}
