using Engine.Engine.models;
using Engine.Resources;
using System.Collections.Generic;

namespace Engine.Logic.models
{
    public interface IActiveElements
    {
        List<Block> ActiveBlocks { get; }
        List<Foliage> ActiveToppings { get; }
        List<Fluid> ActiveFluids { get; }
        List<Block> VisiableBlocks { get; }
    }
    public interface INearbyBlockCheck
    {
        bool IsStationNearby(BlockType station);
    }
    public interface IStatusDisplayer
    {
        void Present(int life, PlayerStatus currentItems);

        int SelectedIndex { get; set; }
    }
}