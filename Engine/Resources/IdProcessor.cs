﻿using Engine.Engine.models;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Resources
{
    public interface IIdProcessor
    {
        void ProcessSprite(SpriteOverlay overlay,BlockType Id);
    }
    public class BlockIdProcessor : IIdProcessor
    {
        public void ProcessSprite(SpriteOverlay overlay,BlockType Id)
        {
            switch (Id)
            {
                case BlockType.Grass:
                    overlay.color = new Color(100, 200, 50);
                    break;
                case BlockType.Dirt:
                    overlay.color = new Color(200, 100, 50);
                    break;
                case BlockType.Stone:
                    overlay.color = new Color(156, 159, 161);
                    break;
                case BlockType.Wood:
                    overlay.color = new Color(153, 51, 0);
                    break;
                case BlockType.Leaves:
                    overlay.color = new Color(102, 153, 51);
                    break;
                case BlockType.CoalOre:
                    overlay.color = new Color(0, 0, 0);
                    break;
                case BlockType.IronOre:
                    overlay.color = new Color(203, 205, 205);
                    break;
                case BlockType.GoldOre:
                    overlay.color = new Color(153, 153, 0);
                    break;
                case BlockType.DiamondOre:
                    overlay.color = new Color(134, 255, 255);
                    break;
                case BlockType.Planks:
                    overlay.color = new Color(100, 100, 100);
                    break;
            }
        }
    }
    public enum BlockType
    {
        None,
        Grass,
        Dirt,
        Stone,
        Wood,
        Leaves,
        CoalOre,
        IronOre,
        GoldOre,
        DiamondOre,
        stick,
        Planks
    }
}