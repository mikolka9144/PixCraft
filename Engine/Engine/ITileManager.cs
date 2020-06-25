using Engine.Engine.models;

namespace Engine.Engine
{
    public interface ITileManager
    {
        void Add(SpriteOverlay sprite);
        void AddBlockTile(double X, double Y, int Id, int size, bool SholdDraw);
        void LoadMap(string MapData);
        void RemoveTile(Block tile);
    }
}