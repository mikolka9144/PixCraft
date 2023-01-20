using Engine.Engine.models;
using Engine.Resources;
using System.Collections.Generic;

namespace Engine.Logic.models
{
    public interface IActiveElements
    {
        List<LEDBlockTile> GetActiveBlocks(Vector2 sprite);

        List<LEDBlockTile> GetActiveToppings(Vector2 sprite);

        List<LEDBlockTile> GetActiveFluids(Vector2 sprite);
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