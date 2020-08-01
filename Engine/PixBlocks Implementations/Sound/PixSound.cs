using Engine.Resources;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.PixBlocks_Implementations
{
    public interface IPixSound
    {
        void PlaySound(SoundType soundType);
    }

    public class PixSound : IPixSound
    {
        public PixSound(ISounds staticSoundPlayTable)
        {
            SoundEngine = staticSoundPlayTable;
        }
        public ISounds SoundEngine { get; }
        private Dictionary<SoundType, Task> soundPlayTable = new Dictionary<SoundType, Task>();


        public void PlaySound(SoundType soundType)
        {
            if (!soundPlayTable.ContainsKey(soundType))
                soundPlayTable.Add(soundType, SoundEngine.GetSound(soundType));

            var taskToRun = soundPlayTable[soundType];
            if (taskToRun.IsCompleted)
            {
                soundPlayTable[soundType] = SoundEngine.GetSound(soundType);
                taskToRun = soundPlayTable[soundType];
            }
            if (taskToRun.Status == TaskStatus.Created)
            {
                taskToRun.Start();
            }
        }
    }
}
