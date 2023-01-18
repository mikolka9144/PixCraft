namespace Engine.Logic
{
    public interface IPlayerStatusParameters
    {
        int LavaDamage { get; }
        int BaseHealth { get; }
        int MaxBreath { get; }
        int MaxSlotCapatility { get; }
        int minimumBlocksForFall { get; }
    }
}