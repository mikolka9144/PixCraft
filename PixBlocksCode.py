"";import System.Reflection.Assembly as Assembly
"";import System.Convert as Convert
clr.AddReference('PixBlocks_Compatiblity_layer');
from PixBlocks_Compatiblity_layer import StartUpScript;

manager = StartUpScript();
manager.Init();
"game."