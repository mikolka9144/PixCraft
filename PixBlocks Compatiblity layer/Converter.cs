using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixBlocks_Compatiblity_layer
{
    internal static class Converter
    {
        public static Color Convert(this Integration.Color color)
        {
            return new Color(color.r, color.g, color.b);
        }
    }
}
