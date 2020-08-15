using Engine.Engine.models;
using Engine.Resources;
using System.Collections.Generic;

namespace Engine.Logic.models
{
    public interface IActiveElements
    {
        List<Block> GetActiveBlocks(Vector2 sprite);

        List<Block> GetActiveToppings(Vector2 sprite);

        List<Fluid> GetActiveFluids(Vector2 sprite);

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