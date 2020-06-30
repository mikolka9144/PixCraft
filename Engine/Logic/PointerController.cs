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
            point = pointer;
            Engine = engine;
            this.moveDefiner = moveDefiner;
            this.paramters = paramters;
            ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
            engine.Sprites.Add(pointer);
        }
        public Pointer point { get; }
        public Engine Engine { get; }
        public Foliage LastFoliage { get; set; }

        public override void update()
        {
            

            MovePointer();
            if (moveDefiner.key(command.Action) && IsInBreakingRange(point))
            {

                if (DestroyModeActive)
                {
                    foreach (var b in Engine.Blocks.FindAll(s => s.IsRendered))
                    {

                        if (point.Sprite.collide(b.Sprite))
                        {
                            status.AddElement(new Item(true, 1, b.Id));
                            Engine.RemoveTile(b);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var b in Engine.Blocks.FindAll(s => s.IsRendered))
                    {
                        if (point.Sprite.collide(b.Sprite)) return;
                    }
                    var blockType = status.GetBlockToPlace();
                    if (blockType != BlockType.None) Engine.AddBlockTile(point.X, point.Y, blockType, paramters.BlockSize, true);
                }
            }
            if (moveDefiner.key(command.ChangeMouseState)&& ChangeStateOfPointerTask.Status != TaskStatus.Running)
            {
                if (ChangeStateOfPointerTask.Status == TaskStatus.RanToCompletion) ChangeStateOfPointerTask = new Task(ChangeStateOfPointer);
                ChangeStateOfPointerTask.Start();
            }
            point.Sprite.image = IsInBreakingRange(point) ? 56 : 55;
        }

        private void ChangeStateOfPointer()
        {
            DestroyModeActive = !DestroyModeActive;
            if (DestroyModeActive) point.Sprite.color = new Color(255, 51, 0);
            else point.Sprite.color = new Color(15, 142, 255);
            Thread.Sleep(paramters.PointerStatusChangeDelay);
        }

        private void MovePointer()
        {

            var MousePos = GameScene.gameSceneStatic.mouse.position;
            var PointPos = point;
            var Xlen = MousePos.x - PointPos.X;
            var Ylen = MousePos.y - PointPos.Y;
            var YtoMove = (int)(Ylen / 10) * 20;
            var XtoMove = (int)(Xlen / 10) * 20;

            bool IsNotInPointerZone = point.X + XtoMove > paramters.PointerRange || point.X + XtoMove < -paramters.PointerRange ||
                point.Y + YtoMove > paramters.PointerRange || point.Y + YtoMove < -paramters.PointerRange;
            if (!IsNotInPointerZone)
            {

                point.Move(roation.Up, YtoMove);
                point.Move(roation.Right, XtoMove);
            }
        }
        private bool IsInBreakingRange(SpriteOverlay point)
        {
            bool IsNotInRange = point.X > paramters.breakingRange || point.X < -paramters.breakingRange ||
                point.Y > paramters.breakingRange || point.Y < -paramters.breakingRange;
            return !IsNotInRange;
        }
    }
}