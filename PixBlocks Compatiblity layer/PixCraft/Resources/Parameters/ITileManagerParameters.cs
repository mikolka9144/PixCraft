namespace Engine.Engine
{
    public interface ITileManagerParameters:IDrawerParameters
    {
        int hitboxArea { get; }
        int blockTypeBorder { get; }
    }
}