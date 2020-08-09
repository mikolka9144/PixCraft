using Engine.Engine;
using Engine.Engine.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
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
        private int BreakingTicks;
        private Block blockToBreak;

        public PointerController(PlayerStatus status, ITileManager engine, IMoveDefiner moveDefiner,IDrawer drawer,IPixSound sound,IPointerControllerParameters parameters):base(drawer)
        {
            this.status = status;
            Tiles = engine;
            this.moveDefiner = moveDefiner;
            Sound = sound;
            Parameters = parameters;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
        }

        public ITileManager Tiles { get; }
        public IPixSound Sound { get; }
        public IPointerControllerParameters Parameters { get; }
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
                    return;
                }
                else
                {
                    PlaceBlock();
                }
            }
            BreakingTicks = 0;
        }

        private void PlaceBlock()
        {
            var blockType = status.GetItem();
            if (blockType is null) return;
            if (!blockType.IsPlaceable) return;

            foreach (var b in Tiles.VisiableBlocks)
            {
                if (collide(b)) return;
            }
            Tiles.PlaceBlock(Position.X, Position.Y, blockType.type);
            status.Decrement(blockType.type, 1);
            RemoveOverlappingWater();
            Sound.PlaySound(SoundType.Place);
        }

        private void RemoveOverlappingWater()
        {
            var fluidToRemove = Tiles.Fluids.Find(s => collide(s));
            if (fluidToRemove != null) Tiles.RemoveFluid(fluidToRemove);
        }

        private void DestroyBlock()
        {
            var blockType = status.GetItem();
            if(BreakingTicks > 0)
            {
                if (blockToBreak.tool == blockType.TooltType) BreakingTicks += blockType.Power;
                else BreakingTicks += 1;

                if (BreakingTicks>= blockToBreak.Durablity)
                {
                    CheckMinPower(blockType);
                    Tiles.RemoveTile(blockToBreak);
                    Sound.PlaySound(SoundType.Break);
                    DamageTool(blockType);
                    BreakingTicks = 0;
                    return;
                }
            }
            foreach (var b in Tiles.VisiableBlocks)
            {
                if (collide(b))
                {
                    blockToBreak = b;
                    BreakingTicks++;
                    break;
                }
            }
        }

        private void CheckMinPower(Item blockType)
        {
            if(blockToBreak.MinimumPower != 0)
            {
                if (blockToBreak.tool != blockType.TooltType || blockToBreak.MinimumPower > blockType.Power) return;
            }
            status.AddElement(new Item(1, blockToBreak.Id));
        }

        private void DamageTool(Item blockType)
        {
            if (blockType.TooltType == ToolType.None) return;
            if (blockType != null) blockType.Durablity--;
            else return;
            if (blockType.Durablity <= 0) status.Inventory.Remove(blockType);
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
            var Xlen = MousePos.x - Position.X;
            var Ylen = MousePos.y - Position.Y;
            var YtoMove = (int)(Ylen / 10) * 20;
            var XtoMove = (int)(Xlen / 10) * 20;

            bool IsNotInXZone = Position.X + XtoMove > Parameters.PointerRange || Position.X + XtoMove < -Parameters.PointerRange;
            bool IsNotInYZone = Position.Y + YtoMove > Parameters.PointerRange || Position.Y + YtoMove < -Parameters.PointerRange;
            if (!IsNotInXZone) move(roation.Right, XtoMove);
            if (!IsNotInYZone) move(roation.Up, YtoMove);
        }
    }
}