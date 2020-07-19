using Engine.Engine;
using Engine.Engine.models;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    public class PointerController : Pointer
    {
        private readonly PlayerStatus status;
        private readonly IMoveDefiner moveDefiner;
        private Task ChangeStateOfPointerTask;
        private bool DestroyModeActive;

        public PointerController(PlayerStatus status, ITileManager engine, IMoveDefiner moveDefiner,IDrawer drawer):base(drawer)
        {
            this.status = status;
            Tiles = engine;
            this.moveDefiner = moveDefiner;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
        }

        public ITileManager Tiles { get; }

        public override void update()
        {
            MovePointer(GameScene.gameSceneStatic.mouse.position);
            CheckBlocksOperations();
            if (moveDefiner.key(command.ChangeMouseState) && ChangeStateOfPointerTask.Status != TaskStatus.Running)
            {
                if (ChangeStateOfPointerTask.Status == TaskStatus.RanToCompletion) ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
                ChangeStateOfPointerTask.Start();
            }
        }


        private void CheckBlocksOperations()
        {
            if (moveDefiner.key(command.Action) && IsInBreakingRange(this))
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
            foreach (var b in Tiles.Blocks.FindAll(s => s.IsVisible))
            {
                if (collide(b)) return;
            }

            RemoveOverlappingWater();
            var blockType = status.GetBlockToPlace();
            if (blockType != BlockType.None) Tiles.PlaceBlock(X, Y, blockType);
        }

        private void RemoveOverlappingWater()
        {
            var fluidToRemove = Tiles.Fluids.Find(s => collide(s));
            if (fluidToRemove != null) Tiles.RemoveFluid(fluidToRemove);
        }

        private void DestroyBlock()
        {
            foreach (var b in Tiles.Blocks.FindAll(s => s.IsVisible))
            {
                if (collide(b))
                {
                    status.AddElement(new Item(1, b.Id));
                    Tiles.RemoveTile(b);
                    break;
                }
            }
        }

        private void ChangeStateOfPointer()
        {
            DestroyModeActive = !DestroyModeActive;
            if (DestroyModeActive) color = Parameters.RedColor;
            else color = Parameters.DefaultColor;
            Thread.Sleep(Parameters.PointerStatusChangeDelay);
        }

        private void MovePointer(Vector MousePos)
        {
            var Xlen = MousePos.x - X;
            var Ylen = MousePos.y - Y;
            var YtoMove = (int)(Ylen / 10) * 20;
            var XtoMove = (int)(Xlen / 10) * 20;

            bool IsNotInXZone = X + XtoMove > Parameters.PointerRange || X + XtoMove < -Parameters.PointerRange;
            bool IsNotInYZone = Y + YtoMove > Parameters.PointerRange || Y + YtoMove < -Parameters.PointerRange;
            if (!IsNotInXZone) move(roation.Right, XtoMove);
            if (!IsNotInYZone) move(roation.Up, YtoMove);
        }

        private bool IsInBreakingRange(SpriteOverlay point)
        {
            bool IsNotInRange = point.X > Parameters.PointerRange || point.X < -Parameters.PointerRange ||
                point.Y > Parameters.PointerRange || point.Y < -Parameters.PointerRange;
            return !IsNotInRange;
        }
    }
}