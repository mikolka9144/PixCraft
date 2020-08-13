from System.Reflection import Assembly
from System import Convert
clr.AddReference('PixBlocks_Compatiblity_layer');
from PixBlocks_Compatiblity_layer import StartUpScript;

manager = StartUpScript();
manager.Init();
"game."