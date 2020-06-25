using Engine.Engine.models;
using Engine.GUI;
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
    public class StartUp:IInit
    {
        private bool IsWorldGenerated = false;
        private Engine.Engine engine;

        public void Init(int timeout)
        {
            engine = new Engine.Engine(timeout);
            var pointer = new Pointer(engine);
            var pointerController = new PointerController(GameScene.gameSceneStatic, pointer, engine);
            var player = new Player(engine, pointerController,GameScene.gameSceneStatic);
            var game = GameScene.gameSceneStatic;

            var MainMenu = new Main_Menu(this);
            MainMenu.ShowDialog();
            if (!IsWorldGenerated) return;
            game.add(pointerController);
            game.add(player);
            game.start();
        }

        public void InitWithParameters(int seed, int size)
        {
            IsWorldGenerated = true;
            engine.CreateGenerator(seed,size);

        }

        public void Lock()
        {
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
