using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.Engine.models
{
    internal class PointerController:Sprite
    {
        private readonly PlayerStatus status;
        private readonly IMoveDefiner moveDefiner;
        private readonly Parameters paramters;

        public PointerController(PlayerStatus status,Pointer pointer,Engine engine,IMoveDefiner moveDefiner,Parameters paramters)
        {
            size = 0;
            this.status = status;
            point = pointer;
            Engine = engine;
            this.moveDefiner = moveDefiner;
            this.paramters = paramters;
            engine.Sprites.Add(pointer);
        }
        public Pointer point { get; }
        public Engine Engine { get; }
        public Foliage LastFoliage { get; set; }

        public override void update()
        {
            bool IsNotInRange = point.X > paramters.breakingRange || point.X < -paramters.breakingRange ||
                point.Y > paramters.breakingRange || point.Y < -paramters.breakingRange;

            MovePointer();

            if (moveDefiner.key(command.BreakBlock) && !IsNotInRange)
            {
                foreach (var b in Engine.ActiveBlocks)
                {

                    if (this.point.Sprite.collide(b.Sprite))
                    {
                        status.AddElement(new Item(true, 1, b.Id));
                        Engine.RemoveTile(b);
                        break;
                    }
                }
            }
            else if (moveDefiner.key(command.PlaceBlock) && !IsNotInRange)
            {
                foreach (var b in Engine.ActiveBlocks)
                {
                    if (point.Sprite.collide(b.Sprite)) return;
                }
                var blockType = status.GetBlockToPlace();
                if (blockType != BlockType.None) Engine.AddBlockTile(point.X, point.Y, blockType, 20, true);
            }
            if (IsNotInRange)
            {
                point.Sprite.image = 55;
            }
            else
            {
                point.Sprite.image = 56;
            }
        }

        private void MovePointer()
        {
            var MousePos = GameScene.gameSceneStatic.mouse.position;
            var PointPos = point;
            var Xlen = MousePos.x - PointPos.X;
            var Ylen = MousePos.y - PointPos.Y;
            point.Move(roation.Up, (int)(Ylen / 10) * 20);
            point.Move(roation.Right, (int)(Xlen / 10) * 20);
        }
    }
}