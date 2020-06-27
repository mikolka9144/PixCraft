using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
using Logic;
using PixBlocks.PythonIron.Tools.Game;

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
            var game = GameScene.gameSceneStatic;
            var IdProcessor = new BlockIdProcessor();
            var moveDefiner = new PlayerMoveDefiner();

            parameters = new Parameters();
            engine = new Engine.Engine(parameters);
            tileManager = new TileManager(parameters, engine, IdProcessor);

            var pointer = new Pointer(engine);
            var pointerController = new PointerController(pointer, engine,moveDefiner);
            var player = new Player(parameters,engine,engine,pointerController,moveDefiner);

            var MainMenu = new Main_Menu(this,parameters);
            MainMenu.ShowDialog();
            if (!IsWorldGenerated) return;
            game.add(pointerController);
            game.add(player);
            game.start();
        }

        public void GenerateWorld(int seed, int size)
        {
            IsWorldGenerated = true;
            var oreTable = new OreTable();

            var generator = new Generator(seed, tileManager, parameters, oreTable,size,engine);
            ExecuteGeneration(generator);

        }
        private void ExecuteGeneration(Generator generator)
        {
            generator.GenerateTerrian();
            generator.CreateUnderGround();
            generator.GenerateTrees();
            generator.GenerateOres(BlockType.Leaves);
            generator.Render();
        }
    }
}
