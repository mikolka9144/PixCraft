using Engine.Engine.models;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;

namespace Engine.Resources
{
    public interface IIdProcessor
    {
        void ProcessSprite(Block overlay, BlockType Id);
        void ProcessSprite(Foliage overlay, BlockType Id);
        void ProcessSprite(Fluid overlay, BlockType Id);
    }

    public class BlockIdProcessor : IIdProcessor
    {
        private List<BlockType> MinableBlocks = new List<BlockType>() { BlockType.Stone};
        private List<BlockType> AxeableBlocks = new List<BlockType>() { BlockType.Wood};
        private List<BlockType> ShovelableBlocks = new List<BlockType>() { BlockType.Dirt};

        public void ProcessSprite(Block overlay, BlockType Id)
        {
            ProcessColor(overlay, Id);
            if (MinableBlocks.Contains(Id)) overlay.tool = ToolType.Pixaxe;
            if (ShovelableBlocks.Contains(Id)) overlay.tool = ToolType.Shovel;
            if (AxeableBlocks.Contains(Id)) overlay.tool = ToolType.Axe;
            ProcessDyrablity(overlay, Id);
            ProcessRequirements(overlay);
        }

        private void ProcessRequirements(Block overlay)
        {
            switch (overlay.Id)
            {
                case BlockType.Stone:
                    overlay.MinimumPower = 10;
                    break;
                case BlockType.CoalOre:
                    overlay.MinimumPower = 10;
                    break;
                case BlockType.IronOre:
                    break;
                case BlockType.GoldOre:
                    break;
                case BlockType.DiamondOre:
                    break;
                case BlockType.Furnance:
                    overlay.MinimumPower = 15;
                    break;
            }
        }

        private void ProcessDyrablity(Block block,BlockType type)
        {
            block.Durablity = 20;
            switch (type)
            {
                case BlockType.Grass:
                    block.Durablity = 20;
                    break;
                case BlockType.Dirt:
                    block.Durablity = 10;
                    break;
                case BlockType.Stone:
                    break;
                case BlockType.Wood:
                    break;
                case BlockType.Leaves:
                    break;
                case BlockType.CoalOre:
                    break;
                case BlockType.IronOre:
                    break;
                case BlockType.GoldOre:
                    break;
                case BlockType.DiamondOre:
                    break;
                case BlockType.Planks:
                    break;
                case BlockType.CraftingTable:
                    break;
                case BlockType.Furnance:
                    break;
                case BlockType.Sand:
                    break;
            }
        }

        public void ProcessSprite(Foliage overlay, BlockType Id)
        {
            ProcessColor(overlay, Id);
        }

        public void ProcessSprite(Fluid overlay, BlockType Id)
        {
            ProcessColor(overlay, Id);
        }

        private void ProcessColor(SpriteOverlay overlay, BlockType Id)
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
                    overlay.color = new Color(170, 103, 0);
                    break;
                case BlockType.CraftingTable:
                    overlay.color = new Color(96, 101, 1);
                    break;
                case BlockType.Furnance:
                    overlay.color = new Color(255, 161, 114);
                    break;
                case BlockType.Water:
                    overlay.color = new Color(0, 255, 204);
                    break;
                case BlockType.Lava:
                    overlay.color = new Color(255, 0, 51);
                    break;
                case BlockType.Sand:
                    overlay.color = new Color(204, 255, 51);
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
        Planks,
        CraftingTable,
        Furnance,
        GoldBar,
        IronBar,
        Water,
        Sand,
        Lava,
        WoodPixaxe,
        WoodAxe,
        WoodShovel,
    }
}