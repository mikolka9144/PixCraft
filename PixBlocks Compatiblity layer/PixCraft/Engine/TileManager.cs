using Engine.Engine.models;
using Engine.Logic;
using Engine.Logic.models;
using Engine.Resources;
using Integration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Engine
{
    public class TileManager :GenericSprite,ITileManager,INearbyBlockCheck
    {
        public List<LEDBlockTile> LEDBlocks {get;} = new List<LEDBlockTile>(100);
        public World World { get; } = new World();
        public ITileManagerParameters parameters { get; }

        private readonly IDrawer drawer;
        private readonly IIdProcessor processor;

        public TileManager(IDrawer drawer, IIdProcessor processor,ITileManagerParameters parameters)
        {
            IsInvisible = true;
            this.drawer = drawer;
            this.processor = processor;
            this.parameters = parameters;
        }

        public void populateBoard()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    LEDBlocks.Add(new LEDBlockTile(100-(x*20),100-(y*20), World.GetBlock(5-x,5-y),drawer,processor));
                }
            }
        }

        public void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false)
        {
            int x = Parameters.BlockSize;
            var currentBlock = World.GetBlock(BlockX,BlockY);
            if (currentBlock != null)
            {
                if (replace)
                {
                    
                    World.RemoveBlock(currentBlock);
                }
                else
                {
                    return;
                }
            }
            else if (forceReplace)
            {
                return;
            }

            AddBlockTile(BlockX, BlockY, Id);
        }

        public void AddBlockTile(int BlockX, int BlockY, BlockType Id)
        {
            var x = Parameters.BlockSize;
            World.SetBlock(BlockX,BlockY,Id);
            foreach (var led in LEDBlocks)
            {
                if(led.Data.X == BlockX && led.Data.Y == BlockY)
                {
                    led.morphInto(World.GetBlock(led.Data.X,led.Data.Y),processor);
                }
            }
        }

        public override void update()
        {
            base.update();
            foreach (var led in LEDBlocks)
            {
                
                    var IsNotInLeftBorder = led.position.x < -parameters.border.Left;
                    var IsNotInRightBorder =  led.position.x > parameters.border.Right; 
                    var IsNotInUpBorder = led.position.y > parameters.border.Up; 
                    var IsNotInDownBorder = led.position.y < -parameters.border.Down;

                    if (IsNotInUpBorder)
                    {
                        led.morphInto(World.GetBlock(led.Data.X,led.Data.Y-10),processor);
                        led.move(roation.Down,Parameters.BlockSize*10);
                    }
                    else if (IsNotInDownBorder)
                    {
                        led.morphInto(World.GetBlock(led.Data.X,led.Data.Y+10),processor);
                        led.move(roation.Up,Parameters.BlockSize*10);
                    }
                    else if (IsNotInLeftBorder)
                    {
                        led.morphInto(World.GetBlock(led.Data.X+10,led.Data.Y),processor);
                        led.move(roation.Right,Parameters.BlockSize*10);
                    }
                    else if (IsNotInRightBorder)
                    {
                        led.morphInto(World.GetBlock(led.Data.X-10,led.Data.Y),processor);
                        led.move(roation.Left,Parameters.BlockSize*10);
                    }
                
            }
            
        }
        public void RemoveTile(LEDBlockTile tile)
        {
            World.RemoveBlock(tile.Data);
            tile.morphInto(World.GetBlock(tile.Data.X,tile.Data.Y),processor);
        }

        public bool IsStationNearby(BlockType station)
        {
            if (station == BlockType.None) return true;
            return GetActiveBlocks(new Vector2(0,0)).Any(s => s.Id == station);
        }

        
        
        public List<LEDBlockTile> GetActiveBlocks(Vector2 sprite)
        {
            return LEDBlocks.FindAll(s => s.Data.Type != BlockType.None).FindAll(s => s.IsInRange(parameters.hitboxArea, sprite) && s.position.y > parameters.blockTypeBorder + sprite.y);
        }
        public List<LEDBlockTile> GetActiveToppings(Vector2 sprite)
        {
            return LEDBlocks.FindAll(s => s.Data.Type != BlockType.None).FindAll(s => s.IsInRange(parameters.hitboxArea, sprite) && s.position.y <= parameters.blockTypeBorder+sprite.y);
        }

        public List<LEDBlockTile> GetActiveFluids(Vector2 sprite)
        {
            //return Fluids.FindAll(s => s.IsInRange(parameters.hitboxArea,sprite)).ToList();
            return LEDBlocks.FindAll(s => s.IsInRange(parameters.hitboxArea,sprite)
            &&
                s.Data.Type == BlockType.Lava || 
                s.Data.Type == BlockType.Water)
            .ToList();
        }
    }
}