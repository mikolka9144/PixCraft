using Engine.PixBlocks_Implementations;

using System.Threading;
using System.Threading.Tasks;

namespace Engine.Resources
{
    public interface ISounds
    {
        Task GetSound(SoundType soundType);
    }

    public class Sounds : ISounds
    {
        private readonly ISound Sound;

        public Sounds(ISound sound)
        {
            Sound = sound;
        }

        public Task GetSound(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.Break:
                    return new Task(() => Play("e2", 10));
                case SoundType.Place:
                    return new Task(() => Play("e5", 10));
                case SoundType.Music:
                    return new Task(() => Play("m2", 0));
                case SoundType.Walking:
                    return new Task(() => Play("e5", 400));
                case SoundType.WaterEnter:
                    return new Task(() => Play("e20", 200));
                case SoundType.WaterExit:
                    return new Task(() => Play("e10", 200));
            }
            return null;
        }
        private void Play(string sound, int delay)
        {
            Sound.play(sound);
            Thread.Sleep(delay);
        }
    }
}
