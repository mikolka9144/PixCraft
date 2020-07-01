using System.IO;

namespace Engine.Saves
{
    public interface IFileManager
    {
        Stream GetFileStream(string path);
    }
}