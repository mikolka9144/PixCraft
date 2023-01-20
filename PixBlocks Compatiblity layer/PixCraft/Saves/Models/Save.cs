using Engine.Logic;
using System.Collections.Generic;

namespace Engine.Saves.Models
{
    public class Save
    {
        public void SetUp(List<BlockTemplate> blocks, int hp, List<Item> items, int CenterX, int CenterY)
        {
            this.CenterX = CenterX;
            this.CenterY = CenterY;
            Tiles = blocks;
            Hp = hp;
            Items = items;
        }

        public List<BlockTemplate> Tiles { get; set; }
        public int Hp { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public List<Item> Items { get; set; }
    }
}