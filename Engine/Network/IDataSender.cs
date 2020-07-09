using Engine.Resources;

namespace Engine.Network
{
    internal interface IDataSender
    {
        (int RelX, int RelY) BreakBlock();
        (int RelX, int RelY, BlockType type) PlaceBlock();
        void SendMove(command command);
        bool key(command command);
        void BreakBlock(int RelX, int RelY);
        void PlaceBlock(int RelX, int RelY, BlockType type);
    }
}