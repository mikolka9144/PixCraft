using Engine.Engine.models;
using Integration;
using System;
using System.Collections.Generic;

namespace Engine.Resources
{
    public interface IIdProcessor
    {
        void ProcessSprite(LEDBlockTile overlay, BlockType Id);
        void ProcessSprite(Fluid overlay, BlockType Id);
    }

    public class BlockIdProcessor : IIdProcessor
    {
        private List<BlockType> MinableBlocks = new List<BlockType>() { BlockType.Stone};
        private List<BlockType> AxeableBlocks = new List<BlockType>() { BlockType.Wood};
        private List<BlockType> ShovelableBlocks = new List<BlockType>() { BlockType.Dirt};

        public void ProcessSprite(LEDBlockTile overlay, BlockType Id)
        {
            if(Id == BlockType.None){
                overlay.size = 0;
                return;
            }
            else
            {
                overlay.size = Parameters.BlockSize;
            }
            ProcessColor(overlay, Id);
            if (MinableBlocks.Contains(Id)) overlay.tool = ToolType.Pixaxe;
            if (ShovelableBlocks.Contains(Id)) overlay.tool = ToolType.Shovel;
            if (AxeableBlocks.Contains(Id)) overlay.tool = ToolType.Axe;
            ProcessDyrablity(overlay, Id);
            ProcessFluidabling(overlay,Id);
            ProcessRequirements(overlay);
        }

        private void ProcessFluidabling(LEDBlockTile overlay, BlockType id)
        {
            switch (id)
            {
                case BlockType.Water:
                    overlay.image = 88;
                    overlay.IsFluid = true;
                    return;
                case BlockType.Lava:
                    overlay.IsFluid = true;
                    overlay.image = 88;
                    return;
                default:
                    overlay.IsFluid = false;
                    overlay.image = 63;
                    return;
            }
        }

        private void ProcessRequirements(LEDBlockTile overlay)
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
                    overlay.MinimumPower = 15;
                    break;
                case BlockType.GoldOre:
                    overlay.MinimumPower = 15;
                    break;
                case BlockType.DiamondOre:
                    overlay.MinimumPower = 20;
                    break;
                case BlockType.Furnance:
                    overlay.MinimumPower = 10;
                    break;
            }
        }

        private void ProcessDyrablity(LEDBlockTile block,BlockType type)
        {
            block.Durablity = 20;
            switch (type)
            {
                case BlockType.Grass:
                    break;
                case BlockType.Dirt:
                    block.Durablity = 10;
                    break;
                case BlockType.Stone:
                    block.Durablity = 30;
                    break;
                case BlockType.Wood:
                    block.Durablity = 25;
                    break;
                case BlockType.Leaves:
                    block.Durablity = 5;
                    break;
                case BlockType.CoalOre:
                    block.Durablity = 40;
                    break;
                case BlockType.IronOre:
                    block.Durablity = 50;
                    break;
                case BlockType.GoldOre:
                    block.Durablity = 50;
                    break;
                case BlockType.DiamondOre:
                    block.Durablity = 50;
                    break;
                case BlockType.Planks:
                    block.Durablity = 25;
                    break;
                case BlockType.CraftingTable:
                    block.Durablity = 25;
                    break;
                case BlockType.Furnance:
                    block.Durablity = 30;
                    break;
                case BlockType.Sand:
                    break;
            }
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
        WoodSword,
        StoneSword,
        StoneAxe,
        StoneShovel,
        StonePixaxe,
        DiamondSword,
        DiamondAxe,
        DiamondShovel,
        DiamondPixaxe,
        GoldSword,
        GoldAxe,
        GoldShovel,
        GoldPixaxe,
        IronSword,
        IronAxe,
        IronShovel,
        IronPixaxe,
    }
}