using Engine.Engine;
using Engine.Engine.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using Integration;
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
        private LEDBlockTile blockToBreak;

        public PointerController(PlayerStatus status, ITileManager engine, IMoveDefiner moveDefiner,IDrawer drawer,IPixSound sound,IPointerControllerParameters parameters,IEntitiesData entities,IMouse mouse):base(drawer)
        {
            this.status = status;
            Tiles = engine;
            this.moveDefiner = moveDefiner;
            Sound = sound;
            Parameters = parameters;
            Entities = entities;
            Mouse = mouse;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
        }

        public ITileManager Tiles { get; }
        public IPixSound Sound { get; }
        public IPointerControllerParameters Parameters { get; }
        public IEntitiesData Entities { get; }
        public IMouse Mouse { get; }
        public bool Active { get; set; } = true;

        public override void update()
        {
            if (!Active) return;
            MovePointer(Mouse.position);
            CheckBlocksOperations();
            ChangeState();
            image = IsInRange(Parameters.BreakingRange) ? 56 : 55;
        }

        private void ChangeState()
        {
            if (moveDefiner.key(command.ChangeMouseState) && ChangeStateOfPointerTask.Status != TaskStatus.Running)
            {
                if (ChangeStateOfPointerTask.Status == TaskStatus.RanToCompletion) ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
                ChangeStateOfPointerTask.Start();
            }
        }

        public void ResetPointer()
        {
            if (!IsInRange(Parameters.PointerRange))
            {
                position = Tiles.LEDBlocks.First().position.Clone();
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

            foreach (var b in Tiles.LEDBlocks)
            {
                if (CollideSystem.collide(b,this) && b.Data.Type == BlockType.None){
                    Tiles.AddBlockTile(b.Data.X,b.Data.Y,blockType.Type);
                    status.Decrement(blockType.Type, 1);
                    Sound.PlaySound(SoundType.Place);
                    return;
                }
            }
            
        }

        private void DestroyBlock()
        {
            var blockType = status.GetItem();
            if (blockType.TooltType == ToolType.Sword) DamageMonster(blockType);
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
            foreach (var b in Tiles.LEDBlocks)
            {
                if (CollideSystem.collide(b,this) && b.Data.Type != BlockType.None)
                {
                    blockToBreak = b;
                    BreakingTicks++;
                    break;
                }
            }
        }

        private void DamageMonster(Item blockType)
        {
            foreach (var item  in Entities.entities)
            {
                var entity = item as MovableObject;
                if (entity.Collide(this,20)) 
                { 
                    entity.DealAttackDamage(blockType.Power);
                    DamageTool(blockType);
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

        private void MovePointer(Vector2 MousePos)
        {
            var Xlen = MousePos.x - position.x;
            var Ylen = MousePos.y - position.y;
            var YtoMove = (int)(Ylen / 10) * 20;
            var XtoMove = (int)(Xlen / 10) * 20;

            bool IsNotInXZone = position.x + XtoMove > Parameters.PointerRange || position.x + XtoMove < -Parameters.PointerRange;
            bool IsNotInYZone = position.y + YtoMove > Parameters.PointerRange || position.y + YtoMove < -Parameters.PointerRange;
            if (!IsNotInXZone) move(roation.Right, XtoMove);
            if (!IsNotInYZone) move(roation.Up, YtoMove);
        }
    }
}