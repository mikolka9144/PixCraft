using Engine.Engine;
using Engine.GUI;
using Engine.Logic;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using Engine.Saves;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Windows.Forms;

using Sound = Engine.PixBlocks_Implementations.Sound;

namespace Engine
{
    public class StartUp : IInit
    {
        public bool IsWorldGenerated { get; set; } = false;
        private Engine.Engine engine;
        private TileManager tileManager;
        private Drawer Drawer;

        public void Init()
        {
            var Sound = new PixSound(new Sounds(new Sound()));
            Drawer = new Drawer();
            var IdProcessor = new BlockIdProcessor();
            tileManager = new TileManager(Drawer, IdProcessor);
            engine = new Engine.Engine(tileManager, Drawer);
            var craftingSystem = new CraftingModule(Craftings.GetCraftings(),tileManager);
            var StatusWindow = new StatusDisplay(craftingSystem);
            var playerstatus = new PlayerStatus(StatusWindow);
            var blockConverter = new BlockConverter(Drawer, IdProcessor);
            var game = GameScene.gameSceneStatic;
            var moveDefiner = new PlayerMoveDefiner();
            var SaveManager = new SaveManager(tileManager, playerstatus, blockConverter, engine.Center, engine);
            var pauseMenu = new PauseMenu(SaveManager);
            var pointerController = new PointerController(playerstatus, tileManager, moveDefiner,Drawer,Sound);
            var player = new Player(pauseMenu, tileManager, pointerController, moveDefiner, playerstatus,Drawer,engine,engine.Center,Sound);

            var MainMenu = new Main_Menu(this, SaveManager);
            MainMenu.ShowDialog();
            if (!IsWorldGenerated) return;
            engine.Add(pointerController);
            game.background = new Color(102, 51, 204);
            game.add(pointerController);
            game.add(player);
            Sound.PlaySound(SoundType.Music);
            game.start();
        }

        public void GenerateWorld(int seed, int size, ProgressBar progress)
        {
            IsWorldGenerated = true;
            var oreTable = new OreTable(OreResource.InitOreTable());

            var generator = new Generator(seed, tileManager, oreTable, size,Drawer);
            ExecuteGeneration(generator, progress);
        }

        private void ExecuteGeneration(Generator generator, ProgressBar progress)
        {
            generator.GenerateTerrian();
            generator.GenerateWater();
            progress.Value = 25;
            generator.GenerateTrees();
            progress.Value = 50;
            generator.CreateUnderGround();
            progress.Value = 75;
            generator.GenerateOres(BlockType.CoalOre);
            generator.GenerateOres(BlockType.IronOre);
            generator.GenerateOres(BlockType.GoldOre);
            generator.GenerateOres(BlockType.DiamondOre);
            generator.GenerateOres(BlockType.Lava);
            progress.Value = 100;
            generator.Render();
        }
    }
}