from System.Reflection import Assembly
from System import Convert
code = Assembly.Load(Convert.FromBase64String(input[0]))

manager = code.CreateInstance("PixBlocks_Compatiblity_layer.StartUpScript",True);
manager.Init.Init();
"game."