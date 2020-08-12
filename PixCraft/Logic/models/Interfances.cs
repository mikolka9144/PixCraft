using Engine.Engine.models;
using Engine.Resources;
using System.Collections.Generic;

namespace Engine.Logic.models
{
    public interface IActiveElements
    {
        List<Block> GetActiveBlocks(Positon sprite);

        List<Foliage> GetActiveToppings(Positon sprite);

        List<Fluid> GetActiveFluids(Positon sprite);

        List<Block> VisiableBlocks { get; }
    }
    public interface INearbyBlockCheck
    {
        bool IsStationNearby(BlockType station);
    }
    public interface IStatusDisplayer
    {
        void Present( PlayerStatus currentItems);

        int SelectedIndex { get; }
    }
}