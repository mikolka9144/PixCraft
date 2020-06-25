using Engine.Engine.models;
using Logic;
using PixBlocks.PythonIron.Tools.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    public class StartUp
    {
        public void Init(int timeout,int seed,int size)
        {
            var engine = new Engine.Engine(timeout);
            var pointer = new Pointer(engine);
            var pointerController = new PointerController(GameScene.gameSceneStatic, pointer, engine);
            var player = new Player(engine, pointerController,GameScene.gameSceneStatic);
            engine.CreateGenerator(seed,size);
            var game = GameScene.gameSceneStatic;
            game.add(pointerController);
            game.add(player);
            game.start();
        }
        public void Lock()
        {
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
