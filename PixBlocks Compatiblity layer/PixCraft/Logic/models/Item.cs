using Engine.Resources;

namespace Engine.Logic
{
    public class Item
    {
        public Item(int count, BlockType type)
        {
            var Properties = BlockPropertiesData.GetProperties(type);
            CanStack = Properties.CanStack;
            IsPlaceable = Properties.IsPlaceAble;
            TooltType = Properties.type;
            Power = Properties.power;
            Durablity = Properties.durablity;
            Count = count;
            Type = type;
        }

        public Item()
        {
        }

        public bool CanStack { get; set; }
        public bool IsPlaceable { get; set; }
        public int Count { get; set; }
        public BlockType Type { get; set; }
        public ToolType TooltType { get; set; }
        public int Power { get; set; }
        public int Durablity { get; set; }
        public string Name { get => Type.ToString(); }

        public bool Compare(Item item)
        {
            return item.Type == Type;
        }
        public override string ToString() => $"{Name} X:{Count}";

        internal Item Duplicate()
        {
            return MemberwiseClone() as Item;
        }
    }
}