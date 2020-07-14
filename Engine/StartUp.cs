using Engine.Engine;
using Engine.GUI;
using Engine.Logic;
using Engine.Resources;
using Engine.Saves;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Windows.Forms;

namespace Engine
{
    public class StartUp : IInit
    {
        public bool IsWorldGenerated { get; set; } = false;
        private Engine.Engine engine;
        private TileManager tileManager;

        public void Init()
        {
            var drawer = new Drawer();
            var IdProcessor = new BlockIdProcessor();
            tileManager = new TileManager(drawer, IdProcessor);
            engine = new Engine.Engine(tileManager, drawer);
            var craftingSystem = new CraftingModule(Craftings.GetCraftings(),tileManager);
            var StatusWindow = new StatusDisplay(craftingSystem);
            var playerstatus = new PlayerStatus(StatusWindow);
            var blockConverter = new BlockConverter(drawer, IdProcessor);
            var game = GameScene.gameSceneStatic;
            var moveDefiner = new PlayerMoveDefiner();
            var SaveManager = new SaveManager(tileManager, playerstatus, blockConverter, engine.Center, engine);
            var pauseMenu = new PauseMenu(SaveManager);
            var pointerController = new PointerController(playerstatus, tileManager, moveDefiner,drawer);
            var player = new Player(pauseMenu, tileManager, pointerController, moveDefiner, playerstatus,drawer,engine);

            var MainMenu = new Main_Menu(this, SaveManager);
            MainMenu.ShowDialog();
            if (!IsWorldGenerated) return;
            engine.Add(pointerController);
            game.background = new Color(102, 51, 204);
            game.add(pointerController);
            game.add(player);
            game.start();
        }

        public void GenerateWorld(int seed, int size, ProgressBar progress)
        {
            IsWorldGenerated = true;
            var oreTable = new OreTable(OreResource.InitOreTable());

            var generator = new Generator(seed, tileManager, oreTable, size);
            ExecuteGeneration(generator, progress);
        }

        private void ExecuteGeneration(Generator generator, ProgressBar progress)
        {
            generator.GenerateTerrian();
            generator.GenerateWater();
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
        }
    }
}