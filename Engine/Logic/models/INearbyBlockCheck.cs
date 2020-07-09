using Engine.Resources;

namespace Engine.Logic
{
    public interface INearbyBlockCheck
    {
        bool IsStationNearby(BlockType station);
    }
}