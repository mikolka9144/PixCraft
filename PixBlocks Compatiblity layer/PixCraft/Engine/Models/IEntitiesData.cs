using Engine.Engine;
using System.Collections.Generic;

namespace Engine.Logic
{
    public interface IEntitiesData
    {
        //List<IStoppableSpriteOverlay> Sprites { get; }
        List<IStoppableSpriteOverlay> entities { get; }
    }
}