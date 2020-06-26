using Engine.Engine.models;
using Engine.GUI;
using IronPython.Compiler.Ast;
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

        public void Init()
        {
            var parameters = new Paramters();
            engine = new Engine.Engine(parameters);
            var pointer = new Pointer(engine);
            var moveDefiner = new PlayerMoveDefiner();
            var pointerController = new PointerController(pointer, engine,moveDefiner);
            var player = new Player(engine,engine,pointerController,moveDefiner);
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
    }
}
