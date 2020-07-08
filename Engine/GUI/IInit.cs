using System.Windows.Forms;

namespace Engine.GUI
{
    public interface IInit
    {
        void GenerateWorld(int seed, int size, ProgressBar progress);

        bool IsWorldGenerated { get; set; }
    }
}