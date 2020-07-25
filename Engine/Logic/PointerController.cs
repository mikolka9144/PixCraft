using Engine.Engine;
using Engine.Engine.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    public class PointerController : Pointer,IStoppableSpriteOverlay
    {
        private readonly PlayerStatus status;
        private readonly IMoveDefiner moveDefiner;
        private Task ChangeStateOfPointerTask;
        private bool DestroyModeActive;

        public PointerController(PlayerStatus status, ITileManager engine, IMoveDefiner moveDefiner,IDrawer drawer,IPixSound sound):base(drawer)
        {
            this.status = status;
            Tiles = engine;
            this.moveDefiner = moveDefiner;
            Sound = sound;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
        }

        public ITileManager Tiles { get; }
        public IPixSound Sound { get; }
        public bool Active { get; set; } = true;

        public override void update()
        {
            if (!Active) return;
            MovePointer(GameScene.gameSceneStatic.mouse.position);
            CheckBlocksOperations();
            ChangeState();
            image = IsInRange(Parameters.BreakingRange) ? 56 : 55;
            ResetPointer();
        }

        private void ChangeState()
        {
            if (moveDefiner.key(command.ChangeMouseState) && ChangeStateOfPointerTask.Status != TaskStatus.Running)
            {
                if (ChangeStateOfPointerTask.Status == TaskStatus.RanToCompletion) ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
                ChangeStateOfPointerTask.Start();
            }
        }

        private void ResetPointer()
        {
            if (!IsInRange(Parameters.PointerRange))
            {
                position = Tiles.VisiableBlocks.First().position;
            }
        }

        private void CheckBlocksOperations()
        {
            if (moveDefiner.key(command.Action) && IsInRange(Parameters.BreakingRange))
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
            foreach (var b in Tiles.VisiableBlocks)
            {
                if (collide(b)) return;
            }

            var blockType = status.GetBlockToPlace();
            if (blockType != BlockType.None)
            {
                Tiles.PlaceBlock(X, Y, blockType);
                RemoveOverlappingWater(); 
                Sound.PlaySound(SoundType.Place);
            }
        }

        private void RemoveOverlappingWater()
        {
            var fluidToRemove = Tiles.Fluids.Find(s => collide(s));
            if (fluidToRemove != null) Tiles.RemoveFluid(fluidToRemove);
        }

        private void DestroyBlock()
        {
            foreach (var b in Tiles.VisiableBlocks.FindAll(s => s.IsVisible))
            {
                if (collide(b))
                {
                    status.AddElement(new Item(1, b.Id));
                    Tiles.RemoveTile(b);
                    Sound.PlaySound(SoundType.Break);
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
    }
}