using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
using Engine.Logic;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using Engine.Saves;
using System;
using Integration;
using System.Threading;
using MainMenu = Engine.GUI.MainMenu;

namespace Engine
{
    public class StartUp
    {
        private static SaveManager SaveManager;

        public IGameScene GameScene { get; }
        public IMouse Mouse { get; }
        public Engine.Engine engine { get; }
        public PointerController pointerController { get; }
        internal Player player { get; }
        internal MobSpawner MobSpawner { get; }
        public IPixSound Sound { get; }
        internal Drawer Drawer { get; }
        internal Generator Generator { get; }

        public StartUp(IGameScene gameScene,IMouse mouse,ISound sound)
        {
            GameScene = gameScene;
            Mouse = mouse;
            var parameters = new Parameters();
            Sound = new PixSound(new Sounds(sound));
            Drawer = new Drawer(parameters,gameScene);
            var IdProcessor = new BlockIdProcessor();
            var tileManager = new TileManager(Drawer, IdProcessor, parameters);
            engine = new Engine.Engine(tileManager, Drawer);
            var craftingSystem = new CraftingModule(Craftings.GetCraftings(), tileManager);
            var StatusWindow = new InventoryForm(craftingSystem, engine,mouse,Drawer,gameScene);
            var playerstatus = new PlayerStatus(StatusWindow, parameters);
            var blockConverter = new BlockConverter(Drawer, IdProcessor);
            var moveDefiner = new PlayerMoveDefiner(gameScene,mouse);
            SaveManager = new SaveManager(tileManager, playerstatus, blockConverter, engine.Center, engine);
            var pauseMenu = new PauseForm(engine, SaveManager,mouse,Drawer,gameScene);
            var oreTable = new OreTable(OreResource.InitOreTable());
            pointerController = new PointerController(playerstatus, tileManager, moveDefiner, Drawer, Sound, parameters, engine,mouse);
            player = new Player(pauseMenu, tileManager, moveDefiner, playerstatus, Drawer, engine, Sound, parameters,gameScene);
            MobSpawner = new MobSpawner(engine, tileManager, Drawer, Sound, player);
            Generator = new Generator(tileManager, oreTable, Drawer, parameters);
        }
        private void ShowMainMenu()
        {
            var MainMenu = new MainMenu(Mouse,Drawer,GameScene,this);
            MainMenu.Show();
            GameScene.start();     
        }
        public void Init()
        {
            try
            {
                ShowMainMenu();
            }
            catch (Exception ex)
            {
                if (ex is ThreadInterruptedException) return;
                GameScene.ShowError(ex);              
            }
        }

        


        internal void InitGame(string text)
        {
            SaveManager.LoadSaveFromFile(text);

            Start();
        }

        internal void InitGame(int size, int seed)
        {
            Generator.GenerateWorld(seed, size);

            Start();
        }

        private void Start()
        {
            engine.Add(pointerController);
            
            GameScene.background = new Color(102, 51, 204);

            engine.Render();

            engine.Add(player);
            player.move(roation.Up, 0);
            Sound.PlaySound(SoundType.Music);
        }
        
    }
}