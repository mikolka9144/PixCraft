using Engine.Engine;
using Engine.Logic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Engine.Saves
{
    public class SaveManager
    {
        public SaveManager(ITileManager manager, PlayerStatus status)
        {
            Manager = manager;
            Status = status;
            Serializer = new BinaryFormatter();

        }
        public BinaryFormatter Serializer { get; }
        public ITileManager Manager { get; }
        public PlayerStatus Status { get; }

        public void LoadFromStream(Stream stream)
        {
            var obj = Serializer.Deserialize(stream);
            if (obj is Save) LoadSave((Save)obj);
        }
        public void SaveToStream(Stream SaveDest)
        {
            var save = new Save(Manager.Blocks, Status.health, Status.Inventory);
            Serializer.Serialize(SaveDest, save);
        }
        private void LoadSave(Save save)
        {
            Status.LoadState( save.Hp,save.Items);
            Manager.Blocks.AddRange(save.Tiles);
        }
    }
}
