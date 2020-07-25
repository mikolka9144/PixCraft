using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
using Engine.Logic;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using Engine.Saves;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using MainMenu = Engine.GUI.MainMenu;
using Sound = Engine.PixBlocks_Implementations.Sound;

namespace Engine
{
    public class StartUp
    {
        private static SaveManager SaveManager;

        public void Init()
        {
            var game = GameScene.gameSceneStatic;
            var MainMenu = new MainMenu();
            MainMenu.Show();
            game.start();

           
            
        }

        private static void ConfigureDependencies(out PixSound Sound, out PointerController pointerController, out Player player,out Generator generator,out Engine.Engine engine)
        {
            Sound = new PixSound(new Sounds(new Sound()));
            var Drawer = new Drawer();
            var IdProcessor = new BlockIdProcessor();
            var tileManager = new TileManager(Drawer, IdProcessor);
            engine = new Engine.Engine(tileManager, Drawer);
            var craftingSystem = new CraftingModule(Craftings.GetCraftings(), tileManager);
            var StatusWindow = new StatusDisplay(craftingSystem);
            var playerstatus = new PlayerStatus(StatusWindow);
            var blockConverter = new BlockConverter(Drawer, IdProcessor);
            var moveDefiner = new PlayerMoveDefiner();
            SaveManager = new SaveManager(tileManager, playerstatus, blockConverter, engine.Center, engine);
            var pauseMenu = new PauseForm(engine,SaveManager);
            var oreTable = new OreTable(OreResource.InitOreTable());
            pointerController = new PointerController(playerstatus, tileManager, moveDefiner, Drawer, Sound);
            player = new Player(pauseMenu, tileManager, pointerController, moveDefiner, playerstatus, Drawer, engine, engine.Center, Sound);
            generator = new Generator(tileManager, oreTable, Drawer);
        }

        internal static void InitGame(string text)
        {
            PixSound Sound;
            PointerController pointerController;
            Player player;
            Engine.Engine engine;
            ConfigureDependencies(out Sound, out pointerController, out player, out _, out engine);           
            SaveManager.LoadSaveFromFile(text);

            Start(Sound, pointerController, player, engine);
        }

        internal static void InitGame(int size, int seed)
        {
            PixSound Sound;
            PointerController pointerController;
            Player player;
            Generator generator;
            Engine.Engine engine;
            ConfigureDependencies(out Sound, out pointerController, out player,out generator,out engine);
            generator.GenerateWorld(seed, size);

            Start(Sound,pointerController,player,engine);
        }

        private static void Start(PixSound Sound, PointerController pointerController, Player player,Engine.Engine engine)
        {
            var game = GameScene.gameSceneStatic;
            engine.Add(pointerController);
            game.background = new Color(102, 51, 204);

            engine.Render();

            engine.Add(player);
            player.move(roation.Up, 0);
            Sound.PlaySound(SoundType.Music);
        }
        
    }
}