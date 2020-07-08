using Engine.Engine.models;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    internal class PointerController : Sprite
    {
        private readonly PlayerStatus status;
        private readonly IMoveDefiner moveDefiner;
        private Task ChangeStateOfPointerTask;
        private bool DestroyModeActive;

        public PointerController(PlayerStatus status, Pointer pointer, ITileManager engine, IMoveDefiner moveDefiner)
        {
            size = 0;
            this.status = status;
            Point = pointer;
            Engine = engine;
            this.moveDefiner = moveDefiner;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
        }

        public Pointer Point { get; }
        public ITileManager Engine { get; }
        public Foliage LastFoliage { get; set; }

        public override void update()
        {
            MovePointer(GameScene.gameSceneStatic.mouse.position);
            CheckBlocksOperations();
            if (moveDefiner.key(command.ChangeMouseState) && ChangeStateOfPointerTask.Status != TaskStatus.Running)
            {
                if (ChangeStateOfPointerTask.Status == TaskStatus.RanToCompletion) ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
                ChangeStateOfPointerTask.Start();
            }
            Point.image = IsInBreakingRange(Point) ? 56 : 55;
            if (!Point.IsVisible) ResetPointer();
            
        }

        private void ResetPointer()
        {
            for (int i = 0; i < 3; i++)
            {

                MovePointer(new Vector(0, 0));
            }
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
            foreach (var b in Engine.Blocks.FindAll(s => s.IsVisible))
            {
                if (Point.collide(b)) return;
            }
            var blockType = status.GetBlockToPlace();
            if (blockType != BlockType.None) Engine.PlaceBlock(Point.X, Point.Y, blockType);
        }

        private void DestroyBlock()
        {
            foreach (var b in Engine.Blocks.FindAll(s => s.IsVisible))
            {
                if (Point.collide(b))
                {
                    status.AddElement(new Item(1, b.Id));
                    Engine.RemoveTile(b);
                    break;
                }
            }
        }

        private void ChangeStateOfPointer()
        {
            DestroyModeActive = !DestroyModeActive;
            if (DestroyModeActive) Point.color = Parameters.RedColor;
            else Point.color = Parameters.DefaultColor;
            Thread.Sleep(Parameters.PointerStatusChangeDelay);
        }

        private void MovePointer(Vector MousePos)
        {
            var PointPos = Point;
            var Xlen = MousePos.x - PointPos.X;
            var Ylen = MousePos.y - PointPos.Y;
            var YtoMove = (int)(Ylen / 10) * 20;
            var XtoMove = (int)(Xlen / 10) * 20;

            bool IsNotInXZone = Point.X + XtoMove > Parameters.PointerRange || Point.X + XtoMove < -Parameters.PointerRange;
            bool IsNotInYZone = Point.Y + YtoMove > Parameters.PointerRange || Point.Y + YtoMove < -Parameters.PointerRange;
            if (!IsNotInXZone) Point.Move(roation.Right, XtoMove);
            if (!IsNotInYZone) Point.Move(roation.Up, YtoMove);
        }

        private bool IsInBreakingRange(SpriteOverlay point)
        {
            bool IsNotInRange = point.X > Parameters.breakingRange || point.X < -Parameters.breakingRange ||
                point.Y > Parameters.breakingRange || point.Y < -Parameters.breakingRange;
            return !IsNotInRange;
        }
    }
}