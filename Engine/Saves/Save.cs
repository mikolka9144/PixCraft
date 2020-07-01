using Engine.Engine.models;
using Engine.Logic;
using IronPython.Runtime;
using System;
using System.Collections.Generic;

namespace Engine.Saves
{
    [Serializable]
    public class Save
    {
        public Save(List<Block> blocks,int hp,List<Item> items)
        {
            Tiles = blocks;
            Hp = hp;
            Items = items;
        }
        public Save()
        {

        }
        public List<Block> Tiles { get; set; }
        public int Hp { get; set; }
        public List<Item> Items { get; set; }
    }
}