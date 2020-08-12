using System;

namespace Integration
{
    public interface IGameScene
    {
        Color background { get; set; }

        void start();
        void ShowError(Exception ex);
        string GetInput(string v);
        bool key(string v);
        void add(GenericSprite sprite);
        void remove(GenericSprite sprite);
        void stop();
        void ShowMessage(string v);
    }
}
