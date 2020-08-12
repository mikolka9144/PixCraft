using System;

namespace Engine.GUI.Models
{
    [Serializable]
    public class WorldEntry
    {
        public WorldEntry(string name, string Guid)
        {
            Name = name;
            this.Guid = Guid;
        }

        public WorldEntry()
        {
        }

        public string Name { get; set; }
        public string Guid { get; set; }
    }
}