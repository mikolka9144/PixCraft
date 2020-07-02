using Engine.Engine;
using Engine.Logic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Engine.Saves
{
    public class SaveManager
    {
        public SaveManager(Engine.Engine manager, PlayerStatus status,BlockConverter converter)
        {
            Manager = manager;
            Status = status;
            Converter = converter;
            Serializer = new XmlSerializer(typeof(Save));

        }
        public XmlSerializer Serializer { get; }
        public Engine.Engine Manager { get; }
        public PlayerStatus Status { get; }
        public BlockConverter Converter { get; }

        public Save LoadFromStream(Stream stream)
        {
            var obj = Serializer.Deserialize(stream);
            return (Save)obj;
        }
        public void SaveToStream(Stream SaveDest)
        {
            var save = new Save(); 
            save.SetUp(Converter.Convert(Manager.Blocks), Status.health, Status.Inventory,Manager.Center.X, Manager.Center.Y);
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

        private void LoadSave(Save save)
        {
            Status.LoadState( save.Hp,save.Items);
            foreach (var item in Converter.Convert(save.Tiles,save.CenterX,save.CenterY))
            {
                Manager.AddBlockTile(item, true);
            }
            Manager.MoveScene(save.CenterX/20*20 , -(save.CenterY / 20 * 20));
        }
    }
}
