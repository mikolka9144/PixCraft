namespace Engine.PixBlocks_Implementations
{
    public interface ISound
    {
        void play(string sound);
    }
    internal class Sound : ISound
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