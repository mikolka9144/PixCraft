namespace BlockEngine
{
    public interface ITileManager
    {
        void Add(SpriteOverlay sprite);
        void AddBlockTile(int X, int Y, int Id, int size, bool SholdDraw);
        void LoadMap(string MapData);
        void RemoveTile(Block tile);
    }
}