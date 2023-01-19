"";import System.Reflection.Assembly as Assembly
"";import System.Convert as Convert
###  INSERT CODE HERE  ###



##########################
code = Assembly.Load(Convert.FromBase64String(bin))
manager = code.CreateInstance("PixBlocks_Compatiblity_layer.StartUpScript",True);
manager.Init.Init();
"game."