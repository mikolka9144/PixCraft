using Integration;

namespace Engine.PixBlocks_Implementations
{
    
    public class Sound : ISound
    {
        private PixBlocks.PythonIron.Tools.Integration.Sound SoundPlayer;

        public Sound()
        {
            SoundPlayer = new PixBlocks.PythonIron.Tools.Integration.Sound();
        }
        public void play(string sound)
        {
            SoundPlayer.play(sound);
        }
    }
}