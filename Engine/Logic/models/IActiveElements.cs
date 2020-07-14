using Engine.Engine.models;
using System.Collections.Generic;

namespace Engine.Logic
{
    public interface IActiveElements
    {
        List<Block> ActiveBlocks { get; }
        List<Foliage> ActiveToppings { get; }
        List<Fluid> ActiveFluids { get; }
    }
}