using Engine.Engine;
using Engine.Engine.models;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    internal class PointerController : Pointer
    {
        private readonly PlayerStatus status;
        private readonly IMoveDefiner moveDefiner;
        private Task ChangeStateOfPointerTask;
        private bool DestroyModeActive;

        public PointerController(PlayerStatus status, ITileManager engine, IMoveDefiner moveDefiner,IDrawer drawer):base(drawer)
        {
            this.status = status;
            Engine = engine;
            this.moveDefiner = moveDefiner;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
        }

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
            if(!IsInBreakingRange(this)) ResetPointer();
        }

        private void ResetPointer()
        {
            X = LastFoliage.Block.X;
            Y = LastFoliage.Block.Y + Parameters.BlockSize;
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
            foreach (var b in Engine.Blocks.FindAll(s => s.IsVisible))
            {
                if (collide(b)) return;
            }
            var blockType = status.GetBlockToPlace();
            if (blockType != BlockType.None) Engine.PlaceBlock(X,Y, blockType);
        }

        private void DestroyBlock()
        {
            foreach (var b in Engine.Blocks.FindAll(s => s.IsVisible))
            {
                if (collide(b))
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
            if (!IsNotInXZone) Move(roation.Right, XtoMove);
            if (!IsNotInYZone) Move(roation.Up, YtoMove);
        }

        private bool IsInBreakingRange(SpriteOverlay point)
        {
            bool IsNotInRange = point.X > Parameters.PointerRange || point.X < -Parameters.PointerRange ||
                point.Y > Parameters.PointerRange || point.Y < -Parameters.PointerRange;
            return !IsNotInRange;
        }
    }
}