using Engine.Engine.models;
using Engine.Logic;
using Engine.Resources;
using Engine.Saves.Models;
using System.IO;
using System.Xml.Serialization;

namespace Engine.Saves
{
    public class SaveManager
    {
        public SaveManager(ITileManager manager, PlayerStatus status, BlockConverter converter, Center center, IMover mover)
        {
            Manager = manager;
            Status = status;
            Converter = converter;
            Center = center;
            Mover = mover;
            Serializer = new XmlSerializer(typeof(Save));
        }

        public XmlSerializer Serializer { get; }
        public ITileManager Manager { get; }
        public PlayerStatus Status { get; }
        public BlockConverter Converter { get; }
        public Center Center { get; }
        public IMover Mover { get; }

        public void LoadFromStream(Stream stream)
        {
            var obj = Serializer.Deserialize(stream);
            LoadSave((Save)obj);
        }

        public void SaveToStream(Stream SaveDest)
        {
            var save = new Save();
             save.SetUp(Converter.Convert(Manager.World.GetAllThat(s => true)), Status.health, Status.Inventory, Center.position.x, Center.position.y);
            Serializer.Serialize(SaveDest, save);
        }

        public void LoadSaveFromFile(string path)
        {
            var stream = File.OpenRead(path);
             LoadFromStream(stream);
        }

        public void SaveToFile(string path)
        {
            var stream = File.OpenWrite(path);
            SaveToStream(stream);
            stream.Close();
        }

        private void LoadSave(Save save)
        {
            Status.LoadState(save.Hp, save.Items);
            foreach (var item in Converter.Convert(save.Tiles))
            {
                 Manager.World.SetBlock(new BlockData(
                    item.X+(save.CenterX/Parameters.BlockSize),
                    item.Y+(save.CenterY/Parameters.BlockSize),
                    item.Type
                    ));
            }
        }

        private void MoveScene(int X, int Y)
        {
            Mover.Move(roation.Left, X);
            Mover.Move(roation.Up, Y);
        }
    }
}