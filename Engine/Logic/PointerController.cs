using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Engine.models
{
    internal class PointerController : Sprite
    {
        private readonly PlayerStatus status;
        private readonly IMoveDefiner moveDefiner;
        private readonly Parameters paramters;
        private Task ChangeStateOfPointerTask;
        private bool DestroyModeActive;

        public PointerController(PlayerStatus status, Pointer pointer, Engine engine, IMoveDefiner moveDefiner, Parameters paramters)
        {
            size = 0;
            this.status = status;
            Point = pointer;
            Engine = engine;
            this.moveDefiner = moveDefiner;
            this.paramters = paramters;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
            engine.Sprites.Add(pointer);
        }

        public Pointer Point { get; }
        public Engine Engine { get; }
        public Foliage LastFoliage { get; set; }

        public override void update()
        {
            MovePointer();
            CheckBlocksOperations();
            if (moveDefiner.key(command.ChangeMouseState) && ChangeStateOfPointerTask.Status != TaskStatus.Running)
            {
                if (ChangeStateOfPointerTask.Status == TaskStatus.RanToCompletion) ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
                ChangeStateOfPointerTask.Start();
            }
            Point.Sprite.image = IsInBreakingRange(Point) ? 56 : 55;
        }

        private void CheckBlocksOperations()
        {
            if (moveDefiner.key(command.Action) && IsInBreakingRange(Point))
            {
                if (DestroyModeActive)
                {
                    DestroyBlock();
                }
                else
                {
                    PlaceBlock();
                }
            }
        }

        private void PlaceBlock()
        {
            foreach (var b in Engine.Blocks.FindAll(s => s.Sprite.IsVisible))
            {
                if (Point.Sprite.collide(b.Sprite)) return;
            }
            var blockType = status.GetBlockToPlace();
            if (blockType != BlockType.None) Engine.AddBlockTile(Point.X, Point.Y, blockType, paramters.BlockSize, true);
        }

        private void DestroyBlock()
        {
            foreach (var b in Engine.Blocks.FindAll(s => s.Sprite.IsVisible))
            {
                if (Point.Sprite.collide(b.Sprite))
                {
                    status.AddElement(new Item(true, 1, b.Id));
                    Engine.RemoveTile(b);
                    break;
                }
            }
        }

        private void ChangeStateOfPointer()
        {
            DestroyModeActive = !DestroyModeActive;
            if (DestroyModeActive) Point.Sprite.color = new Color(255, 51, 0);
            else Point.Sprite.color = new Color(15, 142, 255);
            Thread.Sleep(paramters.PointerStatusChangeDelay);
        }

        private void MovePointer()
        {
            var MousePos = GameScene.gameSceneStatic.mouse.position;
            var PointPos = Point;
            var Xlen = MousePos.x - PointPos.X;
            var Ylen = MousePos.y - PointPos.Y;
            var YtoMove = (int)(Ylen / 10) * 20;
            var XtoMove = (int)(Xlen / 10) * 20;

            bool IsNotInXZone = Point.X + XtoMove > paramters.PointerRange || Point.X + XtoMove < -paramters.PointerRange;
            bool IsNotInYZone = Point.Y + YtoMove > paramters.PointerRange || Point.Y + YtoMove < -paramters.PointerRange;
            if (!IsNotInXZone) Point.Move(roation.Right, XtoMove);
            if (!IsNotInYZone) Point.Move(roation.Up, YtoMove);
        }

        private bool IsInBreakingRange(SpriteOverlay point)
        {
            bool IsNotInRange = point.X > paramters.breakingRange || point.X < -paramters.breakingRange ||
                point.Y > paramters.breakingRange || point.Y < -paramters.breakingRange;
            return !IsNotInRange;
        }
    }
}