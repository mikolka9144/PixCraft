using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
using Logic;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Logic
{
    public class StartUp:IInit
    {
        private bool IsWorldGenerated = false;
        private Engine.Engine engine;
        private Parameters parameters;
        private TileManager tileManager;

        public void Init()
        {
            parameters = new Parameters();
            var game = GameScene.gameSceneStatic;
            var IdProcessor = new BlockIdProcessor();
            var moveDefiner = new PlayerMoveDefiner();
            var StatusWindow = new StatusDisplay(parameters);
            engine = new Engine.Engine(parameters);
            tileManager = new TileManager(parameters, engine, IdProcessor);

            var playerstatus = new PlayerStatus(parameters, StatusWindow);
            var pointer = new Pointer(engine,parameters);
            var pointerController = new PointerController(playerstatus,pointer, engine,moveDefiner,parameters);
            var player = new Player(parameters,engine,engine,pointerController,moveDefiner,playerstatus);

            var MainMenu = new Main_Menu(this,parameters);
            MainMenu.ShowDialog();
            if (!IsWorldGenerated) return;
            game.background = new Color(102, 51, 204);
            game.add(pointerController);
            game.add(player);
            game.start();
        }

        public void GenerateWorld(int seed, int size, ProgressBar progress)
        {
            IsWorldGenerated = true;
            var oreTable = new OreTable();

            var generator = new Generator(seed, tileManager, parameters, oreTable,size,engine);
            ExecuteGeneration(generator,progress);

        }
        private void ExecuteGeneration(Generator generator,ProgressBar progress)
        {
            generator.GenerateTerrian();
            progress.Value = 25;
            generator.CreateUnderGround();
            progress.Value = 50;
            generator.GenerateTrees();
            progress.Value = 75;
            generator.GenerateOres(BlockType.CoalOre);
            generator.GenerateOres(BlockType.IronOre);
            generator.GenerateOres(BlockType.GoldOre);
            generator.GenerateOres(BlockType.DiamondOre);
            progress.Value = 100;
            generator.Render();
        }
    }
}
