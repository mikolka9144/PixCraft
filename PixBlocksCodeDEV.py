"";System.Reflection.Assembly as Assembly
"";System.Convert as Convery
code = Assembly.LoadFile(input[0])

manager = code.CreateInstance("Engine.Logic.StartUp",True);
manager.Init();
"game."