using System.Threading.Tasks;

namespace Engine.PixBlocks_Implementations
{
    public interface IPixSound
    {
        void PlaySound(SoundType soundType);
    }
    public interface ISounds
    {
        Task GetSound(SoundType soundType);
    }
}
