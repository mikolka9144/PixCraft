using Engine.Engine.models;
using Engine.Logic;
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

        public Save LoadFromStream(Stream stream)
        {
            var obj = Serializer.Deserialize(stream);
            return (Save)obj;
        }

        public void SaveToStream(Stream SaveDest)
        {
            var save = new Save();
            save.SetUp(Converter.Convert(Manager.Blocks),Converter.Convert(Manager.Fluids), Status.health, Status.Inventory, Center.X, Center.Y);
            Serializer.Serialize(SaveDest, save);
        }

        public Save LoadFromFile(string path)
        {
            var stream = File.OpenRead(path);
            return LoadFromStream(stream);
        }

        public void SaveToFile(string path)
        {
            var stream = File.OpenWrite(path);
            SaveToStream(stream);
            stream.Close();
        }

        public void LoadSave(Save save)
        {
            Status.LoadState(save.Hp, save.Items);
            foreach (var item in Converter.Convert(save.Tiles, save.CenterX, save.CenterY))
            {
                Manager.AddBlockTile(item, false);
            }
            foreach (var item in Converter.Convert(save.Fluids, save.CenterX, save.CenterY))
            {
                Manager.AddFluid(item);
            }
            MoveScene(save.CenterX / 20 * 20, -(save.CenterY / 20 * 20));
        }

        private void MoveScene(int X, int Y)
        {
            Mover.Move(roation.Right, X);
            Mover.Move(roation.Down, Y);
        }
    }
}